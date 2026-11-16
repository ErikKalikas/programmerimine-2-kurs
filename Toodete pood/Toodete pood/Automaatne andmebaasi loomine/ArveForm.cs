using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    // Ostukorv: tooted ridadena (pilt, kogus − / +, summa), paremal kokkuvõte, sooduskood ja ostu vormistamine
    public partial class ArveForm : BaasVorm
    {
        // Ainult koodist määratav, vormi disainer seda ei salvesta (muidu viga WFO1000)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Toode? SelectedToode { get; set; }

        public ArveForm()
        {
            InitializeComponent();

            // Kõik tooted ComboBoxi, et korvi saaks kiiresti lisada ka ilma poodi minemata
            using var db = new ToodedContext();
            comboTooted.DataSource = db.Toodetabel.OrderBy(t => t.Toodenimetus).ToList();
            comboTooted.DisplayMember = "Toodenimetus";
            comboTooted.ValueMember = "Id";
        }

        private void ArveForm_Load(object? sender, EventArgs e)
        {
            // Kui lehele anti toode kaasa, on see kohe valitud
            if (SelectedToode != null)
                comboTooted.SelectedValue = SelectedToode.Id;

            NaitaKorvi();
        }

        // Näitab ostukorvi ridu ja summasid
        private void NaitaKorvi()
        {
            flpRead.SuspendLayout();
            foreach (var vana in flpRead.Controls.Cast<Control>().ToList())
                vana.Dispose();

            if (Ostukorv.Ridad.Count == 0)
            {
                flpRead.Controls.Add(new Label
                {
                    Text = Keel.T("Ostukorv on tühi."),
                    AutoSize = true,
                    Font = Teema.Alapealkiri,
                    ForeColor = Teema.HallTume,
                    Margin = new Padding(0, 24, 0, 12)
                });
                var btnPoodi = new UmarNupp
                {
                    Text = Keel.T("Mine poodi"),
                    Ikoon = "",
                    Stiil = NupuStiil.Punane,
                    Size = new Size(200, 44)
                };
                btnPoodi.Click += (_, _) => FormMain.Aktiivne?.AvaPood();
                flpRead.Controls.Add(btnPoodi);
            }

            for (int i = 0; i < Ostukorv.Ridad.Count; i++)
                flpRead.Controls.Add(LooRida(i));

            flpRead.ResumeLayout();

            lblKorvArv.Text = Keel.T("{0} toodet", Ostukorv.TooteidKokku);
            lblVahesumma.Text = $"{Ostukorv.Vahesumma:0.00} €";
            lblSoodustusT.Text = Ostukorv.SoodusProtsent > 0
                ? Keel.T("Soodustus ({0} −{1}%)", Ostukorv.Sooduskood, Ostukorv.SoodusProtsent)
                : Keel.T("Soodustus");
            lblSoodustus.Text = Ostukorv.SoodusProtsent > 0 ? $"−{Ostukorv.Soodustus:0.00} €" : "–";
            lblKokku.Text = $"{Ostukorv.Kokku:0.00} €";

            txtSooduskood.Text = Ostukorv.Sooduskood ?? "";
            txtSooduskood.ReadOnly = Ostukorv.Sooduskood != null;
            btnRakenda.Text = Ostukorv.Sooduskood != null ? Keel.T("Eemalda") : Keel.T("Rakenda");

            bool onTooteid = Ostukorv.Ridad.Count > 0;
            btnSaadaEmail.Enabled = btnGenPDF.Enabled = onTooteid;
        }

        // Üks rida: pilt, nimi, hind, − kogus +, summa, eemalda
        private UmarPaneel LooRida(int i)
        {
            var rida = Ostukorv.Ridad[i];
            var t = rida.Toode;
            int laius = Math.Max(420, flpRead.ClientSize.Width - 8);

            var p = new UmarPaneel
            {
                Size = new Size(laius, 96),
                Margin = new Padding(0, 0, 0, 10),
                Raadius = 10
            };

            p.Controls.Add(new PictureBox
            {
                Image = Pildid.Lae(t.Pilt),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(12, 12),
                Size = new Size(72, 72),
                BackColor = Teema.Valge
            });

            p.Controls.Add(new Label
            {
                Text = t.Toodenimetus,
                Font = Teema.KaardiNimi,
                AutoEllipsis = true,
                Location = new Point(100, 18),
                Size = new Size(laius - 100 - 330, 26),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            });

            string hind = $"{t.HetkeHind:0.00} € / {Keel.T("tk")}";
            if (t.OnSoodus) hind += $"   −{t.SoodusProtsent}%";
            p.Controls.Add(new Label
            {
                Text = hind,
                ForeColor = t.OnSoodus ? Teema.Punane : Teema.HallTume,
                AutoSize = true,
                Location = new Point(100, 50)
            });

            // paremalt vasakule: eemalda, summa, +, kogus, −
            var btnEemalda = new UmarNupp
            {
                Text = "",
                Ikoon = "",   // prügikast
                Stiil = NupuStiil.Kontuur,
                Size = new Size(36, 36),
                Location = new Point(laius - 52, 30),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnEemalda.Click += (_, _) => BeginInvoke(() => { Ostukorv.Eemalda(i); NaitaKorvi(); });

            var lblSumma = new Label
            {
                Text = $"{rida.Summa:0.00} €",
                Font = Teema.Alapealkiri,
                TextAlign = ContentAlignment.MiddleRight,
                Size = new Size(110, 36),
                Location = new Point(laius - 172, 30),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            var btnPluss = new UmarNupp
            {
                Text = "+",
                Stiil = NupuStiil.Hall,
                Size = new Size(36, 36),
                Location = new Point(laius - 220, 30),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnPluss.Click += (_, _) => BeginInvoke(() => MuudaKogust(i, +1));

            var lblKogus = new Label
            {
                Text = rida.Kogus.ToString(),
                Font = Teema.Paks,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(44, 36),
                Location = new Point(laius - 264, 30),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            var btnMiinus = new UmarNupp
            {
                Text = "−",
                Stiil = NupuStiil.Hall,
                Size = new Size(36, 36),
                Location = new Point(laius - 300, 30),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnMiinus.Click += (_, _) => BeginInvoke(() => MuudaKogust(i, -1));

            p.Controls.AddRange(new Control[] { btnMiinus, lblKogus, btnPluss, lblSumma, btnEemalda });
            return p;
        }

        // Ridade laius järgib akna laiust
        private void flpRead_Resize(object? sender, EventArgs e)
        {
            int laius = Math.Max(420, flpRead.ClientSize.Width - 8);
            foreach (Control c in flpRead.Controls)
                if (c is UmarPaneel) c.Width = laius;
        }

        private void MuudaKogust(int i, int muutus)
        {
            string? viga = Ostukorv.MuudaKogust(i, muutus);
            if (viga != null) MessageBox.Show(viga);
            NaitaKorvi();
        }

        private void btnLisaKorvi_Click(object? sender, EventArgs e)
        {
            if (comboTooted.SelectedItem is not Toode toode)
            {
                MessageBox.Show(Keel.T("Vali toode enne ostukorvi lisamist."));
                return;
            }

            string kogusStr = Microsoft.VisualBasic.Interaction.InputBox(
                Keel.T("Sisesta kogus"), Keel.T("Kogus"), "1");

            if (string.IsNullOrEmpty(kogusStr)) return;   // vajutati Cancel

            if (!int.TryParse(kogusStr, out int kogus) || kogus <= 0)
            {
                MessageBox.Show(Keel.T("Vale kogus."));
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

            MessageBox.Show(Keel.T("PDF on loodud:") + "\n" + arve.Value.Fail);
        }

        // Loob PDF-arve praeguse ostukorvi järgi (tühja korvi puhul null)
        private (string Fail, string Nr)? LooPdf(string? email)
        {
            if (Ostukorv.Ridad.Count == 0)
            {
                MessageBox.Show(Keel.T("Ostukorv on tühi."));
                return null;
            }

            var andmed = ArveAndmed.Ostukorvist(email);
            return (ArvePdf.Loo(andmed), andmed.Nr);
        }

        private async void btnSaadaEmail_Click(object? sender, EventArgs e)
        {
            if (Ostukorv.Ridad.Count == 0)
            {
                MessageBox.Show(Keel.T("Ostukorv on tühi."));
                return;
            }

            // Kontoga ostjal on e-post juba ette täidetud
            string vaikimisi = AktiivneKasutaja.OnKonto ? AktiivneKasutaja.Email : "nimi@example.com";
            string email = Microsoft.VisualBasic.Interaction.InputBox(
                Keel.T("Kuhu arve saata?"), Keel.T("E-post"), vaikimisi).Trim();

            if (string.IsNullOrWhiteSpace(email)) return;

            // PDF tehakse alati uuesti praeguse korvi järgi, et ei saadetaks vana arvet
            var arve = LooPdf(email);
            if (arve == null) return;
            string pdfPath = arve.Value.Fail;

            string nupuTekst = btnSaadaEmail.Text;
            btnSaadaEmail.Enabled = false;
            btnSaadaEmail.Text = Keel.T("Saadan...");
            try
            {
                // Esimesel korral avaneb brauser Google'i sisselogimiseks
                // Kirja teema ja sisu tulevad poe seadetest (mall)
                var pood = PoeSeaded.Lae();
                string Taida(string mall) => mall
                    .Replace("{nr}", arve.Value.Nr)
                    .Replace("{nimi}", AktiivneKasutaja.OnKonto && AktiivneKasutaja.Nimi != "" ? ", " + AktiivneKasutaja.Nimi : "")
                    .Replace("{summa}", $"{Ostukorv.Kokku:0.00} €")
                    .Replace("{pood}", pood.PoeNimi);

                await GmailSaatja.SaadaAsync(email, Taida(pood.KirjaTeema), Taida(pood.KirjaSisu), pdfPath);

                // Ost on tehtud: tellimus salvestatakse, laoseis väheneb ja korv tühjeneb
                Ostukorv.KinnitaOst(arve.Value.Nr, email, pdfPath);
                if (IsDisposed) return;   // kasutaja võis vahepeal teisele lehele minna
                NaitaKorvi();

                MessageBox.Show(Keel.T("Arve saadetud! Täname ostu eest."));
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show(Keel.T("Google'i sisselogimine jäi pooleli. Proovi uuesti."));
            }
            catch (Exception ex)
            {
                MessageBox.Show(Keel.T("Viga:") + " " + ex.Message);
            }
            finally
            {
                if (!IsDisposed)
                {
                    btnSaadaEmail.Text = nupuTekst;
                    btnSaadaEmail.Enabled = Ostukorv.Ridad.Count > 0;
                }
            }
        }
    }
}
