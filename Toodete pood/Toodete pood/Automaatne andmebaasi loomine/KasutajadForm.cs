using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    // Admin: kasutajate nimekiri, uus administraator, rolli muutmine ja blokeerimine
    public partial class KasutajadForm : Form
    {
        private List<Kasutaja> kasutajad = new();

        public KasutajadForm()
        {
            InitializeComponent();
            Lae();
        }

        private void Lae()
        {
            using var db = new ToodedContext();
            kasutajad = db.Kasutajad.AsNoTracking().OrderBy(k => k.Roll).ThenBy(k => k.Nimi).ToList();
            var tellimusi = db.Tellimused.Where(t => t.KasutajaId != null)
                              .GroupBy(t => t.KasutajaId!.Value)
                              .Select(g => new { Id = g.Key, Arv = g.Count() })
                              .ToDictionary(x => x.Id, x => x.Arv);

            dgvKasutajad.DataSource = kasutajad.Select(k => new
            {
                k.Nimi,
                k.Email,
                Roll = k.Roll == "admin" ? "administraator" : "ostja",
                Olek = k.Blokeeritud ? "Blokeeritud" : "Aktiivne",
                Tellimusi = tellimusi.TryGetValue(k.Id, out int n) ? n : 0
            }).ToList();
        }

        // Blokeeritud kontod hallilt
        private void dgvKasutajad_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvKasutajad.Rows.Count && i < kasutajad.Count; i++)
                if (kasutajad[i].Blokeeritud)
                    dgvKasutajad.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
        }

        private Kasutaja? Valitud =>
            dgvKasutajad.CurrentRow != null && dgvKasutajad.CurrentRow.Index < kasutajad.Count
                ? kasutajad[dgvKasutajad.CurrentRow.Index]
                : null;

        // Ennast ei saa blokeerida ega rollist ilma jätta, et admin ei lukustaks end välja
        private bool OnMina(Kasutaja k)
        {
            if (k.Id != AktiivneKasutaja.Id) return false;
            MessageBox.Show("Oma kontot siin muuta ei saa.");
            return true;
        }

        private void btnLisaAdmin_Click(object? sender, EventArgs e)
        {
            using var f = new RegistreerimineForm("admin");
            if (f.ShowDialog(this) == DialogResult.OK) Lae();
        }

        private void btnRoll_Click(object? sender, EventArgs e)
        {
            var valitud = Valitud;
            if (valitud == null || OnMina(valitud)) return;

            string uus = valitud.Roll == "admin" ? "kasutaja" : "admin";
            string tekst = uus == "admin" ? "teha administraatoriks" : "muuta tavaliseks ostjaks";
            if (MessageBox.Show($"Kas {valitud.Nimi} {tekst}?", "Muuda rolli", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using var db = new ToodedContext();
            var k = db.Kasutajad.Find(valitud.Id);
            if (k == null) return;
            k.Roll = uus;
            db.SaveChanges();
            Tegevuslogi.Kirjuta($"Muutis kasutaja {k.Email} rolliks: {(uus == "admin" ? "administraator" : "ostja")}");
            Lae();
        }

        private void btnBlokeeri_Click(object? sender, EventArgs e)
        {
            var valitud = Valitud;
            if (valitud == null || OnMina(valitud)) return;

            using var db = new ToodedContext();
            var k = db.Kasutajad.Find(valitud.Id);
            if (k == null) return;
            k.Blokeeritud = !k.Blokeeritud;
            db.SaveChanges();
            Tegevuslogi.Kirjuta(k.Blokeeritud ? $"Blokeeris kasutaja {k.Email}" : $"Avas kasutaja {k.Email} blokeeringu");

            MessageBox.Show(k.Blokeeritud ? $"{k.Nimi} on blokeeritud ega saa enam sisse logida." : $"{k.Nimi} saab jälle sisse logida.");
            Lae();
        }
    }
}
