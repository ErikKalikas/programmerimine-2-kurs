using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    public partial class ArveForm : Form
    {
        List<OstukorviRida> ostukorv = new List<OstukorviRida>();

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

            if (!int.TryParse(kogusStr, out int kogus) || kogus <= 0)
            {
                MessageBox.Show("Vale kogus.");
                return;
            }

            // Kui toode on juba korvis, suurendame kogust
            var olemas = ostukorv.FirstOrDefault(r => r.Toode.Id == toode.Id);
            if (olemas != null)
            {
                olemas.Kogus += kogus;
                listOstukorv.Items[ostukorv.IndexOf(olemas)] = olemas;
            }
            else
            {
                var rida = new OstukorviRida
                {
                    Toode = toode,
                    Kogus = kogus
                };

                ostukorv.Add(rida);
                listOstukorv.Items.Add(rida);
            }

            ArvutaKoguSumma();
        }

        private void btnEemalda_Click(object? sender, EventArgs e)
        {
            int i = listOstukorv.SelectedIndex;
            if (i < 0)
            {
                MessageBox.Show("Vali ostukorvist rida, mida eemaldada.");
                return;
            }

            ostukorv.RemoveAt(i);
            listOstukorv.Items.RemoveAt(i);

            ArvutaKoguSumma();
        }

        private void ArvutaKoguSumma()
        {
            float kokku = ostukorv.Sum(r => r.Summa);

            lblKokku.Text = $"Kokku: {kokku} €";
        }

        private void btnGenPDF_Click(object? sender, EventArgs e)
        {
            if (ostukorv.Count == 0)
            {
                MessageBox.Show("Ostukorv on tühi.");
                return;
            }

            Directory.CreateDirectory("Arved");

            string failinimi = $"Arved/Arve_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 12);

            gfx.DrawString("Arve", new XFont("Verdana", 20), XBrushes.Black,
                new XRect(0, 20, page.Width, 40), XStringFormats.TopCenter);

            int y = 80;
            foreach (var item in ostukorv)
            {
                gfx.DrawString(item.ToString(), font, XBrushes.Black,
                    new XRect(20, y, page.Width - 40, 20), XStringFormats.TopLeft);
                y += 30;
            }

            gfx.DrawString($"Kokku: {ostukorv.Sum(r => r.Summa)} €",
                new XFont("Verdana", 14), XBrushes.Black,
                new XRect(20, y + 20, page.Width, 20), XStringFormats.TopLeft);

            document.Save(failinimi);

            MessageBox.Show($"PDF on loodud:\n{failinimi}");
        }

        private async void btnSaadaEmail_Click(object? sender, EventArgs e)
        {
            if (!Directory.Exists("Arved") || Directory.GetFiles("Arved", "*.pdf").Length == 0)
            {
                MessageBox.Show("Arvet pole veel loodud. Vajuta enne \"Genereeri PDF\".");
                return;
            }

            string email = Microsoft.VisualBasic.Interaction.InputBox(
                "Sisesta e-mail", "Saaja", "nimi@example.com");

            if (string.IsNullOrWhiteSpace(email)) return;

            string pdfPath = Path.GetFullPath(Directory.GetFiles("Arved", "*.pdf")
                .OrderByDescending(f => f)
                .First());

            btnSaadaEmail.Enabled = false;
            btnSaadaEmail.Text = "Saadan...";
            try
            {
                // Esimesel korral avaneb brauser Google'i sisselogimiseks
                await GmailSaatja.SaadaAsync(email.Trim(), "Arve", "Arve on manuses.", pdfPath);

                MessageBox.Show("Arve saadetud!");
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
