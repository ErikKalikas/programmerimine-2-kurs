using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace Automaatne_andmebaasi_loomine
{
    // Arve sisu: tuleb kas ostukorvist (uus ost) või salvestatud tellimusest (vana arve uuesti)
    public class ArveAndmed
    {
        public string Nr { get; set; } = string.Empty;
        public DateTime Aeg { get; set; }
        public List<(string Nimetus, int Kogus, float Hind)> Read { get; set; } = new();
        public string? OstjaNimi { get; set; }
        public string? OstjaEmail { get; set; }
        public string? OstjaTelefon { get; set; }
        public string? OstjaAadress { get; set; }
        public string? Sooduskood { get; set; }
        public decimal Soodustus { get; set; }

        public static ArveAndmed Ostukorvist(string? email)
        {
            var a = new ArveAndmed
            {
                Aeg = DateTime.Now,
                OstjaEmail = email,
                Sooduskood = Ostukorv.Sooduskood != null ? $"{Ostukorv.Sooduskood} −{Ostukorv.SoodusProtsent}%" : null,
                Soodustus = (decimal)Ostukorv.Soodustus,
                Read = Ostukorv.Ridad.Select(r => (r.Toode.Toodenimetus, r.Kogus, r.Toode.HetkeHind)).ToList()
            };
            a.Nr = a.Aeg.ToString("yyyyMMdd-HHmmss");
            a.LisaOstjaAndmed(AktiivneKasutaja.Id);
            return a;
        }

        public static ArveAndmed Tellimusest(Tellimus t)
        {
            var a = new ArveAndmed
            {
                Nr = t.Nr,
                Aeg = t.Kuupaev,
                OstjaEmail = t.Email,
                Sooduskood = t.Sooduskood,
                Soodustus = (decimal)t.Soodustus,
                Read = t.Read.Select(r => (r.Toodenimetus, r.Kogus, r.Hind)).ToList()
            };
            a.LisaOstjaAndmed(t.KasutajaId);
            return a;
        }

        // Kontoga ostja nimi, telefon ja aadress tulevad profiilist
        private void LisaOstjaAndmed(int? kasutajaId)
        {
            if (kasutajaId == null) return;
            using var db = new ToodedContext();
            var k = db.Kasutajad.Find(kasutajaId.Value);
            if (k == null) return;
            OstjaNimi = k.Nimi;
            OstjaTelefon = k.Telefon;
            OstjaAadress = k.Aadress;
            if (string.IsNullOrWhiteSpace(OstjaEmail)) OstjaEmail = k.Email;
        }
    }

    // Koostab ostukorvist ilusa PDF-arve (päis, tabel, käibemaks, kokkuvõte)
    public static class ArvePdf
    {

        private static readonly XColor Sinine = XColor.FromArgb(31, 78, 121);
        private static readonly XColor Helesinine = XColor.FromArgb(221, 235, 247);
        private static readonly XColor Triibuline = XColor.FromArgb(246, 250, 254);
        private static readonly XColor Hall = XColor.FromArgb(110, 110, 110);
        private static readonly XPen Joon = new XPen(XColor.FromArgb(200, 200, 200), 0.5);

        private static readonly XStringFormat Vasak = new() { Alignment = XStringAlignment.Near, LineAlignment = XLineAlignment.Center };
        private static readonly XStringFormat Parem = new() { Alignment = XStringAlignment.Far, LineAlignment = XLineAlignment.Center };
        private static readonly XStringFormat Keskel = new() { Alignment = XStringAlignment.Center, LineAlignment = XLineAlignment.Center };

        private const double Serv = 40;        // lehe vasak/parem veeris
        private const double ReaKorgus = 22;

        // Tabeli veerud: Nr | Toode | Kogus | Hind | Summa
        private const double XNr = Serv, XToode = 70, XKogus = 330, XHind = 420, XSumma = 555;

        // Tagastab loodud faili täieliku tee
        public static string Loo(ArveAndmed a)
        {
            Directory.CreateDirectory("Arved");

            DateTime aeg = a.Aeg;
            string nr = a.Nr;
            string failinimi = Path.GetFullPath($"Arved/Arve_{nr.Replace('-', '_')}.pdf");

            var unicode = new XPdfFontOptions(PdfFontEncoding.Unicode);   // täpitähed õ ä ö ü ja €
            XFont Font(double suurus, XFontStyle stiil = XFontStyle.Regular) => new XFont("Verdana", suurus, stiil, unicode);

            var pood = PoeSeaded.Lae();                               // poe andmed ja käibemaks seadetest
            decimal KaibemaksProtsent = (decimal)pood.KmProtsent;

            var dokument = new PdfDocument();
            dokument.Info.Title = $"Arve {nr}";

            PdfPage leht = dokument.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(leht);
            double parem = leht.Width.Point - Serv;

            // ---------- Päis ----------
            gfx.DrawRectangle(new XSolidBrush(Sinine), 0, 0, leht.Width.Point, 95);
            double tekstX = Serv;
            string? logoTee = string.IsNullOrEmpty(pood.Logo) ? null : Path.Combine("Images", pood.Logo);
            if (logoTee != null && File.Exists(logoTee))
            {
                // logo valgel ruudul päise vasakus servas
                using var logo = XImage.FromFile(logoTee);
                double lk = 65, ll = Math.Min(130, lk * logo.PixelWidth / Math.Max(1, logo.PixelHeight));
                gfx.DrawRectangle(XBrushes.White, Serv - 4, 15, ll + 8, lk + 8);
                gfx.DrawImage(logo, Serv, 19, ll, lk);
                tekstX = Serv + ll + 18;
            }
            gfx.DrawString(pood.PoeNimi.ToUpper(), Font(22, XFontStyle.Bold), XBrushes.White, new XRect(tekstX, 25, 330, 30), Vasak);
            gfx.DrawString(pood.Hyydlause, Font(10), XBrushes.White, new XRect(tekstX, 55, 330, 20), Vasak);
            gfx.DrawString("ARVE", Font(22, XFontStyle.Bold), XBrushes.White, new XRect(Serv, 25, parem - Serv, 30), Parem);
            gfx.DrawString($"Nr {nr}", Font(10), XBrushes.White, new XRect(Serv, 55, parem - Serv, 20), Parem);

            // ---------- Arve andmed ----------
            double y = 120;
            void InfoRida(string silt, string vaartus)
            {
                gfx.DrawString(silt, Font(10), new XSolidBrush(Hall), new XRect(Serv, y, 110, 16), Vasak);
                gfx.DrawString(vaartus, Font(10, XFontStyle.Bold), XBrushes.Black, new XRect(Serv + 110, y, 300, 16), Vasak);
                y += 18;
            }
            InfoRida("Kuupäev:", aeg.ToString("dd.MM.yyyy HH:mm"));
            InfoRida("Müüja:", pood.PoeNimi);
            if (!string.IsNullOrWhiteSpace(a.OstjaNimi)) InfoRida("Ostja:", a.OstjaNimi);
            if (!string.IsNullOrWhiteSpace(a.OstjaEmail)) InfoRida("E-post:", a.OstjaEmail);
            if (!string.IsNullOrWhiteSpace(a.OstjaTelefon)) InfoRida("Telefon:", a.OstjaTelefon);
            if (!string.IsNullOrWhiteSpace(a.OstjaAadress)) InfoRida("Aadress:", a.OstjaAadress);
            InfoRida("Makseviis:", "Arve e-postiga");
            y += 15;

            // ---------- Tabel ----------
            void TabeliPais()
            {
                gfx.DrawRectangle(new XSolidBrush(Sinine), Serv, y, parem - Serv, ReaKorgus);
                XFont f = Font(9, XFontStyle.Bold);
                gfx.DrawString("Nr", f, XBrushes.White, new XRect(XNr + 6, y, 30, ReaKorgus), Vasak);
                gfx.DrawString("Toode", f, XBrushes.White, new XRect(XToode, y, 250, ReaKorgus), Vasak);
                gfx.DrawString("Kogus", f, XBrushes.White, new XRect(XKogus - 60, y, 60, ReaKorgus), Parem);
                gfx.DrawString("Hind", f, XBrushes.White, new XRect(XHind - 80, y, 80, ReaKorgus), Parem);
                gfx.DrawString("Summa", f, XBrushes.White, new XRect(XSumma - 100, y, 94, ReaKorgus), Parem);
                y += ReaKorgus;
            }

            // Pikk nimi lühendatakse, et see mahuks veergu
            string Mahuta(string tekst, XFont f, double laius)
            {
                if (gfx.MeasureString(tekst, f).Width <= laius) return tekst;
                while (tekst.Length > 1 && gfx.MeasureString(tekst + "…", f).Width > laius)
                    tekst = tekst[..^1];
                return tekst + "…";
            }

            TabeliPais();
            XFont reaFont = Font(9);
            int jrk = 0;
            foreach (var rida in a.Read)
            {
                // Kui leht saab täis, jätkub tabel uuel lehel
                if (y + ReaKorgus > leht.Height.Point - 95)
                {
                    leht = dokument.AddPage();
                    gfx = XGraphics.FromPdfPage(leht);
                    y = Serv;
                    TabeliPais();
                }

                jrk++;
                if (jrk % 2 == 0)
                    gfx.DrawRectangle(new XSolidBrush(Triibuline), Serv, y, parem - Serv, ReaKorgus);
                if (jrk > 1)
                    gfx.DrawLine(Joon, Serv, y, parem, y);   // eraldusjoon eelmise rea alla

                gfx.DrawString(jrk.ToString(), reaFont, XBrushes.Black, new XRect(XNr + 6, y, 30, ReaKorgus), Vasak);
                gfx.DrawString(Mahuta(rida.Nimetus, reaFont, XKogus - XToode - 70), reaFont, XBrushes.Black,
                    new XRect(XToode, y, XKogus - XToode - 60, ReaKorgus), Vasak);
                gfx.DrawString($"{rida.Kogus} tk", reaFont, XBrushes.Black, new XRect(XKogus - 60, y, 60, ReaKorgus), Parem);
                gfx.DrawString($"{rida.Hind:0.00} €", reaFont, XBrushes.Black, new XRect(XHind - 80, y, 80, ReaKorgus), Parem);
                gfx.DrawString($"{Math.Round((decimal)rida.Hind * rida.Kogus, 2):0.00} €", Font(9, XFontStyle.Bold), XBrushes.Black, new XRect(XSumma - 100, y, 94, ReaKorgus), Parem);

                y += ReaKorgus;
            }
            gfx.DrawLine(Joon, Serv, y, parem, y);   // tabeli alumine joon

            // ---------- Kokkuvõte ----------
            if (y + 200 > leht.Height.Point - 95)
            {
                leht = dokument.AddPage();
                gfx = XGraphics.FromPdfPage(leht);
                y = Serv;
            }

            decimal vahesumma = a.Read.Sum(r => Math.Round((decimal)r.Hind * r.Kogus, 2));
            decimal kokku = vahesumma - a.Soodustus;
            decimal kaibemaks = Math.Round(kokku * KaibemaksProtsent / (100 + KaibemaksProtsent), 2);
            decimal ilmaKm = kokku - kaibemaks;

            y += 15;
            double sx = 330;   // kokkuvõtte ploki algus
            void SummaRida(string silt, decimal summa)
            {
                gfx.DrawString(silt, Font(10), new XSolidBrush(Hall), new XRect(sx, y, 170, 18), Vasak);
                gfx.DrawString($"{summa:0.00} €", Font(10), XBrushes.Black, new XRect(sx, y, parem - sx - 6, 18), Parem);
                y += 20;
            }
            if (a.Soodustus > 0)
            {
                SummaRida("Vahesumma:", vahesumma);
                SummaRida($"Soodustus ({a.Sooduskood}):", -a.Soodustus);
            }
            SummaRida("Summa km-ta:", ilmaKm);
            SummaRida($"Käibemaks {KaibemaksProtsent:0}%:", kaibemaks);

            y += 4;
            gfx.DrawRectangle(new XSolidBrush(Helesinine), sx - 6, y, parem - sx + 6, 30);
            gfx.DrawString("KOKKU TASUDA", Font(11, XFontStyle.Bold), new XSolidBrush(Sinine), new XRect(sx, y, 150, 30), Vasak);
            gfx.DrawString($"{kokku:0.00} €", Font(14, XFontStyle.Bold), new XSolidBrush(Sinine), new XRect(sx, y, parem - sx - 6, 30), Parem);

            gfx.DrawString($"Tooteid kokku: {a.Read.Sum(r => r.Kogus)} tk", Font(9), new XSolidBrush(Hall), new XRect(Serv, y, 250, 30), Vasak);

            // ---------- Jalus ----------
            double jy = leht.Height.Point - 80;
            gfx.DrawLine(new XPen(Sinine, 1), Serv, jy, parem, jy);
            gfx.DrawString("Aitäh ostu eest! Ootame teid jälle.", Font(11, XFontStyle.Bold), new XSolidBrush(Sinine),
                new XRect(0, jy + 8, leht.Width.Point, 20), Keskel);

            // poe rekvisiidid (ainult täidetud väljad)
            var rekvisiidid = new List<string> { pood.PoeNimi };
            if (pood.Aadress != "") rekvisiidid.Add(pood.Aadress);
            if (pood.Registrikood != "") rekvisiidid.Add($"Reg. kood {pood.Registrikood}");
            if (pood.KmkrNr != "") rekvisiidid.Add($"KMKR {pood.KmkrNr}");
            if (pood.Telefon != "") rekvisiidid.Add(pood.Telefon);
            if (pood.Email != "") rekvisiidid.Add(pood.Email);
            gfx.DrawString(string.Join("  •  ", rekvisiidid), Font(8), new XSolidBrush(Hall),
                new XRect(0, jy + 30, leht.Width.Point, 14), Keskel);
            gfx.DrawString("Arve on koostatud elektrooniliselt ja kehtib allkirjata.", Font(8), new XSolidBrush(Hall),
                new XRect(0, jy + 46, leht.Width.Point, 14), Keskel);

            dokument.Save(failinimi);
            return failinimi;
        }
    }
}
