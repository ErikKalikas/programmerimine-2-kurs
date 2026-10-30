using System;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Button[] nupud;
            if (AktiivneKasutaja.Roll == "admin")
            {
                Text = "Peamenüü – administraator";
                lblTere.Text = $"Administraator: {AktiivneKasutaja.Nimi}";
                nupud = new[] { btnTooted, btnKategooriad, btnKoikTellimused, btnAruanded, btnKasutajad, btnLogi, btnPood, btnArve, btnProfiil, btnLogiValja };
            }
            else if (AktiivneKasutaja.OnKonto)
            {
                // Kontoga ostja: pood, korv, tellimused, lemmikud ja profiil
                Text = "Pood";
                lblTere.Text = $"Tere, {AktiivneKasutaja.Nimi}!";
                nupud = new[] { btnPood, btnArve, btnTellimused, btnLemmikud, btnProfiil, btnLogiValja };
            }
            else
            {
                // Külaline näeb ainult poodi ja ostukorvi, midagi muuta ei saa
                Text = "Pood";
                lblTere.Text = "Tere, külaline!";
                btnLogiValja.Text = "Tagasi algusesse";
                nupud = new[] { btnPood, btnArve, btnLogiValja };
            }

            // Nupud üksteise alla; teised peidetakse
            foreach (Control c in Controls)
                if (c is Button) c.Visible = false;

            int y = 50;
            foreach (var nupp in nupud)
            {
                if (nupp == btnLogiValja) y += 10;   // väike vahe enne väljalogimist
                nupp.Location = new Point(30, y);
                nupp.Visible = true;
                y += 46;
            }
            ClientSize = new Size(280, y + 10);
        }

        private void btnLogiValja_Click(object? sender, EventArgs e)
        {
            AktiivneKasutaja.LogiValja();   // LoginForm näeb tühja rolli ja avab end uuesti
            Ostukorv.Unusta();              // korv jääb faili alles järgmiseks korraks
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

        private void btnTellimused_Click(object? sender, EventArgs e)
        {
            using var f = new TellimusedForm();
            f.ShowDialog();
        }

        private void btnLemmikud_Click(object? sender, EventArgs e)
        {
            using var f = new LemmikudForm();
            f.ShowDialog();
        }

        private void btnKoikTellimused_Click(object? sender, EventArgs e)
        {
            using var f = new KoikTellimusedForm();
            f.ShowDialog();
        }

        private void btnAruanded_Click(object? sender, EventArgs e)
        {
            using var f = new AruandedForm();
            f.ShowDialog();
        }

        private void btnKasutajad_Click(object? sender, EventArgs e)
        {
            using var f = new KasutajadForm();
            f.ShowDialog();
        }

        private void btnLogi_Click(object? sender, EventArgs e)
        {
            using var f = new LogiForm();
            f.ShowDialog();
        }

        private void btnProfiil_Click(object? sender, EventArgs e)
        {
            using var f = new ProfiilForm();
            f.ShowDialog();
            lblTere.Text = AktiivneKasutaja.Roll == "admin"
                ? $"Administraator: {AktiivneKasutaja.Nimi}"
                : $"Tere, {AktiivneKasutaja.Nimi}!";
        }
    }
}
