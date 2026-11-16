using System.ComponentModel;
using System.Net.Mail;

namespace Automaatne_andmebaasi_loomine
{
    // Uue ostja konto loomine
    public partial class RegistreerimineForm : BaasVorm
    {
        // Loodud konto (null, kui registreerimine jäi pooleli)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Kasutaja? UusKasutaja { get; private set; }

        private readonly string roll;

        // roll "kasutaja" = ostja registreerub ise, "admin" = administraator lisab uue administraatori
        public RegistreerimineForm(string roll = "kasutaja")
        {
            InitializeComponent();
            this.roll = roll;
            if (roll == "admin")
            {
                Text = "Uus administraator";
                lblPealkiri.Text = "Uus administraator";
                btnRegistreeru.Text = "Lisa";
            }
        }

        private void btnRegistreeru_Click(object? sender, EventArgs e)
        {
            string nimi = txtNimi.Text.Trim();
            string email = txtEmail.Text.Trim().ToLower();

            if (nimi == "") { lblViga.Text = Keel.T("Sisesta nimi."); return; }
            if (!MailAddress.TryCreate(email, out _) || !email.Contains('.'))
            { lblViga.Text = Keel.T("Vale e-posti aadress."); return; }
            if (txtParool.Text.Length < 6) { lblViga.Text = Keel.T("Parool peab olema vähemalt 6 märki."); return; }
            if (txtParool.Text != txtParool2.Text) { lblViga.Text = Keel.T("Paroolid ei ühti."); return; }

            using var db = new ToodedContext();
            if (db.Kasutajad.Any(k => k.Email.ToLower() == email))
            {
                lblViga.Text = Keel.T("Selle e-postiga konto on juba olemas.");
                return;
            }

            var kasutaja = new Kasutaja
            {
                Nimi = nimi,
                Email = email,
                ParoolHash = PasswordHelper.Hash(txtParool.Text),
                Roll = roll,
                Telefon = txtTelefon.Text.Trim(),
                Aadress = txtAadress.Text.Trim()
            };
            db.Kasutajad.Add(kasutaja);
            db.SaveChanges();

            UusKasutaja = kasutaja;
            if (roll == "admin") Tegevuslogi.Kirjuta($"Lisas administraatori {email}");
            MessageBox.Show(roll == "admin" ? Keel.T("Administraator {0} on lisatud.", nimi) : Keel.T("Tere tulemast, {0}! Konto on loodud.", nimi));
            DialogResult = DialogResult.OK;
        }
    }
}
