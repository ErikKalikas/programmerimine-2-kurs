using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    public partial class LoginForm : BaasVorm
    {
        public LoginForm()
        {
            InitializeComponent();
            AcceptButton = btnOstja;

            UuendaTekstid();
            Keel.Muutus += UuendaTekstid;
            FormClosed += (_, _) => Keel.Muutus -= UuendaTekstid;
            Load += (_, _) => pnlParem_Resize(null, EventArgs.Empty);
        }

        // Kõik tekstid valitud keeles (kutsutakse ka keele vahetamisel)
        private void UuendaTekstid()
        {
            var pood = PoeSeaded.Lae();
            lblBrand.Text = pood.PoeNimi;
            lblBrandAlam.Text = Keel.T(pood.Hyydlause);

            Text = Keel.T("Tere tulemast");
            lblAlam.Text = Keel.T("Vali, kuidas soovid jätkata");
            btnOstja.Text = Keel.T("Sisene poodi");
            btnKlient.Text = Keel.T("Logi sisse");
            btnRegistreeru.Text = Keel.T("Registreeru");
            btnAdmin.Text = Keel.T("Logi sisse administraatorina");
            txtEmail.PlaceholderText = Keel.T("E-post");
            txtParool.PlaceholderText = Keel.T("Parool");
            btnLogin.Text = Keel.T("Logi sisse");
            btnTagasi.Text = Keel.T("Tagasi");
            NaitaPealkiri();
            lblVeateade.Text = "";
        }

        private void NaitaPealkiri()
        {
            lblPealkiri.Text = reziim == "admin" ? Keel.T("Administraator")
                             : reziim == "klient" ? Keel.T("Sisselogimine")
                             : Keel.T("Tere tulemast!");
            lblAlam.Text = reziim == "" ? Keel.T("Vali, kuidas soovid jätkata") : Keel.T("Sisesta oma e-post ja parool");
        }

        // Kaart on alati akna paremal poolel keskel
        private void pnlParem_Resize(object? sender, EventArgs e)
        {
            pnlKaart.Left = Math.Max(20, (pnlParem.ClientSize.Width - pnlKaart.Width) / 2);
            pnlKaart.Top = Math.Max(70, (pnlParem.ClientSize.Height - pnlKaart.Height) / 2);
            keeleValik.Location = new Point(pnlParem.ClientSize.Width - keeleValik.Width - 24, 20);
        }

        // "" = algvaade, "klient" = ostja konto, "admin" = administraator
        private string reziim = "";

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            using var db = new ToodedContext();

            string email = txtEmail.Text.Trim().ToLower();
            string parool = txtParool.Text;

            var kasutaja = db.Kasutajad.FirstOrDefault(k => k.Email.ToLower() == email);

            if (kasutaja == null || !PasswordHelper.Verify(parool, kasutaja.ParoolHash))
            {
                lblVeateade.Text = Keel.T("Vale e-post või parool!");
                txtParool.Clear();
                return;
            }

            if (kasutaja.Blokeeritud)
            {
                lblVeateade.Text = Keel.T("See konto on blokeeritud.");
                return;
            }

            if (reziim == "admin" && kasutaja.Roll != "admin")
            {
                lblVeateade.Text = Keel.T("See konto ei ole administraator!");
                return;
            }

            if (reziim == "klient" && kasutaja.Roll == "admin")
            {
                lblVeateade.Text = Keel.T("Administraator logib sisse eraldi nupuga.");
                return;
            }

            AktiivneKasutaja.LogiSisse(kasutaja);
            if (kasutaja.Roll == "admin") Tegevuslogi.Kirjuta("Logis sisse administraatorina");
            AvaPeamenyy();
        }

        // Külaline: parooli pole vaja, saab poes osta
        private void btnOstja_Click(object? sender, EventArgs e)
        {
            AktiivneKasutaja.Kulaline();
            AvaPeamenyy();
        }

        private void btnKlient_Click(object? sender, EventArgs e) => NaitaVaade("klient");

        private void btnAdmin_Click(object? sender, EventArgs e) => NaitaVaade("admin");

        private void btnTagasi_Click(object? sender, EventArgs e) => NaitaVaade("");

        private void btnRegistreeru_Click(object? sender, EventArgs e)
        {
            using var f = new RegistreerimineForm();
            if (f.ShowDialog(this) == DialogResult.OK && f.UusKasutaja != null)
            {
                // pärast registreerimist ollakse kohe sisse logitud
                AktiivneKasutaja.LogiSisse(f.UusKasutaja);
                AvaPeamenyy();
            }
        }

        // Vahetab algvaate (nupud) ja sisselogimise vaate (e-post + parool)
        private void NaitaVaade(string uus)
        {
            reziim = uus;
            bool vorm = uus != "";

            btnOstja.Visible = !vorm;
            btnKlient.Visible = !vorm;
            btnRegistreeru.Visible = !vorm;
            btnAdmin.Visible = !vorm;

            NaitaPealkiri();
            txtEmail.Visible = vorm;
            txtParool.Visible = vorm;
            btnLogin.Visible = vorm;
            btnTagasi.Visible = vorm;

            AcceptButton = vorm ? btnLogin : btnOstja;   // Enter vajutab õiget nuppu
            lblVeateade.Text = "";
            txtParool.Clear();
            if (vorm) txtEmail.Focus();
        }

        private void AvaPeamenyy()
        {
            lblVeateade.Text = "";
            txtParool.Clear();

            if (AktiivneKasutaja.Roll != "admin")
                Ostukorv.Lae();   // eelmisel korral pooleli jäänud ostukorv (adminil korvi pole)

            FormMain main = new FormMain();
            main.FormClosed += (_, _) =>
            {
                // "Logi välja" tühjendab rolli: siis tuleb tagasi sisselogimise aken,
                // muidu (akna sulgemisel) sulgub kogu programm
                if (AktiivneKasutaja.Roll == "")
                {
                    NaitaVaade("");
                    this.Show();
                }
                else
                    this.Close();
            };
            main.Show();
            this.Hide();
        }
    }
}
