namespace Automaatne_andmebaasi_loomine
{
    // Toote detailvaade: suur pilt, hind, laoseis, kirjeldus, korvi lisamine ja lemmik
    public partial class TooteKaartForm : BaasVorm
    {
        private readonly Toode toode;

        public TooteKaartForm(Toode toode)
        {
            InitializeComponent();
            this.toode = toode;

            Text = toode.Toodenimetus;
            pbPilt.Image = Pildid.Lae(toode.Pilt);
            lblNimi.Text = toode.Toodenimetus;
            lblKirjeldus.Text = string.IsNullOrWhiteSpace(toode.Kirjeldus) ? Keel.T("Kirjeldus puudub.") : toode.Kirjeldus;

            lblHind.Text = $"{toode.HetkeHind:0.00} €";
            if (toode.OnSoodus)
            {
                lblHind.ForeColor = Teema.Punane;
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
                lblLaos.Text = Keel.T("Otsas");
                lblLaos.ForeColor = Teema.Punane;
            }
            else
            {
                lblLaos.Text = korvis > 0 ? Keel.T("Laos: {0} tk (korvis {1} tk)", toode.Kogus, korvis) : Keel.T("Laos: {0} tk", toode.Kogus);
                lblLaos.ForeColor = Teema.HallTume;
            }

            if (saadaval <= 0)
            {
                numKogus.Enabled = false;
                btnLisa.Enabled = false;
                btnLisa.Text = toode.Kogus <= 0 ? Keel.T("Otsas") : Keel.T("Kõik on juba korvis");
                btnLisa.Ikoon = "";
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
            btnLemmik.Ikoon = lemmik ? "\uEB52" : "\uEB51";
            btnLemmik.Text = lemmik ? Keel.T("Eemalda lemmikutest") : Keel.T("Lisa lemmikutesse");
        }

        private void btnLisa_Click(object? sender, EventArgs e)
        {
            string? viga = Ostukorv.Lisa(toode, (int)numKogus.Value);
            if (viga != null)
            {
                MessageBox.Show(viga);
                return;
            }

            MessageBox.Show(Keel.T("{0} ({1} tk) lisati korvi.", toode.Toodenimetus, numKogus.Value));
            DialogResult = DialogResult.OK;
        }

        private void btnLemmik_Click(object? sender, EventArgs e)
        {
            NaitaLemmikut(LemmikTooted.Vaheta(toode.Id));
        }
    }
}
