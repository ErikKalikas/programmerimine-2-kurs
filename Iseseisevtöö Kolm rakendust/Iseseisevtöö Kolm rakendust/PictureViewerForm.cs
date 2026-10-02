using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Iseseisevtöö_Kolm_rakendust
{
    public class PictureViewerForm : Form
    {
        private PictureBox pictureBox;
        private Button btnBrowse;
        private Button btnRotate;
        private Button btnBgColor;
        private Button btnStretch;
        private Button btnSlideshow;
        private Panel topPanel;

        // Slaidiseanss
        private Timer slideTimer;
        private List<string> slideFiles = new List<string>();
        private int slideIndex = 0;

        public PictureViewerForm()
        {
            this.Size = new Size(800, 600);
            this.Text = "Pildivaatja";

            topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 40;

            btnBrowse = new Button();
            btnBrowse.Text = "Vali pilt";
            btnBrowse.Location = new Point(10, 8);
            btnBrowse.Size = new Size(100, 25);
            btnBrowse.Click += BtnBrowse_Click;

            btnRotate = new Button();
            btnRotate.Text = "Pööra";
            btnRotate.Location = new Point(120, 8);
            btnRotate.Size = new Size(100, 25);
            btnRotate.Click += BtnRotate_Click;

            btnBgColor = new Button();
            btnBgColor.Text = "Taustavärv";
            btnBgColor.Location = new Point(230, 8);
            btnBgColor.Size = new Size(100, 25);
            btnBgColor.Click += BtnBgColor_Click;

            // Nupp "Venita"
            btnStretch = new Button();
            btnStretch.Text = "Venita";
            btnStretch.Location = new Point(340, 8);
            btnStretch.Size = new Size(100, 25);
            btnStretch.Click += BtnStretch_Click;

            // Nupp "Slaidiseanss"
            btnSlideshow = new Button();
            btnSlideshow.Text = "Slaidiseanss";
            btnSlideshow.Location = new Point(450, 8);
            btnSlideshow.Size = new Size(100, 25);
            btnSlideshow.Click += BtnSlideshow_Click;

            topPanel.Controls.Add(btnBrowse);
            topPanel.Controls.Add(btnRotate);
            topPanel.Controls.Add(btnBgColor);
            topPanel.Controls.Add(btnStretch);
            topPanel.Controls.Add(btnSlideshow);

            pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.LightGray;

            string pilddd = @"..\..\Pildid\pilt.jpg";

            if (File.Exists(pilddd))
            {
                pictureBox.Image = Image.FromFile(pilddd);
            }

            // Slaidiseansi taimer: pilt vahetub iga 2 sekundi järel
            slideTimer = new Timer();
            slideTimer.Interval = 2000;
            slideTimer.Tick += SlideTimer_Tick;

            this.Controls.Add(pictureBox);
            this.Controls.Add(topPanel);
        }

        // Laadib pildi ja vabastab eelmise
        private void LoadImage(string path)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
            }
            pictureBox.Image = Image.FromFile(path);
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Pildid|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Kõik failid|*.*";
                openFileDialog.Title = "Vali pilt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadImage(openFileDialog.FileName);
                }
            }
        }

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox.Refresh();
            }
        }

        private void BtnBgColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.BackColor = colorDialog.Color;
                }
            }
        }

        // Vahetab: venita üle terve akna <-> mahuta proportsioone säilitades
        private void BtnStretch_Click(object sender, EventArgs e)
        {
            if (pictureBox.SizeMode == PictureBoxSizeMode.Zoom)
            {
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                btnStretch.Text = "Mahuta";
            }
            else
            {
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                btnStretch.Text = "Venita";
            }
        }

        // Slaidiseansi käivitamine / peatamine
        private void BtnSlideshow_Click(object sender, EventArgs e)
        {
            if (slideTimer.Enabled)
            {
                slideTimer.Stop();
                btnSlideshow.Text = "Slaidiseanss";
                return;
            }

            // Kaust Pildid projektis: bin\Debug kaustast kaks taset üles
            string folder = Path.GetFullPath(@"..\..\Pildid");

            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Kausta ei leitud: " + folder);
                return;
            }

            string[] extensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };

            slideFiles = Directory.GetFiles(folder)
                .Where(f => extensions.Contains(Path.GetExtension(f).ToLower()))
                .ToList();

            if (slideFiles.Count == 0)
            {
                MessageBox.Show("Kaustas pole pilte.");
                return;
            }

            slideIndex = 0;
            LoadImage(slideFiles[slideIndex]);
            slideTimer.Start();
            btnSlideshow.Text = "Peata";
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            slideIndex = (slideIndex + 1) % slideFiles.Count; // ringiga
            LoadImage(slideFiles[slideIndex]);
        }
    }
}