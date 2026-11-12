namespace Automaatne_andmebaasi_loomine
{
    partial class ArveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tlp = new TableLayoutPanel();
            pnlKorv = new UmarPaneel();
            flpRead = new FlowLayoutPanel();
            pnlKorvPais = new Panel();
            lblKorvPealkiri = new Label();
            lblKorvArv = new Label();
            pnlKokkuvote = new UmarPaneel();
            lblKokkuvote = new Label();
            lblVahesummaT = new Label();
            lblVahesumma = new Label();
            lblSoodustusT = new Label();
            lblSoodustus = new Label();
            pnlJoon = new Panel();
            lblKokkuT = new Label();
            lblKokku = new Label();
            txtSooduskood = new TextBox();
            btnRakenda = new UmarNupp();
            btnSaadaEmail = new UmarNupp();
            btnGenPDF = new UmarNupp();
            btnGmailValja = new UmarNupp();
            lblKiirlisamine = new Label();
            comboTooted = new ComboBox();
            btnLisaKorvi = new UmarNupp();
            tlp.SuspendLayout();
            pnlKorv.SuspendLayout();
            pnlKorvPais.SuspendLayout();
            pnlKokkuvote.SuspendLayout();
            SuspendLayout();
            // 
            // tlp
            // 
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380F));
            tlp.Controls.Add(pnlKorv, 0, 0);
            tlp.Controls.Add(pnlKokkuvote, 1, 0);
            tlp.Dock = DockStyle.Fill;
            tlp.Location = new Point(0, 0);
            tlp.Name = "tlp";
            tlp.RowCount = 1;
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp.Size = new Size(1000, 650);
            // 
            // pnlKorv
            // 
            pnlKorv.Controls.Add(flpRead);
            pnlKorv.Controls.Add(pnlKorvPais);
            pnlKorv.Dock = DockStyle.Fill;
            pnlKorv.Margin = new Padding(0, 0, 20, 0);
            pnlKorv.Name = "pnlKorv";
            pnlKorv.Padding = new Padding(20, 14, 20, 14);
            // 
            // flpRead
            // 
            flpRead.AutoScroll = true;
            flpRead.Dock = DockStyle.Fill;
            flpRead.FlowDirection = FlowDirection.TopDown;
            flpRead.Name = "flpRead";
            flpRead.WrapContents = false;
            flpRead.Resize += flpRead_Resize;
            // 
            // pnlKorvPais
            // 
            pnlKorvPais.Controls.Add(lblKorvPealkiri);
            pnlKorvPais.Controls.Add(lblKorvArv);
            pnlKorvPais.Dock = DockStyle.Top;
            pnlKorvPais.Name = "pnlKorvPais";
            pnlKorvPais.Size = new Size(560, 52);
            // 
            // lblKorvPealkiri
            // 
            lblKorvPealkiri.AutoSize = true;
            lblKorvPealkiri.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblKorvPealkiri.Location = new Point(0, 4);
            lblKorvPealkiri.Name = "lblKorvPealkiri";
            lblKorvPealkiri.Text = "Sinu ostukorv";
            // 
            // lblKorvArv
            // 
            lblKorvArv.AutoSize = true;
            lblKorvArv.ForeColor = Color.FromArgb(110, 110, 118);
            lblKorvArv.Location = new Point(2, 32);
            lblKorvArv.Name = "lblKorvArv";
            // 
            // pnlKokkuvote
            // 
            pnlKokkuvote.AutoScroll = true;
            pnlKokkuvote.Controls.Add(lblKokkuvote);
            pnlKokkuvote.Controls.Add(lblVahesummaT);
            pnlKokkuvote.Controls.Add(lblVahesumma);
            pnlKokkuvote.Controls.Add(lblSoodustusT);
            pnlKokkuvote.Controls.Add(lblSoodustus);
            pnlKokkuvote.Controls.Add(pnlJoon);
            pnlKokkuvote.Controls.Add(lblKokkuT);
            pnlKokkuvote.Controls.Add(lblKokku);
            pnlKokkuvote.Controls.Add(txtSooduskood);
            pnlKokkuvote.Controls.Add(btnRakenda);
            pnlKokkuvote.Controls.Add(btnSaadaEmail);
            pnlKokkuvote.Controls.Add(btnGenPDF);
            pnlKokkuvote.Controls.Add(btnGmailValja);
            pnlKokkuvote.Controls.Add(lblKiirlisamine);
            pnlKokkuvote.Controls.Add(comboTooted);
            pnlKokkuvote.Controls.Add(btnLisaKorvi);
            pnlKokkuvote.Dock = DockStyle.Fill;
            pnlKokkuvote.Margin = new Padding(0);
            pnlKokkuvote.Name = "pnlKokkuvote";
            // 
            // lblKokkuvote
            // 
            lblKokkuvote.AutoSize = true;
            lblKokkuvote.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblKokkuvote.Location = new Point(20, 18);
            lblKokkuvote.Name = "lblKokkuvote";
            lblKokkuvote.Text = "Kokkuvõte";
            // 
            // lblVahesummaT
            // 
            lblVahesummaT.AutoSize = true;
            lblVahesummaT.ForeColor = Color.FromArgb(110, 110, 118);
            lblVahesummaT.Location = new Point(20, 66);
            lblVahesummaT.Name = "lblVahesummaT";
            lblVahesummaT.Text = "Vahesumma";
            // 
            // lblVahesumma
            // 
            lblVahesumma.Location = new Point(180, 66);
            lblVahesumma.Name = "lblVahesumma";
            lblVahesumma.Size = new Size(160, 22);
            lblVahesumma.TextAlign = ContentAlignment.TopRight;
            // 
            // lblSoodustusT
            // 
            lblSoodustusT.AutoSize = true;
            lblSoodustusT.ForeColor = Color.FromArgb(110, 110, 118);
            lblSoodustusT.Location = new Point(20, 94);
            lblSoodustusT.Name = "lblSoodustusT";
            lblSoodustusT.Text = "Soodustus";
            // 
            // lblSoodustus
            // 
            lblSoodustus.ForeColor = Color.FromArgb(220, 38, 38);
            lblSoodustus.Location = new Point(140, 94);
            lblSoodustus.Name = "lblSoodustus";
            lblSoodustus.Size = new Size(200, 22);
            lblSoodustus.TextAlign = ContentAlignment.TopRight;
            // 
            // pnlJoon
            // 
            pnlJoon.BackColor = Color.FromArgb(222, 222, 228);
            pnlJoon.Location = new Point(20, 128);
            pnlJoon.Name = "pnlJoon";
            pnlJoon.Size = new Size(320, 1);
            // 
            // lblKokkuT
            // 
            lblKokkuT.AutoSize = true;
            lblKokkuT.Font = new Font("Segoe UI Semibold", 13F);
            lblKokkuT.Location = new Point(20, 144);
            lblKokkuT.Name = "lblKokkuT";
            lblKokkuT.Text = "Kokku";
            // 
            // lblKokku
            // 
            lblKokku.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblKokku.ForeColor = Color.FromArgb(220, 38, 38);
            lblKokku.Location = new Point(140, 136);
            lblKokku.Name = "lblKokku";
            lblKokku.Size = new Size(200, 40);
            lblKokku.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSooduskood
            // 
            txtSooduskood.CharacterCasing = CharacterCasing.Upper;
            txtSooduskood.Font = new Font("Segoe UI", 11F);
            txtSooduskood.Location = new Point(20, 196);
            txtSooduskood.Name = "txtSooduskood";
            txtSooduskood.PlaceholderText = "Sooduskood";
            txtSooduskood.Size = new Size(200, 27);
            // 
            // btnRakenda
            // 
            btnRakenda.Location = new Point(228, 194);
            btnRakenda.Name = "btnRakenda";
            btnRakenda.Size = new Size(112, 32);
            btnRakenda.Text = "Rakenda";
            btnRakenda.Click += btnRakenda_Click;
            // 
            // btnSaadaEmail
            // 
            btnSaadaEmail.Ikoon = "\uE715";
            btnSaadaEmail.Location = new Point(20, 246);
            btnSaadaEmail.Name = "btnSaadaEmail";
            btnSaadaEmail.Size = new Size(320, 50);
            btnSaadaEmail.Stiil = NupuStiil.Punane;
            btnSaadaEmail.Text = "Osta ja saada arve e-postiga";
            btnSaadaEmail.Click += btnSaadaEmail_Click;
            // 
            // btnGenPDF
            // 
            btnGenPDF.Ikoon = "\uE8A5";
            btnGenPDF.Location = new Point(20, 306);
            btnGenPDF.Name = "btnGenPDF";
            btnGenPDF.Size = new Size(320, 42);
            btnGenPDF.Stiil = NupuStiil.Kontuur;
            btnGenPDF.Text = "Genereeri PDF";
            btnGenPDF.Click += btnGenPDF_Click;
            // 
            // btnGmailValja
            // 
            btnGmailValja.Font = new Font("Segoe UI", 9F);
            btnGmailValja.Location = new Point(20, 356);
            btnGmailValja.Name = "btnGmailValja";
            btnGmailValja.Size = new Size(320, 36);
            btnGmailValja.Stiil = NupuStiil.Hall;
            btnGmailValja.Text = "Vaheta Gmaili kontot";
            btnGmailValja.Click += btnGmailValja_Click;
            // 
            // lblKiirlisamine
            // 
            lblKiirlisamine.AutoSize = true;
            lblKiirlisamine.Font = new Font("Segoe UI Semibold", 10F);
            lblKiirlisamine.Location = new Point(20, 414);
            lblKiirlisamine.Name = "lblKiirlisamine";
            lblKiirlisamine.Text = "Lisa toode kiiresti";
            // 
            // comboTooted
            // 
            comboTooted.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTooted.Font = new Font("Segoe UI", 11F);
            comboTooted.Location = new Point(20, 440);
            comboTooted.Name = "comboTooted";
            comboTooted.Size = new Size(200, 28);
            // 
            // btnLisaKorvi
            // 
            btnLisaKorvi.Location = new Point(228, 438);
            btnLisaKorvi.Name = "btnLisaKorvi";
            btnLisaKorvi.Size = new Size(112, 32);
            btnLisaKorvi.Text = "Lisa";
            btnLisaKorvi.Click += btnLisaKorvi_Click;
            // 
            // ArveForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 650);
            Controls.Add(tlp);
            Name = "ArveForm";
            Text = "Ostukorv";
            Load += ArveForm_Load;
            tlp.ResumeLayout(false);
            pnlKorv.ResumeLayout(false);
            pnlKorvPais.ResumeLayout(false);
            pnlKorvPais.PerformLayout();
            pnlKokkuvote.ResumeLayout(false);
            pnlKokkuvote.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private UmarPaneel pnlKorv;
        private System.Windows.Forms.FlowLayoutPanel flpRead;
        private System.Windows.Forms.Panel pnlKorvPais;
        private System.Windows.Forms.Label lblKorvPealkiri;
        private System.Windows.Forms.Label lblKorvArv;
        private UmarPaneel pnlKokkuvote;
        private System.Windows.Forms.Label lblKokkuvote;
        private System.Windows.Forms.Label lblVahesummaT;
        private System.Windows.Forms.Label lblVahesumma;
        private System.Windows.Forms.Label lblSoodustusT;
        private System.Windows.Forms.Label lblSoodustus;
        private System.Windows.Forms.Panel pnlJoon;
        private System.Windows.Forms.Label lblKokkuT;
        private System.Windows.Forms.Label lblKokku;
        private System.Windows.Forms.TextBox txtSooduskood;
        private UmarNupp btnRakenda;
        private UmarNupp btnSaadaEmail;
        private UmarNupp btnGenPDF;
        private UmarNupp btnGmailValja;
        private System.Windows.Forms.Label lblKiirlisamine;
        private System.Windows.Forms.ComboBox comboTooted;
        private UmarNupp btnLisaKorvi;
    }
}
