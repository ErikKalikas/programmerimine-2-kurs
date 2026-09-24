using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iseseisevtöö_Kolm_rakendust
{
    public class PictureViewerForm : Form
    {
        private PictureBox pictureBox;
        private Button btnBrowse;
        private Button btnRotate;
        private Button btnBgColor;
        private Panel topPanel;

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

            topPanel.Controls.Add(btnBrowse);
            topPanel.Controls.Add(btnRotate);
            topPanel.Controls.Add(btnBgColor);

            pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.LightGray;

            string pilddd = @"..\..\Pildid\pilt.jpg";

            if (System.IO.File.Exists(pilddd))
            {
                pictureBox.Image = Image.FromFile(pilddd);
            }

            this.Controls.Add(pictureBox);
            this.Controls.Add(topPanel);
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Pildid|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Kõik failid|*.*";
                openFileDialog.Title = "Vali pilt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (pictureBox.Image != null)
                    {
                        pictureBox.Image.Dispose();
                    }

                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
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
    }
}