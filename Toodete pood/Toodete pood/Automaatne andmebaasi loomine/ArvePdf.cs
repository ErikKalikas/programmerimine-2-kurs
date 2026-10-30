using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace Automaatne_andmebaasi_loomine
{
    // Koostab ostukorvist ilusa PDF-arve (päis, tabel, käibemaks, kokkuvõte)
    public static class ArvePdf
    {
        private const decimal KaibemaksProtsent = 24m;   // Eesti käibemaks alates 01.07.2025

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
        public static string Loo(IReadOnlyList<OstukorviRida> read, string? ostja = null)
        {
            Directory.CreateDirectory("Arved");

            DateTime aeg = DateTime.Now;
            string nr = aeg.ToString("yyyyMMdd-HHmmss");
            string failinimi = Path.GetFullPath($"Arved/Arve_{aeg:yyyyMMdd_HHmmss}.pdf");

            var unicode = new XPdfFontOptions(PdfFontEncoding.Unicode);   // täpitähed õ ä ö ü ja €
            XFont Font(double suurus, XFontStyle stiil = XFontStyle.Regular) => new XFont("Verdana", suurus, stiil, unicode);

            var dokument = new PdfDocument();
            dokument.Info.Title = $"Arve {nr}";

            PdfPage leht = dokument.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(leht);
            double parem = leht.Width.Point - Serv;

            // ---------- Päis ----------
            gfx.DrawRectangle(new XSolidBrush(Sinine), 0, 0, leht.Width.Point, 95);
            gfx.DrawString("TOODETE POOD", Font(22, XFontStyle.Bold), XBrushes.White, new XRect(Serv, 25, 300, 30), Vasak);
            gfx.DrawString("Värsked tooted iga päev", Font(10), XBrushes.White, new XRect(Serv, 55, 300, 20), Vasak);
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
            InfoRida("Müüja:", "Toodete pood");
            if (!string.IsNullOrWhiteSpace(ostja)) InfoRida("Ostja:", ostja);
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
            foreach (var rida in read)
            {
                // Kui leht saab täis, jätkub tabel uuel lehel
                if (y + ReaKorgus > leht.Height.Point - 60)
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
                gfx.DrawString(Mahuta(rida.Toode.Toodenimetus, reaFont, XKogus - XToode - 70), reaFont, XBrushes.Black,
                    new XRect(XToode, y, XKogus - XToode - 60, ReaKorgus), Vasak);
                gfx.DrawString($"{rida.Kogus} tk", reaFont, XBrushes.Black, new XRect(XKogus - 60, y, 60, ReaKorgus), Parem);
                gfx.DrawString($"{rida.Toode.Hind:0.00} €", reaFont, XBrushes.Black, new XRect(XHind - 80, y, 80, ReaKorgus), Parem);
                gfx.DrawString($"{rida.Summa:0.00} €", Font(9, XFontStyle.Bold), XBrushes.Black, new XRect(XSumma - 100, y, 94, ReaKorgus), Parem);

                y += ReaKorgus;
            }
            gfx.DrawLine(Joon, Serv, y, parem, y);   // tabeli alumine joon

            // ---------- Kokkuvõte ----------
            if (y + 150 > leht.Height.Point - 60)
            {
                leht = dokument.AddPage();
                gfx = XGraphics.FromPdfPage(leht);
                y = Serv;
            }

            decimal kokku = read.Sum(r => (decimal)r.Summa);
            decimal kaibemaks = Math.Round(kokku * KaibemaksProtsent / (100 + KaibemaksProtsent), 2);
            decimal ilmaKm = kokku - kaibemaks;

            y += 15;
            double sx = 330;   // kokkuvõtte ploki algus
            void SummaRida(string silt, decimal summa)
            {
                gfx.DrawString(silt, Font(10), new XSolidBrush(Hall), new XRect(sx, y, 130, 18), Vasak);
                gfx.DrawString($"{summa:0.00} €", Font(10), XBrushes.Black, new XRect(sx, y, parem - sx - 6, 18), Parem);
                y += 20;
            }
            SummaRida("Summa km-ta:", ilmaKm);
            SummaRida($"Käibemaks {KaibemaksProtsent:0}%:", kaibemaks);

            y += 4;
            gfx.DrawRectangle(new XSolidBrush(Helesinine), sx - 6, y, parem - sx + 6, 30);
            gfx.DrawString("KOKKU TASUDA", Font(11, XFontStyle.Bold), new XSolidBrush(Sinine), new XRect(sx, y, 150, 30), Vasak);
            gfx.DrawString($"{kokku:0.00} €", Font(14, XFontStyle.Bold), new XSolidBrush(Sinine), new XRect(sx, y, parem - sx - 6, 30), Parem);

            gfx.DrawString($"Tooteid kokku: {read.Sum(r => r.Kogus)} tk", Font(9), new XSolidBrush(Hall), new XRect(Serv, y, 250, 30), Vasak);

            // ---------- Jalus ----------
            double jy = leht.Height.Point - 70;
            gfx.DrawLine(new XPen(Sinine, 1), Serv, jy, parem, jy);
            gfx.DrawString("Aitäh ostu eest! Ootame teid jälle.", Font(11, XFontStyle.Bold), new XSolidBrush(Sinine),
                new XRect(0, jy + 8, leht.Width.Point, 20), Keskel);
            gfx.DrawString("Arve on koostatud elektrooniliselt ja kehtib allkirjata.", Font(8), new XSolidBrush(Hall),
                new XRect(0, jy + 28, leht.Width.Point, 16), Keskel);

            dokument.Save(failinimi);
            return failinimi;
        }
    }
}
