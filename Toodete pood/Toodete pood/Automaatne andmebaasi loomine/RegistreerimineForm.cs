using System.ComponentModel;
using System.Net.Mail;

namespace Automaatne_andmebaasi_loomine
{
    // Uue ostja konto loomine
    public partial class RegistreerimineForm : Form
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
                btnRegistreeru.Text = "Lisa";
            }
        }

        private void btnRegistreeru_Click(object? sender, EventArgs e)
        {
            string nimi = txtNimi.Text.Trim();
            string email = txtEmail.Text.Trim().ToLower();

            if (nimi == "") { lblViga.Text = "Sisesta nimi."; return; }
            if (!MailAddress.TryCreate(email, out _) || !email.Contains('.'))
            { lblViga.Text = "Vale e-posti aadress."; return; }
            if (txtParool.Text.Length < 6) { lblViga.Text = "Parool peab olema vähemalt 6 märki."; return; }
            if (txtParool.Text != txtParool2.Text) { lblViga.Text = "Paroolid ei ühti."; return; }

            using var db = new ToodedContext();
            if (db.Kasutajad.Any(k => k.Email.ToLower() == email))
            {
                lblViga.Text = "Selle e-postiga konto on juba olemas.";
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
            MessageBox.Show(roll == "admin" ? $"Administraator {nimi} on lisatud." : $"Tere tulemast, {nimi}! Konto on loodud.");
            DialogResult = DialogResult.OK;
        }
    }
}
