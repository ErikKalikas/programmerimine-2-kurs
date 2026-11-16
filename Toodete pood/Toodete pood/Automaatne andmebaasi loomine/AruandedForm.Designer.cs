namespace Automaatne_andmebaasi_loomine
{
    partial class AruandedForm
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
            pnlYlal = new Panel();
            btnTana = new UmarNupp();
            btnNadal = new UmarNupp();
            btnKuu = new UmarNupp();
            btnKoik = new UmarNupp();
            dtpAlates = new DateTimePicker();
            lblKriips = new Label();
            dtpKuni = new DateTimePicker();
            tlp = new TableLayoutPanel();
            pnlKokkuvote = new UmarPaneel();
            lblKokkuvote = new Label();
            pnlTop = new UmarPaneel();
            dgvTop = new DataGridView();
            lblTop = new Label();
            pnlKat = new UmarPaneel();
            dgvKategooriad = new DataGridView();
            lblKat = new Label();
            pnlGraafikKaart = new UmarPaneel();
            pnlGraafik = new Panel();
            pnlYlal.SuspendLayout();
            tlp.SuspendLayout();
            pnlKokkuvote.SuspendLayout();
            pnlTop.SuspendLayout();
            pnlKat.SuspendLayout();
            pnlGraafikKaart.SuspendLayout();
            pnlGraafik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKategooriad).BeginInit();
            SuspendLayout();
            // 
            // pnlYlal
            // 
            pnlYlal.Controls.Add(btnTana);
            pnlYlal.Controls.Add(btnNadal);
            pnlYlal.Controls.Add(btnKuu);
            pnlYlal.Controls.Add(btnKoik);
            pnlYlal.Controls.Add(dtpAlates);
            pnlYlal.Controls.Add(lblKriips);
            pnlYlal.Controls.Add(dtpKuni);
            pnlYlal.Dock = DockStyle.Top;
            pnlYlal.Name = "pnlYlal";
            pnlYlal.Size = new Size(1000, 56);
            // 
            // btnTana
            // 
            btnTana.Location = new Point(0, 8);
            btnTana.Name = "btnTana";
            btnTana.Size = new Size(100, 36);
            btnTana.Stiil = NupuStiil.Kontuur;
            btnTana.Text = "Täna";
            btnTana.Click += btnTana_Click;
            // 
            // btnNadal
            // 
            btnNadal.Location = new Point(108, 8);
            btnNadal.Name = "btnNadal";
            btnNadal.Size = new Size(100, 36);
            btnNadal.Stiil = NupuStiil.Kontuur;
            btnNadal.Text = "7 päeva";
            btnNadal.Click += btnNadal_Click;
            // 
            // btnKuu
            // 
            btnKuu.Location = new Point(216, 8);
            btnKuu.Name = "btnKuu";
            btnKuu.Size = new Size(100, 36);
            btnKuu.Stiil = NupuStiil.Kontuur;
            btnKuu.Text = "30 päeva";
            btnKuu.Click += btnKuu_Click;
            // 
            // btnKoik
            // 
            btnKoik.Location = new Point(324, 8);
            btnKoik.Name = "btnKoik";
            btnKoik.Size = new Size(100, 36);
            btnKoik.Stiil = NupuStiil.Kontuur;
            btnKoik.Text = "Kõik";
            btnKoik.Click += btnKoik_Click;
            // 
            // dtpAlates
            // 
            dtpAlates.Font = new Font("Segoe UI", 11F);
            dtpAlates.Format = DateTimePickerFormat.Short;
            dtpAlates.Location = new Point(444, 12);
            dtpAlates.Name = "dtpAlates";
            dtpAlates.Size = new Size(140, 27);
            dtpAlates.ValueChanged += Periood_Changed;
            // 
            // dtpKuni
            // 
            dtpKuni.Font = new Font("Segoe UI", 11F);
            dtpKuni.Format = DateTimePickerFormat.Short;
            dtpKuni.Location = new Point(604, 12);
            dtpKuni.Name = "dtpKuni";
            dtpKuni.Size = new Size(140, 27);
            dtpKuni.ValueChanged += Periood_Changed;
            // 
            // lblKriips
            // 
            lblKriips.AutoSize = true;
            lblKriips.Location = new Point(588, 15);
            lblKriips.Name = "lblKriips";
            lblKriips.Text = "–";
            // 
            // tlp
            // 
            tlp.ColumnCount = 3;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp.Controls.Add(pnlKokkuvote, 0, 0);
            tlp.Controls.Add(pnlTop, 1, 0);
            tlp.Controls.Add(pnlKat, 2, 0);
            tlp.Controls.Add(pnlGraafikKaart, 0, 1);
            tlp.SetColumnSpan(pnlGraafikKaart, 3);
            tlp.Dock = DockStyle.Fill;
            tlp.Name = "tlp";
            tlp.RowCount = 2;
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tlp.Size = new Size(1000, 594);
            // 
            // pnlKokkuvote
            // 
            pnlKokkuvote.Controls.Add(lblKokkuvote);
            pnlKokkuvote.Dock = DockStyle.Fill;
            pnlKokkuvote.Margin = new Padding(0, 0, 20, 10);
            pnlKokkuvote.Name = "pnlKokkuvote";
            pnlKokkuvote.Padding = new Padding(20, 16, 20, 16);
            // 
            // lblKokkuvote
            // 
            lblKokkuvote.Dock = DockStyle.Fill;
            lblKokkuvote.Font = new Font("Segoe UI", 10.5F);
            lblKokkuvote.Name = "lblKokkuvote";
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(dgvTop);
            pnlTop.Controls.Add(lblTop);
            pnlTop.Dock = DockStyle.Fill;
            pnlTop.Margin = new Padding(0, 0, 20, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(14);
            // 
            // dgvTop
            // 
            dgvTop.AllowUserToAddRows = false;
            dgvTop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTop.Dock = DockStyle.Fill;
            dgvTop.Name = "dgvTop";
            dgvTop.ReadOnly = true;
            dgvTop.RowHeadersVisible = false;
            // 
            // lblTop
            // 
            lblTop.Dock = DockStyle.Top;
            lblTop.Font = new Font("Segoe UI Semibold", 13F);
            lblTop.Name = "lblTop";
            lblTop.Size = new Size(300, 36);
            lblTop.Text = "Top-10 enim müüdud tooted";
            // 
            // pnlKat
            // 
            pnlKat.Controls.Add(dgvKategooriad);
            pnlKat.Controls.Add(lblKat);
            pnlKat.Dock = DockStyle.Fill;
            pnlKat.Margin = new Padding(0, 0, 0, 10);
            pnlKat.Name = "pnlKat";
            pnlKat.Padding = new Padding(14);
            // 
            // dgvKategooriad
            // 
            dgvKategooriad.AllowUserToAddRows = false;
            dgvKategooriad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKategooriad.Dock = DockStyle.Fill;
            dgvKategooriad.Name = "dgvKategooriad";
            dgvKategooriad.ReadOnly = true;
            dgvKategooriad.RowHeadersVisible = false;
            // 
            // lblKat
            // 
            lblKat.Dock = DockStyle.Top;
            lblKat.Font = new Font("Segoe UI Semibold", 13F);
            lblKat.Name = "lblKat";
            lblKat.Size = new Size(300, 36);
            lblKat.Text = "Müük kategooriate kaupa";
            // 
            // pnlGraafikKaart
            // 
            pnlGraafikKaart.Controls.Add(pnlGraafik);
            pnlGraafikKaart.Dock = DockStyle.Fill;
            pnlGraafikKaart.Margin = new Padding(0, 10, 0, 0);
            pnlGraafikKaart.Name = "pnlGraafikKaart";
            pnlGraafikKaart.Padding = new Padding(14);
            // 
            // pnlGraafik
            // 
            pnlGraafik.BackColor = Color.White;
            pnlGraafik.Dock = DockStyle.Fill;
            pnlGraafik.Name = "pnlGraafik";
            pnlGraafik.Paint += pnlGraafik_Paint;
            // 
            // AruandedForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 650);
            Controls.Add(tlp);
            Controls.Add(pnlYlal);
            Name = "AruandedForm";
            Text = "Müügiaruanne";
            pnlYlal.ResumeLayout(false);
            pnlYlal.PerformLayout();
            tlp.ResumeLayout(false);
            tlp.PerformLayout();
            pnlKokkuvote.ResumeLayout(false);
            pnlKokkuvote.PerformLayout();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlKat.ResumeLayout(false);
            pnlKat.PerformLayout();
            pnlGraafikKaart.ResumeLayout(false);
            pnlGraafikKaart.PerformLayout();
            pnlGraafik.ResumeLayout(false);
            pnlGraafik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKategooriad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlYlal;
        private UmarNupp btnTana;
        private UmarNupp btnNadal;
        private UmarNupp btnKuu;
        private UmarNupp btnKoik;
        private System.Windows.Forms.DateTimePicker dtpAlates;
        private System.Windows.Forms.Label lblKriips;
        private System.Windows.Forms.DateTimePicker dtpKuni;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private UmarPaneel pnlKokkuvote;
        private System.Windows.Forms.Label lblKokkuvote;
        private UmarPaneel pnlTop;
        private System.Windows.Forms.DataGridView dgvTop;
        private System.Windows.Forms.Label lblTop;
        private UmarPaneel pnlKat;
        private System.Windows.Forms.DataGridView dgvKategooriad;
        private System.Windows.Forms.Label lblKat;
        private UmarPaneel pnlGraafikKaart;
        private System.Windows.Forms.Panel pnlGraafik;
    }
}
