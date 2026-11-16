using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Automaatne_andmebaasi_loomine
{
    // Rakenduse kujundus: värvid (must, punane, hall), fondid ja kõigi vormide ühtne stiil
    public static class Teema
    {
        public static readonly Color Must = Color.FromArgb(17, 17, 17);
        public static readonly Color MustHele = Color.FromArgb(38, 38, 40);
        public static readonly Color Punane = Color.FromArgb(220, 38, 38);
        public static readonly Color PunaneTume = Color.FromArgb(185, 28, 28);
        public static readonly Color PunaneHele = Color.FromArgb(254, 226, 226);
        public static readonly Color Taust = Color.FromArgb(243, 243, 245);   // lehe taust (helehall)
        public static readonly Color Hall = Color.FromArgb(229, 229, 233);
        public static readonly Color HallTume = Color.FromArgb(110, 110, 118);
        public static readonly Color Aare = Color.FromArgb(222, 222, 228);
        public static readonly Color Tekst = Color.FromArgb(28, 28, 30);
        public static readonly Color Valge = Color.White;

        public static readonly Font Tavaline = new("Segoe UI", 10F);
        public static readonly Font Paks = new("Segoe UI Semibold", 10F);
        public static readonly Font Vaike = new("Segoe UI", 8.5F);
        public static readonly Font Pealkiri = new("Segoe UI", 18F, FontStyle.Bold);
        public static readonly Font Alapealkiri = new("Segoe UI Semibold", 13F);
        public static readonly Font KaardiNimi = new("Segoe UI Semibold", 10.5F);
        public static readonly Font KaardiHind = new("Segoe UI", 15F, FontStyle.Bold);
        public static readonly Font VanaHind = new("Segoe UI", 9F, FontStyle.Strikeout);
        public static readonly Font Mark = new("Segoe UI", 9F, FontStyle.Bold);
        public static readonly Font Ikoonid = new("Segoe MDL2 Assets", 12F);

        // Ümarate nurkadega ristkülik
        public static GraphicsPath UmarRuut(Rectangle r, int raadius)
        {
            var path = new GraphicsPath();
            int d = Math.Max(1, Math.Min(raadius * 2, Math.Min(r.Width, r.Height)));
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // Esimene läbipaistmatu taustavärv vanemate seast (ümarate nurkade taha)
        public static Color VanemaTaust(Control c)
        {
            for (var p = c.Parent; p != null; p = p.Parent)
                if (p.BackColor.A == 255) return p.BackColor;
            return Taust;
        }

        // Käib läbi kõik vormi elemendid ja annab neile ühtse välimuse
        public static void Rakenda(Control juur)
        {
            foreach (Control c in juur.Controls)
            {
                Stiliseeri(c);
                Rakenda(c);
            }
        }

        private static void Stiliseeri(Control c)
        {
            switch (c)
            {
                case DataGridView g:
                    Tabel(g);
                    break;
                case TextBox t:
                    t.BorderStyle = BorderStyle.FixedSingle;
                    t.ForeColor = Tekst;
                    break;
                case NumericUpDown n:
                    n.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case ComboBox cb:
                    cb.FlatStyle = FlatStyle.Flat;
                    break;
                case CheckBox ch:
                    ch.ForeColor = Tekst;
                    break;
                case Label l when l.ForeColor == SystemColors.ControlText:
                    l.ForeColor = Tekst;
                    break;
            }
        }

        // Tabel: must päis, heledad read, punakas valik
        public static void Tabel(DataGridView g)
        {
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Valge;
            g.GridColor = Aare;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.RowHeadersVisible = false;
            g.AllowUserToResizeRows = false;
            g.EnableHeadersVisualStyles = false;

            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 40;
            g.ColumnHeadersDefaultCellStyle.BackColor = Must;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Valge;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Must;
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Valge;
            g.ColumnHeadersDefaultCellStyle.Font = Paks;
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);

            g.DefaultCellStyle.Font = Tavaline;
            g.DefaultCellStyle.ForeColor = Tekst;
            g.DefaultCellStyle.BackColor = Valge;
            g.DefaultCellStyle.SelectionBackColor = PunaneHele;
            g.DefaultCellStyle.SelectionForeColor = Tekst;
            g.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 250);

            g.RowTemplate.Height = 36;
            foreach (DataGridViewRow r in g.Rows) r.Height = 36;
            g.DataBindingComplete += (_, _) =>
            {
                foreach (DataGridViewRow r in g.Rows) r.Height = 36;
            };
        }
    }

    // Kõigi vormide alus: kujundus ja tõlge rakendatakse automaatselt vormi avamisel
    public class BaasVorm : Form
    {
        public BaasVorm()
        {
            Font = Teema.Tavaline;
            BackColor = Teema.Taust;
        }

        protected override void OnLoad(EventArgs e)
        {
            Teema.Rakenda(this);
            Keel.Tolgi(this);
            base.OnLoad(e);
        }
    }

    public enum NupuStiil { Must, Punane, Hall, Kontuur, Menyy }

    // Ümarate nurkadega nupp
    public class UmarNupp : Button
    {
        private NupuStiil stiil = NupuStiil.Must;
        private int raadius = 8;
        private string ikoon = string.Empty;
        private bool aktiivne;
        private bool hiirPeal, vajutatud;

        public UmarNupp()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Font = Teema.Paks;
            Size = new Size(160, 40);
        }

        [DefaultValue(NupuStiil.Must)]
        public NupuStiil Stiil
        {
            get => stiil;
            set { stiil = value; Invalidate(); }
        }

        [DefaultValue(8)]
        public int Raadius
        {
            get => raadius;
            set { raadius = value; Invalidate(); }
        }

        // Ikoon fondist "Segoe MDL2 Assets" (nt "" = ostukorv)
        [DefaultValue("")]
        public string Ikoon
        {
            get => ikoon;
            set { ikoon = value ?? string.Empty; Invalidate(); }
        }

        // Menüüs praegu avatud leht
        [DefaultValue(false)]
        public bool Aktiivne
        {
            get => aktiivne;
            set { aktiivne = value; Invalidate(); }
        }

        protected override void OnMouseEnter(EventArgs e) { hiirPeal = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { hiirPeal = false; vajutatud = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { vajutatud = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { vajutatud = false; Invalidate(); base.OnMouseUp(e); }
        protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }

        private (Color Taust, Color Tekst, Color Aar) Varvid()
        {
            if (!Enabled)
                return stiil == NupuStiil.Menyy
                    ? (Color.Transparent, Teema.HallTume, Color.Empty)
                    : (Color.FromArgb(214, 214, 218), Color.FromArgb(150, 150, 156), Color.Empty);

            return stiil switch
            {
                NupuStiil.Punane => (vajutatud ? Color.FromArgb(153, 27, 27) : hiirPeal ? Teema.PunaneTume : Teema.Punane, Teema.Valge, Color.Empty),
                NupuStiil.Hall => (vajutatud ? Color.FromArgb(200, 200, 206) : hiirPeal ? Color.FromArgb(216, 216, 222) : Teema.Hall, Teema.Tekst, Color.Empty),
                NupuStiil.Kontuur => (vajutatud ? Teema.Hall : hiirPeal ? Color.FromArgb(246, 246, 248) : Teema.Valge, Teema.Tekst,
                                      hiirPeal ? Teema.Punane : Color.FromArgb(205, 205, 212)),
                NupuStiil.Menyy => (aktiivne ? Teema.Punane : hiirPeal ? Teema.MustHele : Color.Transparent,
                                    aktiivne || hiirPeal ? Teema.Valge : Color.FromArgb(200, 200, 205), Color.Empty),
                _ => (vajutatud ? Color.Black : hiirPeal ? Color.FromArgb(58, 58, 62) : Color.FromArgb(32, 32, 34), Teema.Valge, Color.Empty),
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Teema.VanemaTaust(this));   // nurkade taha vanema taust

            var (taust, tekst, aar) = Varvid();
            var r = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var path = Teema.UmarRuut(r, raadius))
            {
                if (taust != Color.Transparent)
                    using (var b = new SolidBrush(taust)) g.FillPath(b, path);
                if (aar != Color.Empty)
                    using (var p = new Pen(aar)) g.DrawPath(p, path);
            }

            bool mitmeReaga = Height >= Font.Height * 2 + 12;
            var lipud = TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis |
                        (mitmeReaga ? TextFormatFlags.WordBreak : TextFormatFlags.SingleLine);

            if (stiil == NupuStiil.Menyy)
            {
                // menüüs: ikoon vasakul, tekst selle järel
                int x = 14;
                if (ikoon != "")
                {
                    TextRenderer.DrawText(g, ikoon, Teema.Ikoonid, new Rectangle(x, 0, 24, Height), tekst,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine);
                    x += 36;
                }
                TextRenderer.DrawText(g, Text, Font, new Rectangle(x, 0, Width - x - 8, Height), tekst,
                    lipud | TextFormatFlags.Left);
                return;
            }

            if (ikoon == "")
            {
                TextRenderer.DrawText(g, Text, Font, new Rectangle(8, 0, Width - 16, Height), tekst,
                    lipud | TextFormatFlags.HorizontalCenter);
                return;
            }

            // ikoon + tekst keskel
            var tekstiSuurus = TextRenderer.MeasureText(g, Text, Font, Size.Empty, TextFormatFlags.SingleLine);
            int kokku = Math.Min(Width - 16, 24 + tekstiSuurus.Width);
            int algus = (Width - kokku) / 2;
            TextRenderer.DrawText(g, ikoon, Teema.Ikoonid, new Rectangle(algus, 0, 20, Height), tekst,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine);
            TextRenderer.DrawText(g, Text, Font, new Rectangle(algus + 24, 0, Width - algus - 24 - 8, Height), tekst,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
        }
    }

    // Ümarate nurkadega paneel ("kaart"); täidetakse BackColor-iga
    public class UmarPaneel : Panel
    {
        private int raadius = 12;
        private Color aareVarv = Color.FromArgb(222, 222, 228);

        public UmarPaneel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            BackColor = Teema.Valge;
        }

        [DefaultValue(12)]
        public int Raadius
        {
            get => raadius;
            set { raadius = value; Invalidate(); }
        }

        [DefaultValue(typeof(Color), "222, 222, 228")]
        public Color AareVarv
        {
            get => aareVarv;
            set { aareVarv = value; Invalidate(); }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Teema.VanemaTaust(this));

            using var path = Teema.UmarRuut(new Rectangle(0, 0, Width - 1, Height - 1), raadius);
            using (var b = new SolidBrush(BackColor)) g.FillPath(b, path);
            if (aareVarv != Color.Empty && aareVarv.A > 0)
                using (var p = new Pen(aareVarv)) g.DrawPath(p, path);
        }
    }

    // Keele valik: kolm nuppu ET / RU / EN
    public class KeeleValik : FlowLayoutPanel
    {
        private readonly Dictionary<string, UmarNupp> nupud = new();
        private bool tume;

        public KeeleValik()
        {
            WrapContents = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Margin = Padding.Empty;
            Padding = Padding.Empty;

            foreach (var kood in Keel.Keeled)
            {
                var n = new UmarNupp
                {
                    Text = kood.ToUpper(),
                    Size = new Size(48, 32),
                    Margin = new Padding(0, 0, 6, 0),
                    Raadius = 6,
                    Font = Teema.Vaike
                };
                n.Click += (_, _) => Keel.Maara(kood);
                nupud[kood] = n;
                Controls.Add(n);
            }
            Keel.Muutus += Uuenda;
            Uuenda();
        }

        // Tumedal taustal (külgmenüüs) teistsugused värvid
        [DefaultValue(false)]
        public bool Tume
        {
            get => tume;
            set { tume = value; Uuenda(); }
        }

        private void Uuenda()
        {
            foreach (var (kood, n) in nupud)
                n.Stiil = kood == Keel.Praegune ? NupuStiil.Punane : tume ? NupuStiil.Must : NupuStiil.Kontuur;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) Keel.Muutus -= Uuenda;
            base.Dispose(disposing);
        }
    }
}
