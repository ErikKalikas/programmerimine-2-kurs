using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    public partial class ArveForm : Form
    {
        // Ainult koodist määratav, vormi disainer seda ei salvesta (muidu viga WFO1000)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Toode? SelectedToode { get; set; }

        public ArveForm()
        {
            InitializeComponent();

            // Kõik tooted ComboBoxi, et korvi saaks lisada mitu erinevat toodet
            using var db = new ToodedContext();
            comboTooted.DataSource = db.Toodetabel.OrderBy(t => t.Toodenimetus).ToList();
            comboTooted.DisplayMember = "Toodenimetus";
            comboTooted.ValueMember = "Id";
        }

        private void ArveForm_Load(object? sender, EventArgs e)
        {
            // Kui vorm avati Form2-st, on see toode kohe valitud
            if (SelectedToode != null)
                comboTooted.SelectedValue = SelectedToode.Id;

            // Gmaili kontot saab vahetada ainult admin
            btnGmailValja.Visible = AktiivneKasutaja.Roll == "admin";

            NaitaKorvi();
        }

        // Näitab ostukorvi sisu ja summasid
        private void NaitaKorvi()
        {
            int valitud = listOstukorv.SelectedIndex;

            listOstukorv.Items.Clear();
            foreach (var rida in Ostukorv.Ridad)
                listOstukorv.Items.Add(rida);

            // valik jääb samale reale ka pärast +/- vajutamist
            if (valitud >= 0 && valitud < listOstukorv.Items.Count)
                listOstukorv.SelectedIndex = valitud;

            if (Ostukorv.SoodusProtsent > 0)
                lblKokku.Text = $"Vahesumma: {Ostukorv.Vahesumma:0.00} €    Soodustus ({Ostukorv.Sooduskood} −{Ostukorv.SoodusProtsent}%): −{Ostukorv.Soodustus:0.00} €\n" +
                                $"KOKKU: {Ostukorv.Kokku:0.00} €";
            else
                lblKokku.Text = $"KOKKU: {Ostukorv.Kokku:0.00} €";

            txtSooduskood.Text = Ostukorv.Sooduskood ?? "";
            btnRakenda.Text = Ostukorv.Sooduskood != null ? "Eemalda kood" : "Rakenda";
        }

        private void btnLisaKorvi_Click(object? sender, EventArgs e)
        {
            if (comboTooted.SelectedItem is not Toode toode)
            {
                MessageBox.Show("Vali toode enne ostukorvi lisamist.");
                return;
            }

            string kogusStr = Microsoft.VisualBasic.Interaction.InputBox(
                "Sisesta kogus", "Kogus", "1");

            if (string.IsNullOrEmpty(kogusStr)) return;   // vajutati Cancel

            if (!int.TryParse(kogusStr, out int kogus) || kogus <= 0)
            {
                MessageBox.Show("Vale kogus.");
                return;
            }

            string? viga = Ostukorv.Lisa(toode, kogus);
            if (viga != null)
            {
                MessageBox.Show(viga);
                return;
            }

            NaitaKorvi();
        }

        private void btnPluss_Click(object? sender, EventArgs e) => MuudaKogust(+1);

        private void btnMiinus_Click(object? sender, EventArgs e) => MuudaKogust(-1);

        private void MuudaKogust(int muutus)
        {
            int i = listOstukorv.SelectedIndex;
            if (i < 0)
            {
                MessageBox.Show("Vali ostukorvist rida.");
                return;
            }

            string? viga = Ostukorv.MuudaKogust(i, muutus);
            if (viga != null) MessageBox.Show(viga);
            NaitaKorvi();
        }

        private void btnEemalda_Click(object? sender, EventArgs e)
        {
            int i = listOstukorv.SelectedIndex;
            if (i < 0)
            {
                MessageBox.Show("Vali ostukorvist rida, mida eemaldada.");
                return;
            }

            Ostukorv.Eemalda(i);
            NaitaKorvi();
        }

        private void btnRakenda_Click(object? sender, EventArgs e)
        {
            if (Ostukorv.Sooduskood != null)
            {
                Ostukorv.EemaldaKood();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtSooduskood.Text)) return;
                string? viga = Ostukorv.RakendaKood(txtSooduskood.Text);
                if (viga != null) MessageBox.Show(viga);
            }
            NaitaKorvi();
        }

        private void btnGenPDF_Click(object? sender, EventArgs e)
        {
            var arve = LooPdf(AktiivneKasutaja.OnKonto ? AktiivneKasutaja.Email : null);
            if (arve == null) return;

            MessageBox.Show($"PDF on loodud:\n{arve.Value.Fail}");
        }

        // Loob PDF-arve praeguse ostukorvi järgi (tühja korvi puhul null)
        private (string Fail, string Nr)? LooPdf(string? email)
        {
            if (Ostukorv.Ridad.Count == 0)
            {
                MessageBox.Show("Ostukorv on tühi.");
                return null;
            }

            var andmed = ArveAndmed.Ostukorvist(email);
            return (ArvePdf.Loo(andmed), andmed.Nr);
        }

        private async void btnSaadaEmail_Click(object? sender, EventArgs e)
        {
            if (Ostukorv.Ridad.Count == 0)
            {
                MessageBox.Show("Ostukorv on tühi.");
                return;
            }

            // Kontoga ostjal on e-post juba ette täidetud
            string vaikimisi = AktiivneKasutaja.OnKonto ? AktiivneKasutaja.Email : "nimi@example.com";
            string email = Microsoft.VisualBasic.Interaction.InputBox(
                "Kuhu arve saata?", "E-post", vaikimisi).Trim();

            if (string.IsNullOrWhiteSpace(email)) return;

            // PDF tehakse alati uuesti praeguse korvi järgi, et ei saadetaks vana arvet
            var arve = LooPdf(email);
            if (arve == null) return;
            string pdfPath = arve.Value.Fail;

            btnSaadaEmail.Enabled = false;
            btnSaadaEmail.Text = "Saadan...";
            try
            {
                // Esimesel korral avaneb brauser Google'i sisselogimiseks
                await GmailSaatja.SaadaAsync(email, $"Arve nr {arve.Value.Nr}", "Arve on manuses. Aitäh ostu eest!", pdfPath);

                // Ost on tehtud: tellimus salvestatakse, laoseis väheneb ja korv tühjeneb
                Ostukorv.KinnitaOst(arve.Value.Nr, email, pdfPath);
                NaitaKorvi();

                MessageBox.Show("Arve saadetud! Täname ostu eest.");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Google'i sisselogimine jäi pooleli. Proovi uuesti.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga: " + ex.Message);
            }
            finally
            {
                btnSaadaEmail.Enabled = true;
                btnSaadaEmail.Text = "Saada emailiga";
            }
        }

        private async void btnGmailValja_Click(object? sender, EventArgs e)
        {
            await GmailSaatja.LogiValjaAsync();
            MessageBox.Show("Gmaili konto unustatud. Järgmisel saatmisel küsitakse kontot uuesti.");
        }
    }
}
