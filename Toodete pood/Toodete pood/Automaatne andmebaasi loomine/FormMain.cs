using System;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            if (AktiivneKasutaja.Roll == "admin")
            {
                Text = "Peamenüü – administraator";
            }
            else
            {
                // Ostja näeb ainult poodi ja ostukorvi, midagi muuta ei saa
                Text = "Pood – ostja";
                btnTooted.Visible = false;
                btnKategooriad.Visible = false;

                btnPood.Location = new Point(30, 30);
                btnArve.Location = new Point(30, 80);
                btnArve.Text = "Ostukorv";
                btnLogiValja.Location = new Point(30, 140);
                ClientSize = new Size(300, 200);
            }
        }

        private void btnLogiValja_Click(object? sender, EventArgs e)
        {
            AktiivneKasutaja.Roll = "";   // LoginForm näeb seda ja avab end uuesti
            Ostukorv.Ridad.Clear();
            Close();
        }

        private void btnTooted_Click(object? sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void btnPood_Click(object? sender, EventArgs e)
        {
            Form3 poodForm = new Form3();
            poodForm.ShowDialog();
        }

        private void btnArve_Click(object? sender, EventArgs e)
        {
            ArveForm arve = new ArveForm();
            arve.ShowDialog();
        }

        private void btnKategooriad_Click(object? sender, EventArgs e)
        {
            KategooriadForm f = new KategooriadForm();
            f.ShowDialog();
        }
    }
}
