using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    public partial class ArveForm : Form
    {
        List<OstukorviRida> ostukorv = new List<OstukorviRida>();

        public Toode? SelectedToode { get; set; }

        // Saatja Gmail ja rakenduse parool küsitakse programmi töö ajal (koodis parooli ei hoita)
        private static string? saatjaEmail;
        private static string? saatjaParool;

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

        private void btnSaadaEmail_Click(object? sender, EventArgs e)
        {
            string email = Microsoft.VisualBasic.Interaction.InputBox(
                "Sisesta e-mail", "Saaja", "nimi@example.com");

            if (string.IsNullOrEmpty(email)) return;

            if (!Directory.Exists("Arved") || Directory.GetFiles("Arved", "*.pdf").Length == 0)
            {
                MessageBox.Show("Arvet pole veel loodud. Vajuta enne \"Genereeri PDF\".");
                return;
            }

            if (!KusiSaatjaAndmed()) return;

            string pdfPath = Directory.GetFiles("Arved", "*.pdf")
                .OrderByDescending(f => f)
                .First();

            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(saatjaEmail!);
                mail.To.Add(email);
                mail.Subject = "Arve";
                mail.Body = "Arve on manuses.";
                mail.Attachments.Add(new Attachment(pdfPath));

                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(saatjaEmail, saatjaParool),
                    EnableSsl = true
                };

                smtp.Send(mail);

                MessageBox.Show("Arve saadetud!");
            }
            catch (Exception ex)
            {
                // vale parooli korral küsitakse järgmisel korral uuesti
                saatjaParool = null;
                MessageBox.Show("Viga: " + ex.Message);
            }
        }

        // Küsib saatja Gmaili ja rakenduse parooli (Google konto → Turvalisus → Rakenduse paroolid)
        private bool KusiSaatjaAndmed()
        {
            if (!string.IsNullOrEmpty(saatjaEmail) && !string.IsNullOrEmpty(saatjaParool)) return true;

            using var f = new Form
            {
                Text = "Saatja Gmail",
                ClientSize = new Size(300, 150),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.LightBlue
            };
            var txtEmail = new TextBox { Location = new Point(20, 20), Width = 260, PlaceholderText = "sinu_gmail@gmail.com", Text = saatjaEmail ?? "" };
            var txtParool = new TextBox { Location = new Point(20, 60), Width = 260, PlaceholderText = "Rakenduse parool", PasswordChar = '*' };
            var btnOk = new Button { Text = "OK", Location = new Point(205, 100), DialogResult = DialogResult.OK };
            f.Controls.Add(txtEmail);
            f.Controls.Add(txtParool);
            f.Controls.Add(btnOk);
            f.AcceptButton = btnOk;

            if (f.ShowDialog(this) != DialogResult.OK ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtParool.Text))
                return false;

            saatjaEmail = txtEmail.Text.Trim();
            saatjaParool = txtParool.Text.Replace(" ", "");
            return true;
        }
    }
}
