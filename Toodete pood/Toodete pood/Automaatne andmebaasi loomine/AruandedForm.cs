using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    // Admin: müügiaruanne valitud perioodi kohta (tulu, käibemaks, top-10, kategooriad)
    public partial class AruandedForm : BaasVorm
    {
        private readonly List<Tellimus> koik;
        private readonly Dictionary<int, string> tooteKategooria;   // ToodeId -> kategooria nimi
        private readonly float kmProtsent;
        private List<Tellimus> perioodis = new();
        private bool laeb = true;

        public AruandedForm()
        {
            InitializeComponent();
            pnlGraafik.Resize += (_, _) => pnlGraafik.Invalidate();

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

            decimal tulu = perioodis.Sum(t => t.Summa);
            decimal soodustused = perioodis.Sum(t => t.Soodustus);
            decimal km = Math.Round(tulu * (decimal)kmProtsent / (100 + (decimal)kmProtsent), 2);
            decimal keskmine = perioodis.Count > 0 ? tulu / perioodis.Count : 0;
            int ostjaid = perioodis.Select(t => t.KasutajaId?.ToString() ?? t.Email).Distinct().Count();

            lblKokkuvote.Text =
                $"{Keel.T("Periood")}: {alates:dd.MM.yyyy} – {kuni.AddDays(-1):dd.MM.yyyy}\n\n" +
                $"{Keel.T("Tellimusi")}:  {perioodis.Count}\n" +
                $"{Keel.T("Erinevaid ostjaid")}:  {ostjaid}\n" +
                $"{Keel.T("Müüdud tooteid")}:  {read.Sum(r => r.Kogus)} {Keel.T("tk")}\n\n" +
                $"{Keel.T("Müügitulu")}:  {tulu:0.00} €\n" +
                $"{Keel.T("Keskmine ost")}:  {keskmine:0.00} €\n" +
                $"{Keel.T("Antud soodustusi")}:  {soodustused:0.00} €\n\n" +
                $"{Keel.T("Käibemaks")} {kmProtsent:0}%:  {km:0.00} €\n" +
                $"{Keel.T("Tulu km-ta")}:  {tulu - km:0.00} €";

            // Top-10 tooted müüdud koguse järgi
            dgvTop.DataSource = read
                .GroupBy(r => r.Toodenimetus)
                .Select(g => new
                {
                    Toode = g.Key,
                    Kogus = g.Sum(r => r.Kogus),
                    Müük = Math.Round(g.Sum(r => r.Hind * r.Kogus), 2)
                })
                .OrderByDescending(x => x.Kogus).ThenByDescending(x => x.Müük)
                .Take(10)
                .Select((x, i) => new { Koht = i + 1, x.Toode, Kogus = $"{x.Kogus} {Keel.T("tk")}", Müük = $"{x.Müük:0.00} €" })
                .ToList();

            // Kategooriad (summad enne sooduskoodi); kustutatud tooted eraldi
            decimal kokkuRead = read.Sum(r => r.Hind * r.Kogus);
            dgvKategooriad.DataSource = read
                .GroupBy(r => tooteKategooria.TryGetValue(r.ToodeId, out var k) ? k : Keel.T("Kustutatud tooted"))
                .Select(g => new
                {
                    Kategooria = g.Key,
                    Müük = Math.Round(g.Sum(r => r.Hind * r.Kogus), 2),
                    Kogus = g.Sum(r => r.Kogus)
                })
                .OrderByDescending(x => x.Müük)
                .Select(x => new
                {
                    x.Kategooria,
                    Kogus = $"{x.Kogus} {Keel.T("tk")}",
                    Müük = $"{x.Müük:0.00} €",
                    Osakaal = kokkuRead > 0 ? $"{x.Müük / kokkuRead * 100:0}%" : "–"
                })
                .ToList();

            pnlGraafik.Invalidate();   // joonista graafik uuesti
        }

        // Müügitulu tulpdiagramm: päevade kaupa (pika perioodi korral kuude kaupa)
        private void pnlGraafik_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DateTime alates = dtpAlates.Value.Date, kuni = dtpKuni.Value.Date;
            bool kuudeKaupa = (kuni - alates).TotalDays > 62;

            // perioodid ja nende tulu
            var tulbad = new List<(string Silt, decimal Summa)>();
            if (kuudeKaupa)
            {
                for (var k = new DateTime(alates.Year, alates.Month, 1); k <= kuni; k = k.AddMonths(1))
                    tulbad.Add((k.ToString("MM.yy"),
                        perioodis.Where(t => t.Kuupaev.Year == k.Year && t.Kuupaev.Month == k.Month).Sum(t => t.Summa)));
            }
            else
            {
                for (var p = alates; p <= kuni; p = p.AddDays(1))
                    tulbad.Add((p.ToString("dd.MM"), perioodis.Where(t => t.Kuupaev.Date == p).Sum(t => t.Summa)));
            }

            using var pealkiriFont = new Font("Segoe UI Semibold", 12F);
            using var vaikeFont = new Font("Segoe UI", 8F);
            using var tekstiPintsel = new SolidBrush(Teema.Tekst);
            using var hallPintsel = new SolidBrush(Teema.HallTume);
            g.DrawString(Keel.T(kuudeKaupa ? "Müügitulu kuude kaupa" : "Müügitulu päevade kaupa"), pealkiriFont, tekstiPintsel, 4, 0);

            decimal max = tulbad.Count > 0 ? tulbad.Max(t => t.Summa) : 0;
            if (max == 0)
            {
                g.DrawString(Keel.T("Selles perioodis müüki ei olnud."), Teema.Tavaline, hallPintsel, 6, 34);
                return;
            }

            const int vasak = 10, ylal = 44, all = 24;
            int laius = pnlGraafik.ClientSize.Width - vasak * 2;
            int korgus = pnlGraafik.ClientSize.Height - ylal - all;
            float samm = (float)laius / tulbad.Count;
            float tulbaLaius = Math.Max(2, samm * 0.7f);
            int sildiIga = Math.Max(1, (int)Math.Ceiling(40 / samm));   // silte ei tohi olla liiga tihedalt

            using var pintsel = new SolidBrush(Teema.Punane);
            using var telg = new Pen(Teema.Aare);
            g.DrawLine(telg, vasak, ylal + korgus, vasak + laius, ylal + korgus);

            for (int i = 0; i < tulbad.Count; i++)
            {
                float h = (float)(tulbad[i].Summa / max) * (korgus - 12);
                float x = vasak + i * samm + (samm - tulbaLaius) / 2;
                float y = ylal + korgus - h;
                if (h > 0)
                {
                    // ülemiste nurkadega tulp
                    int r = (int)Math.Min(6, tulbaLaius / 2);
                    using var tulp = Teema.UmarRuut(new Rectangle((int)x, (int)y, (int)Math.Max(2, tulbaLaius), (int)h + r), r);
                    g.SetClip(new RectangleF(x - 1, y - 1, tulbaLaius + 2, h + 1));
                    g.FillPath(pintsel, tulp);
                    g.ResetClip();
                }

                // suurima tulba ja vähese tulpade arvu korral näita summat
                if (tulbad[i].Summa > 0 && (tulbad.Count <= 15 || tulbad[i].Summa == max))
                    g.DrawString($"{tulbad[i].Summa:0}€", vaikeFont, tekstiPintsel, x - 2, y - 14);

                if (i % sildiIga == 0)
                    g.DrawString(tulbad[i].Silt, vaikeFont, hallPintsel, x - 4, ylal + korgus + 4);
            }
        }
    }
}
