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

        // Näitab ostukorvi sisu ja kogusummat
        private void NaitaKorvi()
        {
            listOstukorv.Items.Clear();
            foreach (var rida in Ostukorv.Ridad)
                listOstukorv.Items.Add(rida);

            lblKokku.Text = $"Kokku: {Ostukorv.Kokku:0.00} €";
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

        private void btnEemalda_Click(object? sender, EventArgs e)
        {
            int i = listOstukorv.SelectedIndex;
            if (i < 0)
            {
                MessageBox.Show("Vali ostukorvist rida, mida eemaldada.");
                return;
            }

            Ostukorv.Ridad.RemoveAt(i);
            NaitaKorvi();
        }

        private void btnGenPDF_Click(object? sender, EventArgs e)
        {
            string? failinimi = LooPdf();
            if (failinimi == null) return;

            MessageBox.Show($"PDF on loodud:\n{failinimi}");
        }

        // Loob PDF-arve praeguse ostukorvi järgi ja tagastab faili tee (tühja korvi puhul null)
        private string? LooPdf(string? ostja = null)
        {
            if (Ostukorv.Ridad.Count == 0)
            {
                MessageBox.Show("Ostukorv on tühi.");
                return null;
            }

            return ArvePdf.Loo(Ostukorv.Ridad, ostja);
        }

        private async void btnSaadaEmail_Click(object? sender, EventArgs e)
        {
            if (Ostukorv.Ridad.Count == 0)
            {
                MessageBox.Show("Ostukorv on tühi.");
                return;
            }

            string email = Microsoft.VisualBasic.Interaction.InputBox(
                "Sisesta e-mail", "Saaja", "nimi@example.com");

            if (string.IsNullOrWhiteSpace(email)) return;

            // PDF tehakse alati uuesti praeguse korvi järgi, et ei saadetaks vana arvet
            string? pdfPath = LooPdf(email.Trim());
            if (pdfPath == null) return;

            btnSaadaEmail.Enabled = false;
            btnSaadaEmail.Text = "Saadan...";
            try
            {
                // Esimesel korral avaneb brauser Google'i sisselogimiseks
                await GmailSaatja.SaadaAsync(email.Trim(), "Arve", "Arve on manuses.", pdfPath);

                // Ost on tehtud: laoseis väheneb ja korv tühjeneb
                Ostukorv.KinnitaOst();
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
