using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    // Pood: tooted kategooriate kaupa, otsing, sorteerimine, soodushinnad ja tootekaart
    public partial class Form3 : Form
    {
        private List<Toode> tooted = new();
        private List<Kategooria> kategooriad = new();
        private HashSet<int> lemmikud = new();

        private static readonly string[] Sorteerimised =
        {
            "Nimi A–Z", "Nimi Z–A", "Hind kasvavalt", "Hind kahanevalt", "Soodustused enne", "Uuemad enne"
        };

        public Form3()
        {
            InitializeComponent();

            cmbSorteeri.Items.AddRange(Sorteerimised);
            cmbSorteeri.SelectedIndex = 0;   // käivitab ka NaitaTooted

            LaeAndmed();
            NaitaTooted();
            NaitaKokku();
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
            string valitudTab = tabPood.SelectedTab?.Text ?? "";
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

            tabPood.SuspendLayout();
            tabPood.TabPages.Clear();

            LisaTab("Kõik tooted", nimekiri);
            foreach (var kat in kategooriad)
            {
                var katTooted = nimekiri.Where(t => t.KategooriaId == kat.Id).ToList();
                if (otsing != "" && katTooted.Count == 0) continue;   // otsingul peidame tühjad kategooriad
                LisaTab(kat.Kategooria_nimetus, katTooted);
            }

            // jääme samale vahelehele, kui see on alles
            string valitudNimi = valitudTab.Split(" (")[0];
            foreach (TabPage p in tabPood.TabPages)
                if (p.Text.Split(" (")[0] == valitudNimi)
                    tabPood.SelectedTab = p;

            tabPood.ResumeLayout();
        }

        private void LisaTab(string nimi, List<Toode> tabiTooted)
        {
            var page = new TabPage($"{nimi} ({tabiTooted.Count})");
            page.AutoScroll = true;
            page.BackColor = Color.LightBlue;

            if (tabiTooted.Count == 0)
            {
                page.Controls.Add(new Label { Text = "Tooteid ei leitud.", AutoSize = true, Location = new Point(15, 15) });
            }

            int x = 10, y = 10, count = 0;
            foreach (var t in tabiTooted)
            {
                var kaart = LooKaart(t);
                kaart.Location = new Point(x, y);
                page.Controls.Add(kaart);

                x += 172;
                count++;
                if (count % 5 == 0)   // 5 toodet reas
                {
                    x = 10;
                    y += 232;
                }
            }

            tabPood.TabPages.Add(page);
        }

        // Ühe toote kaart: pilt, nimi, hind (soodushind läbikriipsutatud vana hinnaga), "Otsas"
        private Panel LooKaart(Toode t)
        {
            bool otsas = t.Kogus <= 0;

            var p = new Panel
            {
                Size = new Size(162, 222),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            var pb = new PictureBox
            {
                Size = new Size(150, 140),
                Location = new Point(5, 5),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Pildid.Lae(t.Pilt),
                Cursor = Cursors.Hand
            };

            var lblNimi = new Label
            {
                Text = (lemmikud.Contains(t.Id) ? "♥ " : "") + t.Toodenimetus,
                Location = new Point(5, 148),
                Size = new Size(150, 34),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            var lblHind = new Label
            {
                Text = $"{t.HetkeHind:0.00} €",
                Location = new Point(5, 182),
                Size = new Size(150, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = t.OnSoodus ? Color.Firebrick : Color.Black
            };
            p.Controls.Add(pb);
            p.Controls.Add(lblNimi);
            p.Controls.Add(lblHind);

            if (t.OnSoodus)
            {
                p.Controls.Add(new Label
                {
                    Text = $"{t.Hind:0.00} €",
                    Location = new Point(5, 201),
                    Size = new Size(150, 16),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 8F, FontStyle.Strikeout),
                    ForeColor = Color.DimGray
                });

                var mark = new Label
                {
                    Text = $"−{t.SoodusProtsent}%",
                    Location = new Point(5, 5),
                    AutoSize = true,
                    BackColor = Color.Firebrick,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Padding = new Padding(3, 1, 3, 1)
                };
                p.Controls.Add(mark);
                mark.BringToFront();
            }

            if (otsas)
            {
                var lblOtsas = new Label
                {
                    Text = "OTSAS",
                    Location = new Point(40, 62),
                    AutoSize = true,
                    BackColor = Color.DimGray,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Padding = new Padding(6, 2, 6, 2)
                };
                p.Controls.Add(lblOtsas);
                lblOtsas.BringToFront();
                lblHind.ForeColor = Color.DimGray;
            }

            // Klõps kaardil avab tootekaardi
            void Ava(object? s, EventArgs e) => AvaToode(t);
            p.Click += Ava;
            foreach (Control c in p.Controls)
                c.Click += Ava;

            return p;
        }

        private void AvaToode(Toode t)
        {
            using var kaart = new TooteKaartForm(t);
            kaart.ShowDialog(this);

            // lemmik võis muutuda ja korv täieneda
            var uuedLemmikud = LemmikTooted.Koik();
            if (!uuedLemmikud.SetEquals(lemmikud))
            {
                lemmikud = uuedLemmikud;
                NaitaTooted();
            }
            NaitaKokku();
        }

        private void NaitaKokku()
        {
            btnOstukorv.Text = $"🛒 Ostukorv ({Ostukorv.TooteidKokku} tk, {Ostukorv.Kokku:0.00} €)";
        }

        private void txtOtsi_TextChanged(object? sender, EventArgs e) => NaitaTooted();

        private void cmbSorteeri_SelectedIndexChanged(object? sender, EventArgs e) => NaitaTooted();

        private void btnOstukorv_Click(object? sender, EventArgs e)
        {
            ArveForm arve = new ArveForm();
            arve.ShowDialog();

            // pärast ostu on laoseis muutunud
            LaeAndmed();
            NaitaTooted();
            NaitaKokku();
        }
    }
}
