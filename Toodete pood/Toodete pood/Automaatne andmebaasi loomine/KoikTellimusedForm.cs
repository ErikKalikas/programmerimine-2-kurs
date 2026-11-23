using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    // Admin: kõigi ostjate tellimused (otsing ja kuupäevavahemik)
    public partial class KoikTellimusedForm : BaasVorm
    {
        private List<Tellimus> koik = new();
        private Dictionary<int, Kasutaja> kasutajad = new();
        private List<Tellimus> naidatud = new();
        private bool laeb = true;

        public KoikTellimusedForm()
        {
            InitializeComponent();

            using var db = new ToodedContext();
            koik = db.Tellimused.Include(t => t.Read).AsNoTracking()
                     .OrderByDescending(t => t.Kuupaev).ToList();
            kasutajad = db.Kasutajad.AsNoTracking().ToDictionary(k => k.Id);

            // vaikimisi viimased 30 päeva (või alates esimesest tellimusest)
            dtpKuni.Value = DateTime.Today;
            dtpAlates.Value = koik.Count > 0 ? koik.Min(t => t.Kuupaev).Date : DateTime.Today.AddDays(-30);

            laeb = false;
            NaitaTellimused();
        }

        private string Ostja(Tellimus t) =>
            t.KasutajaId != null && kasutajad.TryGetValue(t.KasutajaId.Value, out var k) ? k.Nimi : Keel.T("külaline");

        private void Filter_Changed(object? sender, EventArgs e)
        {
            if (!laeb) NaitaTellimused();
        }

        private void NaitaTellimused()
        {
            DateTime alates = dtpAlates.Value.Date, kuni = dtpKuni.Value.Date.AddDays(1);
            string otsing = txtOtsi.Text.Trim();

            naidatud = koik.Where(t => t.Kuupaev >= alates && t.Kuupaev < kuni)
                .Where(t => otsing == "" ||
                            t.Nr.Contains(otsing, StringComparison.CurrentCultureIgnoreCase) ||
                            t.Email.Contains(otsing, StringComparison.CurrentCultureIgnoreCase) ||
                            Ostja(t).Contains(otsing, StringComparison.CurrentCultureIgnoreCase))
                .ToList();

            dgvTellimused.DataSource = naidatud.Select(t => new
            {
                t.Nr,
                Kuupäev = t.Kuupaev.ToString("dd.MM.yyyy HH:mm"),
                Ostja = Ostja(t),
                t.Email,
                Tooteid = t.Read.Sum(r => r.Kogus),
                Soodustus = t.Soodustus > 0 ? $"−{t.Soodustus:0.00} € ({t.Sooduskood})" : "",
                Summa = $"{t.Summa:0.00} €"
            }).ToList();

            decimal summa = naidatud.Sum(t => t.Summa);
            lblKokku.Text = Keel.T("{0} tellimust, kokku {1:0.00} €", naidatud.Count, summa);

            if (naidatud.Count == 0)
            {
                dgvRead.DataSource = null;
                lblRead.Text = Keel.T("Tellimusi ei leitud.");
            }
        }

        private void dgvTellimused_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvTellimused.CurrentRow == null || dgvTellimused.CurrentRow.Index >= naidatud.Count) return;
            var t = naidatud[dgvTellimused.CurrentRow.Index];

            lblRead.Text = Keel.T("Tellimuse nr {0} tooted", t.Nr);
            dgvRead.DataSource = t.Read.Select(r => new
            {
                Toode = r.Toodenimetus,
                Kogus = $"{r.Kogus} {Keel.T("tk")}",
                Hind = $"{r.Hind:0.00} €",
                Summa = $"{Math.Round(r.Hind * r.Kogus, 2):0.00} €"
            }).ToList();
        }
    }
}
