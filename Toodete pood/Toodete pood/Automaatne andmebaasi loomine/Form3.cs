using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    public partial class Form3 : Form
    {
        private readonly ToodedContext _db;

        public Form3()
        {
            InitializeComponent();
            _db = new ToodedContext();
            LaeKategooriadJaPildid();
            NaitaKokku();
        }

        private void LaeKategooriadJaPildid()
        {
            tabPood.TabPages.Clear();

            var kategooriad = _db.Kategooriatabel.ToList();

            foreach (var kat in kategooriad)
            {
                // Loo uus tab selle kategooria jaoks
                var page = new TabPage(kat.Kategooria_nimetus);
                page.AutoScroll = true;
                page.BackColor = Color.LightBlue;

                // Too kategooria tooted andmebaasist
                var tooted = _db.Toodetabel
                                .AsNoTracking()   // alati värske laoseis andmebaasist
                                .Where(t => t.KategooriaId == kat.Id)
                                .ToList();

                int x = 10;
                int y = 10;
                int count = 0;

                foreach (var t in tooted)
                {
                    // Loo paneel iga toote jaoks
                    Panel p = new Panel();
                    p.Width = 150;
                    p.Height = 200;
                    p.BorderStyle = BorderStyle.FixedSingle;

                    // Pildikast
                    PictureBox pb = new PictureBox();
                    pb.Width = 140;
                    pb.Height = 140;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Location = new Point(5, 5);

                    // lae pilt failist, kui olemas
                    var piltPath = Path.Combine("Images", t.Pilt ?? "puudub.png");
                    if (File.Exists(piltPath))
                        pb.Image = Image.FromFile(piltPath);

                    // Pildile klikk lisab toote ostukorvi
                    pb.Cursor = Cursors.Hand;
                    pb.Click += (s, e) => LisaKorvi(t);

                    // Nimetus
                    Label lbl = new Label();
                    lbl.Text = $"{t.Toodenimetus}\n{t.Hind:0.00} €";
                    lbl.AutoSize = false;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Location = new Point(5, 150);
                    lbl.Size = new Size(140, 40);

                    // Lisa elemendid paneelile
                    p.Controls.Add(pb);
                    p.Controls.Add(lbl);

                    // Paiguta paneel TabPage-s
                    p.Location = new Point(x, y);
                    page.Controls.Add(p);

                    // Järgmise positsioon
                    x += 160;
                    count++;

                    // iga 4 pildi järel uus rida
                    if (count % 4 == 0)
                    {
                        x = 10;
                        y += 210;
                    }
                }

                // Lisa TabPage TabControli sisse
                tabPood.TabPages.Add(page);
            }
        }

        private void LisaKorvi(Toode t)
        {
            string kogusStr = Microsoft.VisualBasic.Interaction.InputBox(
                $"{t.Toodenimetus} – {t.Hind:0.00} €\nLaos: {t.Kogus} tk\n\nMitu tükki?", "Lisa korvi", "1");

            if (string.IsNullOrEmpty(kogusStr)) return;   // vajutati Cancel

            if (!int.TryParse(kogusStr, out int kogus) || kogus <= 0)
            {
                MessageBox.Show("Vale kogus.");
                return;
            }

            string? viga = Ostukorv.Lisa(t, kogus);
            MessageBox.Show(viga ?? $"{t.Toodenimetus} ({kogus} tk) lisati korvi.");
            NaitaKokku();
        }

        private void NaitaKokku()
        {
            btnOstukorv.Text = $"Ostukorv ({Ostukorv.Ridad.Sum(r => r.Kogus)} tk, {Ostukorv.Kokku:0.00} €)";
        }

        private void btnOstukorv_Click(object? sender, EventArgs e)
        {
            ArveForm arve = new ArveForm();
            arve.ShowDialog();

            // pärast ostu on laoseis muutunud
            LaeKategooriadJaPildid();
            NaitaKokku();
        }
    }
}
