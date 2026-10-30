using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    public partial class ArveForm : Form
    {
        public Toode? SelectedToode { get; set; }

        // Viimati loodud PDF, mis saadetakse e-postiga
        private string? viimanePdf;

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

            NaitaKorvi();
        }

        // Näitab ostukorvi sisu ja kogusummat
        private void NaitaKorvi()
        {
            listOstukorv.Items.Clear();
            foreach (var rida in Ostukorv.Ridad)
                listOstukorv.Items.Add(rida);

            lblKokku.Text = $"Kokku: {Ostukorv.Kokku} €";
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

            Ostukorv.Lisa(toode, kogus);
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
            if (Ostukorv.Ridad.Count == 0)
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
            foreach (var item in Ostukorv.Ridad)
            {
                gfx.DrawString(item.ToString(), font, XBrushes.Black,
                    new XRect(20, y, page.Width - 40, 20), XStringFormats.TopLeft);
                y += 30;
            }

            gfx.DrawString($"Kokku: {Ostukorv.Kokku} €",
                new XFont("Verdana", 14), XBrushes.Black,
                new XRect(20, y + 20, page.Width, 20), XStringFormats.TopLeft);

            document.Save(failinimi);
            viimanePdf = Path.GetFullPath(failinimi);

            MessageBox.Show($"PDF on loodud:\n{failinimi}");
        }

        private void btnSaadaEmail_Click(object? sender, EventArgs e)
        {
            if (viimanePdf == null)
            {
                MessageBox.Show("Genereeri enne PDF.");
                return;
            }

            try
            {
                string? viga = new ArveTeenus(new GmailSaatja()).SaadaArve(txtEmail.Text, viimanePdf);
                if (viga != null)
                {
                    MessageBox.Show(viga);
                    return;
                }
                MessageBox.Show("Arve saadetud!");
                NaitaKorvi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga: " + ex.Message);
            }
        }
    }
}
