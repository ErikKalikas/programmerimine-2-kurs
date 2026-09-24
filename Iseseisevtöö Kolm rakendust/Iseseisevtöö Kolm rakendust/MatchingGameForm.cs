using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Iseseisevtöö_Kolm_rakendust
{
    // Sarnaste piltide leidmise mäng (Matching Game)
    // Kõik elemendid on loodud koodiga, Toolbox'i ei kasutata.
    // Sümbolite asemel kasutatakse päris pilte kaustast Pildid.
    //
    // Projekti edasiarendus:
    // 1. Lisa taimer ja punktisüsteem.
    // 2. Lisa raskusastme valik (näiteks 4x4, 6x6 ruudustik).
    // 3. Lisa nupp "Uus mäng", mis segab pildid uuesti.
    public class MatchingGameForm : Form
    {
        TableLayoutPanel tableLayoutPanel1;
        Timer timer1;

        // Juhuslike numbrite generaator piltide valimiseks
        Random random = new Random();

        // Piltide nimekiri.
        // Iga pilt on nimekirjas kaks korda (paar).
        List<Image> icons = new List<Image>();

        // firstClicked näitab esimest vajutatud silti,
        // secondClicked näitab teist vajutatud silti
        Label firstClicked = null;
        Label secondClicked = null;

        public MatchingGameForm()
        {
            Text = "Matching Game";
            Size = new Size(550, 550);

            // Loeme 8 pilti kaustast Pildid (mang1.png ... mang8.png)
            for (int i = 1; i <= 8; i++)
            {
                Image originaal = Image.FromFile(@"..\..\Pildid\mang" + i + ".png");

                // Teeme pildi väiksemaks, et see mahuks ruutu
                Image vaike = new Bitmap(originaal, new Size(100, 100));
                originaal.Dispose();

                // Lisame sama pildi kaks korda
                icons.Add(vaike);
                icons.Add(vaike);
            }

            // Tabel 4 x 4
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.BackColor = Color.CornflowerBlue;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.RowCount = 4;

            // Kõik veerud ja read on 25% suurused
            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            }

            // Lisame igasse lahtrisse ühe sildi
            for (int rida = 0; rida < 4; rida++)
            {
                for (int veerg = 0; veerg < 4; veerg++)
                {
                    Label label = new Label();
                    label.BackColor = Color.CornflowerBlue;
                    label.AutoSize = false;
                    label.Dock = DockStyle.Fill;
                    label.ImageAlign = ContentAlignment.MiddleCenter;
                    label.Click += label_Click;

                    tableLayoutPanel1.Controls.Add(label, veerg, rida);
                }
            }

            Controls.Add(tableLayoutPanel1);

            // Taimer peidab valed pildid 0,75 sekundi pärast
            timer1 = new Timer();
            timer1.Interval = 750;
            timer1.Tick += timer1_Tick;

            AssignIconsToSquares();
        }

        /// <summary>
        /// Paneb iga pildi juhuslikku ruutu
        /// </summary>
        private void AssignIconsToSquares()
        {
            // TableLayoutPanel'is on 16 silti
            // ja piltide nimekirjas on 16 pilti,
            // nii et iga silt saab ühe juhusliku pildi
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);

                    // Pilt jäetakse Tag'i sisse peitu.
                    // Image on tühi, seega pilti ei ole näha.
                    iconLabel.Tag = icons[randomNumber];
                    iconLabel.Image = null;

                    icons.RemoveAt(randomNumber);
                }
            }
        }

        /// <summary>
        /// Iga sildi Click sündmus
        /// </summary>
        private void label_Click(object sender, EventArgs e)
        {
            // Kui taimer töötab, siis kaks valet pilti on veel näha,
            // seega ei tee midagi
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // Kui pilt on juba näha (avatud), siis ei tee midagi
                if (clickedLabel.Image != null)
                    return;

                // Kui firstClicked on null, siis see on esimene vajutus
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.Image = (Image)firstClicked.Tag;
                    return;
                }

                // Kui jõudsime siia, siis see on teine vajutus
                secondClicked = clickedLabel;
                secondClicked.Image = (Image)secondClicked.Tag;

                // Kontrollime, kas mängija võitis
                CheckForWinner();

                // Kui pildid on samad, jäävad need nähtavaks
                if (firstClicked.Tag == secondClicked.Tag)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                // Kui pildid on erinevad, käivitame taimeri,
                // mis peidab need natukese aja pärast
                timer1.Start();
            }
        }

        /// <summary>
        /// Taimer käivitub, kui mängija vajutas kahte erinevat pilti.
        /// Peidab mõlemad pildid.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Peatame taimeri
            timer1.Stop();

            // Peidame mõlemad pildid
            firstClicked.Image = null;
            secondClicked.Image = null;

            // Järgmine vajutus on jälle esimene
            firstClicked = null;
            secondClicked = null;
        }

        /// <summary>
        /// Kontrollib, kas kõik pildid on leitud.
        /// Kui jah, siis mängija võitis.
        /// </summary>
        private void CheckForWinner()
        {
            // Kui mõni pilt on veel peidetud (Image on tühi),
            // siis mäng ei ole veel läbi
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.Image == null)
                        return;
                }
            }

            // Kõik pildid on leitud
            MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();
        }
    }
}
