using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    // Pood: tootekaardid nagu internetipoes, kategooriad, otsing, sorteerimine, soodushinnad ja "Lisa korvi"
    public partial class Form3 : BaasVorm
    {
        private List<Toode> tooted = new();
        private List<Kategooria> kategooriad = new();
        private HashSet<int> lemmikud = new();
        private int? valitudKategooria;   // null = kõik tooted
        private bool laeb = true;

        private static readonly string[] Sorteerimised =
        {
            "Nimi A–Z", "Nimi Z–A", "Hind kasvavalt", "Hind kahanevalt", "Soodustused enne", "Uuemad enne"
        };

        public Form3()
        {
            InitializeComponent();

            foreach (var s in Sorteerimised)
                cmbSorteeri.Items.Add(Keel.T(s));
            cmbSorteeri.SelectedIndex = 0;

            LaeAndmed();
            laeb = false;
            NaitaTooted();
        }

        // Värsked andmed andmebaasist (laoseis muutub pärast ostu)
        private void LaeAndmed()
        {
            using var db = new ToodedContext();
            tooted = db.Toodetabel.AsNoTracking().ToList();
            kategooriad = db.Kategooriatabel.AsNoTracking().OrderBy(k => k.Id).ToList();
            lemmikud = LemmikTooted.Koik();
        }

        private void NaitaTooted()
        {
            if (laeb) return;
            string otsing = txtOtsi.Text.Trim();

            IEnumerable<Toode> leitud = tooted;
            if (otsing != "")
                leitud = leitud.Where(t => t.Toodenimetus.Contains(otsing, StringComparison.CurrentCultureIgnoreCase));

            leitud = cmbSorteeri.SelectedIndex switch
            {
                1 => leitud.OrderByDescending(t => t.Toodenimetus),
                2 => leitud.OrderBy(t => t.HetkeHind),
                3 => leitud.OrderByDescending(t => t.HetkeHind),
                4 => leitud.OrderByDescending(t => t.SoodusProtsent).ThenBy(t => t.Toodenimetus),
                5 => leitud.OrderByDescending(t => t.Id),
                _ => leitud.OrderBy(t => t.Toodenimetus),
            };
            var nimekiri = leitud.ToList();

            NaitaKategooriad(nimekiri, otsing != "");

            var naita = valitudKategooria == null
                ? nimekiri
                : nimekiri.Where(t => t.KategooriaId == valitudKategooria).ToList();
            lblLeitud.Text = Keel.T("Leitud {0} toodet", naita.Count);

            flpTooted.SuspendLayout();
            foreach (var vana in flpTooted.Controls.Cast<Control>().ToList())
                vana.Dispose();

            if (naita.Count == 0)
            {
                flpTooted.Controls.Add(new Label
                {
                    Text = Keel.T("Tooteid ei leitud."),
                    AutoSize = true,
                    Font = Teema.Alapealkiri,
                    ForeColor = Teema.HallTume,
                    Margin = new Padding(4, 20, 0, 0)
                });
            }

            foreach (var t in naita)
                flpTooted.Controls.Add(LooKaart(t));

            flpTooted.ResumeLayout();
            flpTooted.AutoScrollPosition = Point.Empty;
        }

        // Kategooriad "kiipidena" toodete kohal; valitud kategooria on punane
        private void NaitaKategooriad(List<Toode> nimekiri, bool otsingul)
        {
            flpKategooriad.SuspendLayout();
            foreach (var vana in flpKategooriad.Controls.Cast<Control>().ToList())
                vana.Dispose();

            LisaKiip(Keel.T("Kõik tooted"), nimekiri.Count, null);
            foreach (var kat in kategooriad)
            {
                int arv = nimekiri.Count(t => t.KategooriaId == kat.Id);
                if (otsingul && arv == 0 && valitudKategooria != kat.Id) continue;   // otsingul peidame tühjad
                LisaKiip(kat.Kategooria_nimetus, arv, kat.Id);
            }
            flpKategooriad.ResumeLayout();
        }

        private void LisaKiip(string nimi, int arv, int? katId)
        {
            string tekst = $"{nimi}  {arv}";
            var kiip = new UmarNupp
            {
                Text = tekst,
                Stiil = valitudKategooria == katId ? NupuStiil.Punane : NupuStiil.Kontuur,
                Raadius = 18,
                Height = 36,
                Width = TextRenderer.MeasureText(tekst, Teema.Paks).Width + 36,
                Margin = new Padding(0, 0, 8, 8)
            };
            kiip.Click += (_, _) => BeginInvoke(() =>
            {
                valitudKategooria = katId;
                NaitaTooted();
            });
            flpKategooriad.Controls.Add(kiip);
        }

        // Ühe toote kaart: pilt, nimi, hind (soodushinnaga ka vana hind), "Lisa korvi"
        private UmarPaneel LooKaart(Toode t)
        {
            bool otsas = t.Kogus <= 0;

            var kaart = new UmarPaneel
            {
                Size = new Size(216, 340),
                Margin = new Padding(0, 0, 18, 18),
                Cursor = Cursors.Hand
            };

            var pb = new PictureBox
            {
                Size = new Size(192, 160),
                Location = new Point(12, 12),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Pildid.Lae(t.Pilt),
                BackColor = Teema.Valge
            };

            var lblNimi = new Label
            {
                Text = t.Toodenimetus,
                Location = new Point(12, 182),
                Size = new Size(192, 44),
                Font = Teema.KaardiNimi,
                ForeColor = Teema.Tekst,
                AutoEllipsis = true
            };

            var lblHind = new Label
            {
                Text = $"{t.HetkeHind:0.00} €",
                Location = new Point(10, 228),
                Size = new Size(110, 30),
                Font = Teema.KaardiHind,
                ForeColor = t.OnSoodus ? Teema.Punane : Teema.Tekst
            };

            var btnLisa = new UmarNupp
            {
                Text = otsas ? Keel.T("Otsas") : Keel.T("Lisa korvi"),
                Ikoon = otsas ? "" : "",
                Stiil = NupuStiil.Punane,
                Location = new Point(12, 286),
                Size = new Size(192, 40),
                Enabled = !otsas
            };
            btnLisa.Click += (_, _) => LisaKorvi(t, btnLisa);

            kaart.Controls.Add(pb);
            kaart.Controls.Add(lblNimi);
            kaart.Controls.Add(lblHind);
            kaart.Controls.Add(btnLisa);

            if (t.OnSoodus)
            {
                kaart.Controls.Add(new Label
                {
                    Text = $"{t.Hind:0.00} €",
                    Location = new Point(12, 258),
                    Size = new Size(110, 20),
                    Font = Teema.VanaHind,
                    ForeColor = Teema.HallTume
                });

                var mark = new Label
                {
                    Text = $"−{t.SoodusProtsent}%",
                    Location = new Point(12, 12),
                    AutoSize = true,
                    BackColor = Teema.Punane,
                    ForeColor = Teema.Valge,
                    Font = Teema.Mark,
                    Padding = new Padding(6, 3, 6, 3)
                };
                kaart.Controls.Add(mark);
                mark.BringToFront();
            }

            if (lemmikud.Contains(t.Id))
            {
                var syda = new Label
                {
                    Text = "",   // täidetud süda
                    Font = Teema.Ikoonid,
                    ForeColor = Teema.Punane,
                    BackColor = Teema.Valge,
                    Location = new Point(176, 14),
                    Size = new Size(24, 24),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                kaart.Controls.Add(syda);
                syda.BringToFront();
            }

            if (otsas)
            {
                var lblOtsas = new Label
                {
                    Text = Keel.T("OTSAS"),
                    AutoSize = true,
                    BackColor = Teema.Must,
                    ForeColor = Teema.Valge,
                    Font = Teema.Alapealkiri,
                    Padding = new Padding(10, 4, 10, 4),
                    Location = new Point(60, 74)
                };
                kaart.Controls.Add(lblOtsas);
                lblOtsas.BringToFront();
                lblHind.ForeColor = Teema.HallTume;
            }

            // Klõps kaardil (v.a nupp) avab tootekaardi; hiire all olev kaart saab punase ääre
            void Ava(object? s, EventArgs e) => BeginInvoke(() => AvaToode(t));
            void Sisse(object? s, EventArgs e) => kaart.AareVarv = Teema.Punane;
            void Valja(object? s, EventArgs e)
            {
                if (!kaart.IsDisposed && !kaart.ClientRectangle.Contains(kaart.PointToClient(Cursor.Position)))
                    kaart.AareVarv = Teema.Aare;
            }

            kaart.Click += Ava;
            kaart.MouseEnter += Sisse;
            kaart.MouseLeave += Valja;
            foreach (Control c in kaart.Controls)
            {
                c.MouseEnter += Sisse;
                c.MouseLeave += Valja;
                if (c != btnLisa)
                {
                    c.Click += Ava;
                    c.Cursor = Cursors.Hand;
                }
            }

            return kaart;
        }

        private void LisaKorvi(Toode t, UmarNupp nupp)
        {
            string? viga = Ostukorv.Lisa(t, 1);
            if (viga != null)
            {
                MessageBox.Show(viga);
                return;
            }

            // lühike kinnitus nupul
            nupp.Text = Keel.T("Lisatud ✓");
            nupp.Stiil = NupuStiil.Must;
            var taimer = new System.Windows.Forms.Timer { Interval = 1200 };
            taimer.Tick += (_, _) =>
            {
                taimer.Dispose();
                if (nupp.IsDisposed) return;
                nupp.Text = Keel.T("Lisa korvi");
                nupp.Stiil = NupuStiil.Punane;
            };
            taimer.Start();
        }

        private void AvaToode(Toode t)
        {
            using var kaart = new TooteKaartForm(t);
            kaart.ShowDialog(TopLevelControl ?? this);

            // lemmik võis muutuda
            var uuedLemmikud = LemmikTooted.Koik();
            if (!uuedLemmikud.SetEquals(lemmikud))
            {
                lemmikud = uuedLemmikud;
                NaitaTooted();
            }
        }

        private void txtOtsi_TextChanged(object? sender, EventArgs e) => NaitaTooted();

        private void cmbSorteeri_SelectedIndexChanged(object? sender, EventArgs e) => NaitaTooted();
    }
}
