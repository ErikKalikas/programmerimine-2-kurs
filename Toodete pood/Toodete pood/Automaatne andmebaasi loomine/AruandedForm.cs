using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    // Admin: müügiaruanne valitud perioodi kohta (tulu, käibemaks, top-10, kategooriad)
    public partial class AruandedForm : Form
    {
        private readonly List<Tellimus> koik;
        private readonly Dictionary<int, string> tooteKategooria;   // ToodeId -> kategooria nimi
        private readonly float kmProtsent;
        private List<Tellimus> perioodis = new();
        private bool laeb = true;

        public AruandedForm()
        {
            InitializeComponent();

            using var db = new ToodedContext();
            koik = db.Tellimused.Include(t => t.Read).AsNoTracking().ToList();
            tooteKategooria = db.Toodetabel.Include(t => t.Kategooria).AsNoTracking()
                                .ToDictionary(t => t.Id, t => t.Kategooria.Kategooria_nimetus);
            kmProtsent = PoeSeaded.Lae().KmProtsent;

            MaaraPeriood(DateTime.Today.AddDays(-29), DateTime.Today);   // vaikimisi 30 päeva
        }

        private void MaaraPeriood(DateTime alates, DateTime kuni)
        {
            laeb = true;
            dtpAlates.Value = alates;
            dtpKuni.Value = kuni;
            laeb = false;
            Arvuta();
        }

        private void btnTana_Click(object? sender, EventArgs e) => MaaraPeriood(DateTime.Today, DateTime.Today);
        private void btnNadal_Click(object? sender, EventArgs e) => MaaraPeriood(DateTime.Today.AddDays(-6), DateTime.Today);
        private void btnKuu_Click(object? sender, EventArgs e) => MaaraPeriood(DateTime.Today.AddDays(-29), DateTime.Today);
        private void btnKoik_Click(object? sender, EventArgs e) =>
            MaaraPeriood(koik.Count > 0 ? koik.Min(t => t.Kuupaev).Date : DateTime.Today, DateTime.Today);

        private void Periood_Changed(object? sender, EventArgs e)
        {
            if (!laeb) Arvuta();
        }

        private void Arvuta()
        {
            DateTime alates = dtpAlates.Value.Date, kuni = dtpKuni.Value.Date.AddDays(1);
            perioodis = koik.Where(t => t.Kuupaev >= alates && t.Kuupaev < kuni).ToList();
            var read = perioodis.SelectMany(t => t.Read).ToList();

            decimal tulu = perioodis.Sum(t => (decimal)t.Summa);
            decimal soodustused = perioodis.Sum(t => (decimal)t.Soodustus);
            decimal km = Math.Round(tulu * (decimal)kmProtsent / (100 + (decimal)kmProtsent), 2);
            decimal keskmine = perioodis.Count > 0 ? tulu / perioodis.Count : 0;
            int ostjaid = perioodis.Select(t => t.KasutajaId?.ToString() ?? t.Email).Distinct().Count();

            lblKokkuvote.Text =
                $"Periood: {alates:dd.MM.yyyy} – {kuni.AddDays(-1):dd.MM.yyyy}\n\n" +
                $"Tellimusi:  {perioodis.Count}\n" +
                $"Erinevaid ostjaid:  {ostjaid}\n" +
                $"Müüdud tooteid:  {read.Sum(r => r.Kogus)} tk\n\n" +
                $"Müügitulu:  {tulu:0.00} €\n" +
                $"Keskmine ost:  {keskmine:0.00} €\n" +
                $"Antud soodustusi:  {soodustused:0.00} €\n\n" +
                $"Käibemaks {kmProtsent:0}%:  {km:0.00} €\n" +
                $"Tulu km-ta:  {tulu - km:0.00} €";

            // Top-10 tooted müüdud koguse järgi
            dgvTop.DataSource = read
                .GroupBy(r => r.Toodenimetus)
                .Select(g => new
                {
                    Toode = g.Key,
                    Kogus = g.Sum(r => r.Kogus),
                    Müük = Math.Round(g.Sum(r => (decimal)r.Hind * r.Kogus), 2)
                })
                .OrderByDescending(x => x.Kogus).ThenByDescending(x => x.Müük)
                .Take(10)
                .Select((x, i) => new { Koht = i + 1, x.Toode, Kogus = $"{x.Kogus} tk", Müük = $"{x.Müük:0.00} €" })
                .ToList();

            // Kategooriad (summad enne sooduskoodi); kustutatud tooted eraldi
            decimal kokkuRead = read.Sum(r => (decimal)r.Hind * r.Kogus);
            dgvKategooriad.DataSource = read
                .GroupBy(r => tooteKategooria.TryGetValue(r.ToodeId, out var k) ? k : "Kustutatud tooted")
                .Select(g => new
                {
                    Kategooria = g.Key,
                    Müük = Math.Round(g.Sum(r => (decimal)r.Hind * r.Kogus), 2),
                    Kogus = g.Sum(r => r.Kogus)
                })
                .OrderByDescending(x => x.Müük)
                .Select(x => new
                {
                    x.Kategooria,
                    Kogus = $"{x.Kogus} tk",
                    Müük = $"{x.Müük:0.00} €",
                    Osakaal = kokkuRead > 0 ? $"{x.Müük / kokkuRead * 100:0}%" : "–"
                })
                .ToList();
        }
    }
}
