namespace Automaatne_andmebaasi_loomine
{
    // Ostja andmed (lähevad ka arvele) ja parooli muutmine
    public partial class ProfiilForm : BaasVorm
    {
        public ProfiilForm()
        {
            InitializeComponent();

            using var db = new ToodedContext();
            var k = db.Kasutajad.Find(AktiivneKasutaja.Id);
            if (k == null) return;

            lblEmail.Text = k.Email;
            txtNimi.Text = k.Nimi;
            txtTelefon.Text = k.Telefon;
            txtAadress.Text = k.Aadress;
        }

        private void btnSalvesta_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNimi.Text))
            {
                MessageBox.Show(Keel.T("Nimi ei tohi olla tühi."));
                return;
            }

            using var db = new ToodedContext();
            var k = db.Kasutajad.Find(AktiivneKasutaja.Id);
            if (k == null) return;

            k.Nimi = txtNimi.Text.Trim();
            k.Telefon = txtTelefon.Text.Trim();
            k.Aadress = txtAadress.Text.Trim();
            db.SaveChanges();

            AktiivneKasutaja.Nimi = k.Nimi;
            FormMain.Aktiivne?.UuendaTervitus();
            MessageBox.Show(Keel.T("Andmed salvestatud."));
        }

        private void btnMuudaParool_Click(object? sender, EventArgs e)
        {
            using var db = new ToodedContext();
            var k = db.Kasutajad.Find(AktiivneKasutaja.Id);
            if (k == null) return;

            if (!PasswordHelper.Verify(txtVanaParool.Text, k.ParoolHash))
            { MessageBox.Show(Keel.T("Praegune parool on vale.")); return; }
            if (txtUusParool.Text.Length < 6)
            { MessageBox.Show(Keel.T("Uus parool peab olema vähemalt 6 märki.")); return; }
            if (txtUusParool.Text != txtUusParool2.Text)
            { MessageBox.Show(Keel.T("Uued paroolid ei ühti.")); return; }

            k.ParoolHash = PasswordHelper.Hash(txtUusParool.Text);
            db.SaveChanges();
            Tegevuslogi.Kirjuta("Muutis oma parooli");

            txtVanaParool.Clear();
            txtUusParool.Clear();
            txtUusParool2.Clear();
            MessageBox.Show(Keel.T("Parool muudetud."));
        }
    }
}
