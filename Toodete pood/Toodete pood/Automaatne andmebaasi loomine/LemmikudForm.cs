using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    // Ostja lemmiktooted
    public partial class LemmikudForm : BaasVorm
    {
        private List<Toode> tooted = new();

        public LemmikudForm()
        {
            InitializeComponent();
            Lae();
        }

        private void Lae()
        {
            using var db = new ToodedContext();
            tooted = db.Lemmikud
                .Where(l => l.KasutajaId == AktiivneKasutaja.Id)
                .Select(l => l.Toode)
                .AsNoTracking()
                .OrderBy(t => t.Toodenimetus)
                .ToList();

            dgvLemmikud.DataSource = tooted.Select(t => new
            {
                Toode = t.Toodenimetus,
                Hind = t.OnSoodus ? $"{t.HetkeHind:0.00} € (−{t.SoodusProtsent}%)" : $"{t.Hind:0.00} €",
                Laos = t.Kogus > 0 ? $"{t.Kogus} {Keel.T("tk")}" : Keel.T("Otsas")
            }).ToList();

            bool on = tooted.Count > 0;
            btnAva.Enabled = btnLisaKorvi.Enabled = btnEemalda.Enabled = on;
            Text = on ? $"{Keel.T("Lemmikud")} ({tooted.Count})" : Keel.T("Lemmikud");
        }

        private Toode? Valitud =>
            dgvLemmikud.CurrentRow != null && dgvLemmikud.CurrentRow.Index < tooted.Count
                ? tooted[dgvLemmikud.CurrentRow.Index]
                : null;

        private void btnAva_Click(object? sender, EventArgs e)
        {
            var t = Valitud;
            if (t == null) return;
            using var kaart = new TooteKaartForm(t);
            kaart.ShowDialog(TopLevelControl ?? this);
            Lae();
        }

        private void dgvLemmikud_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnAva_Click(sender, e);
        }

        private void btnLisaKorvi_Click(object? sender, EventArgs e)
        {
            var t = Valitud;
            if (t == null) return;
            MessageBox.Show(Ostukorv.Lisa(t, 1) ?? Keel.T("{0} lisati korvi.", t.Toodenimetus));
        }

        private void btnEemalda_Click(object? sender, EventArgs e)
        {
            var t = Valitud;
            if (t == null) return;
            LemmikTooted.Vaheta(t.Id);
            Lae();
        }
    }
}
