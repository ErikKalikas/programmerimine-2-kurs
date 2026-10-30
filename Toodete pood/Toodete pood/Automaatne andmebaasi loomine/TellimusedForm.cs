using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Automaatne_andmebaasi_loomine
{
    // Ostja varasemad ostud: tooted, arve uuesti avamine ja "Telli uuesti"
    public partial class TellimusedForm : Form
    {
        private List<Tellimus> tellimused = new();

        public TellimusedForm()
        {
            InitializeComponent();

            using var db = new ToodedContext();
            tellimused = db.Tellimused
                .Include(t => t.Read)
                .Where(t => t.KasutajaId == AktiivneKasutaja.Id)
                .OrderByDescending(t => t.Kuupaev)
                .AsNoTracking()
                .ToList();

            dgvTellimused.DataSource = tellimused.Select(t => new
            {
                Nr = t.Nr,
                Kuupäev = t.Kuupaev.ToString("dd.MM.yyyy HH:mm"),
                Tooteid = t.Read.Sum(r => r.Kogus),
                Soodustus = t.Soodustus > 0 ? $"−{t.Soodustus:0.00} €" : "",
                Summa = $"{t.Summa:0.00} €"
            }).ToList();

            if (tellimused.Count == 0)
            {
                lblRead.Text = "Sul pole veel ühtegi tellimust.";
                btnAvaArve.Enabled = false;
                btnTelliUuesti.Enabled = false;
            }
        }

        private Tellimus? Valitud =>
            dgvTellimused.CurrentRow != null && dgvTellimused.CurrentRow.Index < tellimused.Count
                ? tellimused[dgvTellimused.CurrentRow.Index]
                : null;

        private void dgvTellimused_SelectionChanged(object? sender, EventArgs e)
        {
            var t = Valitud;
            if (t == null) return;

            lblRead.Text = $"Tellimuse nr {t.Nr} tooted";
            dgvRead.DataSource = t.Read.Select(r => new
            {
                Toode = r.Toodenimetus,
                Kogus = $"{r.Kogus} tk",
                Hind = $"{r.Hind:0.00} €",
                Summa = $"{Math.Round((decimal)r.Hind * r.Kogus, 2):0.00} €"
            }).ToList();
        }

        private void btnAvaArve_Click(object? sender, EventArgs e)
        {
            var t = Valitud;
            if (t == null) return;

            // Kui PDF-faili enam pole (nt teine arvuti), tehakse arve tellimuse andmetest uuesti
            string? fail = t.PdfFail;
            if (string.IsNullOrEmpty(fail) || !File.Exists(fail))
            {
                fail = ArvePdf.Loo(ArveAndmed.Tellimusest(t));

                using var db = new ToodedContext();
                var salvestatud = db.Tellimused.Find(t.Id);
                if (salvestatud != null)
                {
                    salvestatud.PdfFail = fail;
                    db.SaveChanges();
                }
                t.PdfFail = fail;
            }

            Process.Start(new ProcessStartInfo(fail) { UseShellExecute = true });
        }

        private void btnTelliUuesti_Click(object? sender, EventArgs e)
        {
            var t = Valitud;
            if (t == null) return;

            using var db = new ToodedContext();
            var teated = new List<string>();
            int lisatud = 0;

            foreach (var r in t.Read)
            {
                var toode = db.Toodetabel.AsNoTracking().FirstOrDefault(x => x.Id == r.ToodeId);
                if (toode == null) { teated.Add($"{r.Toodenimetus}: toodet enam ei müüda"); continue; }

                int korvis = Ostukorv.Ridad.FirstOrDefault(x => x.Toode.Id == toode.Id)?.Kogus ?? 0;
                int kogus = Math.Min(r.Kogus, toode.Kogus - korvis);
                if (kogus <= 0) { teated.Add($"{r.Toodenimetus}: otsas"); continue; }

                if (Ostukorv.Lisa(toode, kogus) == null)
                {
                    lisatud++;
                    if (kogus < r.Kogus) teated.Add($"{r.Toodenimetus}: lisati ainult {kogus} tk (rohkem pole laos)");
                }
            }

            string tekst = $"Korvi lisati {lisatud} toodet.";
            if (teated.Count > 0) tekst += "\n\n" + string.Join("\n", teated);
            MessageBox.Show(tekst);
        }
    }
}
