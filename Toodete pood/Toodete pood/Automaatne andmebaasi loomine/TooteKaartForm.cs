namespace Automaatne_andmebaasi_loomine
{
    // Toote detailvaade: suur pilt, hind, laoseis, kirjeldus, korvi lisamine ja lemmik
    public partial class TooteKaartForm : Form
    {
        private readonly Toode toode;

        public TooteKaartForm(Toode toode)
        {
            InitializeComponent();
            this.toode = toode;

            Text = toode.Toodenimetus;
            pbPilt.Image = Pildid.Lae(toode.Pilt);
            lblNimi.Text = toode.Toodenimetus;
            lblKirjeldus.Text = string.IsNullOrWhiteSpace(toode.Kirjeldus) ? "Kirjeldus puudub." : toode.Kirjeldus;

            lblHind.Text = $"{toode.HetkeHind:0.00} €";
            if (toode.OnSoodus)
            {
                lblHind.ForeColor = Color.Firebrick;
                lblVanaHind.Text = $"{toode.Hind:0.00} €   (−{toode.SoodusProtsent}%)";
            }
            else
            {
                lblVanaHind.Visible = false;
            }

            int korvis = Ostukorv.Ridad.FirstOrDefault(r => r.Toode.Id == toode.Id)?.Kogus ?? 0;
            int saadaval = toode.Kogus - korvis;

            if (toode.Kogus <= 0)
            {
                lblLaos.Text = "Otsas";
                lblLaos.ForeColor = Color.Firebrick;
            }
            else
            {
                lblLaos.Text = korvis > 0 ? $"Laos: {toode.Kogus} tk (korvis {korvis} tk)" : $"Laos: {toode.Kogus} tk";
                lblLaos.ForeColor = Color.DarkGreen;
            }

            if (saadaval <= 0)
            {
                numKogus.Enabled = false;
                btnLisa.Enabled = false;
                btnLisa.Text = toode.Kogus <= 0 ? "Otsas" : "Kõik on juba korvis";
            }
            else
            {
                numKogus.Maximum = saadaval;
            }

            // Lemmikud on ainult kontoga ostjal
            btnLemmik.Visible = AktiivneKasutaja.OnKonto;
            NaitaLemmikut(LemmikTooted.OnLemmik(toode.Id));
        }

        private void NaitaLemmikut(bool lemmik)
        {
            btnLemmik.Text = lemmik ? "♥ Eemalda lemmikutest" : "♡ Lisa lemmikutesse";
        }

        private void btnLisa_Click(object? sender, EventArgs e)
        {
            string? viga = Ostukorv.Lisa(toode, (int)numKogus.Value);
            if (viga != null)
            {
                MessageBox.Show(viga);
                return;
            }

            MessageBox.Show($"{toode.Toodenimetus} ({numKogus.Value} tk) lisati korvi.");
            DialogResult = DialogResult.OK;
        }

        private void btnLemmik_Click(object? sender, EventArgs e)
        {
            NaitaLemmikut(LemmikTooted.Vaheta(toode.Id));
        }
    }
}
