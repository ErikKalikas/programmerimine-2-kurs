namespace Automaatne_andmebaasi_loomine
{
    // Admin: poe andmed arvel, käibemaks, logo ja arve kirja mall
    public partial class SeadedForm : Form
    {
        private string? logo;   // pildifail kaustas Images

        public SeadedForm()
        {
            InitializeComponent();

            var s = PoeSeaded.Lae();
            txtPoeNimi.Text = s.PoeNimi;
            txtHyydlause.Text = s.Hyydlause;
            txtAadress.Text = s.Aadress;
            txtRegistrikood.Text = s.Registrikood;
            txtKmkrNr.Text = s.KmkrNr;
            txtTelefon.Text = s.Telefon;
            txtEmail.Text = s.Email;
            numKm.Value = (decimal)s.KmProtsent;
            txtKirjaTeema.Text = s.KirjaTeema;
            txtKirjaSisu.Text = s.KirjaSisu.Replace("\n", Environment.NewLine);

            logo = s.Logo;
            pbLogo.Image = Pildid.Lae(logo);
        }

        private void btnLogo_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Pildid|*.png;*.jpg;*.jpeg" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            // logo kopeeritakse kausta Images (uue nimega, et vahemälu ei näitaks vana pilti)
            Directory.CreateDirectory("Images");
            string uusNimi = $"logo_{DateTime.Now:yyyyMMddHHmmss}{Path.GetExtension(ofd.FileName)}";
            File.Copy(ofd.FileName, Path.Combine("Images", uusNimi), true);

            logo = uusNimi;
            pbLogo.Image = Pildid.Lae(logo);
        }

        private void btnEemaldaLogo_Click(object? sender, EventArgs e)
        {
            logo = null;
            pbLogo.Image = null;
        }

        private void btnSalvesta_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPoeNimi.Text))
            {
                MessageBox.Show("Poe nimi ei tohi olla tühi.");
                return;
            }

            using var db = new ToodedContext();
            var s = db.Seaded.OrderBy(x => x.Id).First();   // Lae() lõi rea juba valmis

            s.PoeNimi = txtPoeNimi.Text.Trim();
            s.Hyydlause = txtHyydlause.Text.Trim();
            s.Aadress = txtAadress.Text.Trim();
            s.Registrikood = txtRegistrikood.Text.Trim();
            s.KmkrNr = txtKmkrNr.Text.Trim();
            s.Telefon = txtTelefon.Text.Trim();
            s.Email = txtEmail.Text.Trim();
            s.KmProtsent = (float)numKm.Value;
            s.Logo = logo;
            s.KirjaTeema = txtKirjaTeema.Text.Trim();
            s.KirjaSisu = txtKirjaSisu.Text.Replace("\r\n", "\n");
            db.SaveChanges();

            Tegevuslogi.Kirjuta("Muutis poe seadeid");
            MessageBox.Show("Seaded salvestatud. Need kehtivad järgmistel arvetel.");
            Close();
        }
    }
}
