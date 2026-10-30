namespace Automaatne_andmebaasi_loomine
{
    // Ostja andmed (lähevad ka arvele) ja parooli muutmine
    public partial class ProfiilForm : Form
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
                MessageBox.Show("Nimi ei tohi olla tühi.");
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
            MessageBox.Show("Andmed salvestatud.");
        }

        private void btnMuudaParool_Click(object? sender, EventArgs e)
        {
            using var db = new ToodedContext();
            var k = db.Kasutajad.Find(AktiivneKasutaja.Id);
            if (k == null) return;

            if (!PasswordHelper.Verify(txtVanaParool.Text, k.ParoolHash))
            { MessageBox.Show("Praegune parool on vale."); return; }
            if (txtUusParool.Text.Length < 6)
            { MessageBox.Show("Uus parool peab olema vähemalt 6 märki."); return; }
            if (txtUusParool.Text != txtUusParool2.Text)
            { MessageBox.Show("Uued paroolid ei ühti."); return; }

            k.ParoolHash = PasswordHelper.Hash(txtUusParool.Text);
            db.SaveChanges();

            txtVanaParool.Clear();
            txtUusParool.Clear();
            txtUusParool2.Clear();
            MessageBox.Show("Parool muudetud.");
        }
    }
}
