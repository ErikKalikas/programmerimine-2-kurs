namespace Automaatne_andmebaasi_loomine
{
    partial class KasutajadForm
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
            pnlTabel = new UmarPaneel();
            dgvKasutajad = new DataGridView();
            pnlNupud = new UmarPaneel();
            lblTegevused = new Label();
            btnLisaAdmin = new UmarNupp();
            btnRoll = new UmarNupp();
            btnBlokeeri = new UmarNupp();
            lblVihje = new Label();
            tlp.SuspendLayout();
            pnlTabel.SuspendLayout();
            pnlNupud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKasutajad).BeginInit();
            SuspendLayout();
            // 
            // tlp
            // 
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tlp.Controls.Add(pnlTabel, 0, 0);
            tlp.Controls.Add(pnlNupud, 1, 0);
            tlp.Dock = DockStyle.Fill;
            tlp.Location = new Point(0, 0);
            tlp.Name = "tlp";
            tlp.RowCount = 1;
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp.Size = new Size(1000, 650);
            // 
            // pnlTabel
            // 
            pnlTabel.Controls.Add(dgvKasutajad);
            pnlTabel.Dock = DockStyle.Fill;
            pnlTabel.Margin = new Padding(0, 0, 20, 0);
            pnlTabel.Name = "pnlTabel";
            pnlTabel.Padding = new Padding(14);
            // 
            // dgvKasutajad
            // 
            dgvKasutajad.AllowUserToAddRows = false;
            dgvKasutajad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKasutajad.Dock = DockStyle.Fill;
            dgvKasutajad.MultiSelect = false;
            dgvKasutajad.Name = "dgvKasutajad";
            dgvKasutajad.ReadOnly = true;
            dgvKasutajad.RowHeadersVisible = false;
            dgvKasutajad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKasutajad.DataBindingComplete += dgvKasutajad_DataBindingComplete;
            // 
            // pnlNupud
            // 
            pnlNupud.Controls.Add(lblTegevused);
            pnlNupud.Controls.Add(btnLisaAdmin);
            pnlNupud.Controls.Add(btnRoll);
            pnlNupud.Controls.Add(btnBlokeeri);
            pnlNupud.Controls.Add(lblVihje);
            pnlNupud.Dock = DockStyle.Fill;
            pnlNupud.Margin = new Padding(0);
            pnlNupud.Name = "pnlNupud";
            // 
            // lblTegevused
            // 
            lblTegevused.AutoSize = true;
            lblTegevused.Font = new Font("Segoe UI Semibold", 13F);
            lblTegevused.Location = new Point(20, 18);
            lblTegevused.Name = "lblTegevused";
            lblTegevused.Text = "Tegevused";
            // 
            // btnLisaAdmin
            // 
            btnLisaAdmin.Ikoon = "\uE8FA";
            btnLisaAdmin.Location = new Point(20, 58);
            btnLisaAdmin.Name = "btnLisaAdmin";
            btnLisaAdmin.Size = new Size(240, 44);
            btnLisaAdmin.Stiil = NupuStiil.Punane;
            btnLisaAdmin.Text = "Lisa administraator";
            btnLisaAdmin.Click += btnLisaAdmin_Click;
            // 
            // btnRoll
            // 
            btnRoll.Ikoon = "\uE8D7";
            btnRoll.Location = new Point(20, 114);
            btnRoll.Name = "btnRoll";
            btnRoll.Size = new Size(240, 44);
            btnRoll.Text = "Muuda rolli";
            btnRoll.Click += btnRoll_Click;
            // 
            // btnBlokeeri
            // 
            btnBlokeeri.Ikoon = "\uE72E";
            btnBlokeeri.Location = new Point(20, 170);
            btnBlokeeri.Name = "btnBlokeeri";
            btnBlokeeri.Size = new Size(240, 44);
            btnBlokeeri.Stiil = NupuStiil.Kontuur;
            btnBlokeeri.Text = "Blokeeri / ava";
            btnBlokeeri.Click += btnBlokeeri_Click;
            // 
            // lblVihje
            // 
            lblVihje.ForeColor = Color.FromArgb(110, 110, 118);
            lblVihje.Location = new Point(20, 232);
            lblVihje.Name = "lblVihje";
            lblVihje.Size = new Size(240, 70);
            lblVihje.Text = "Blokeeritud kasutaja ei saa sisse logida. Oma kontot siin muuta ei saa.";
            // 
            // KasutajadForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 650);
            Controls.Add(tlp);
            Name = "KasutajadForm";
            Text = "Kasutajad";
            tlp.ResumeLayout(false);
            tlp.PerformLayout();
            pnlTabel.ResumeLayout(false);
            pnlTabel.PerformLayout();
            pnlNupud.ResumeLayout(false);
            pnlNupud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKasutajad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private UmarPaneel pnlTabel;
        private System.Windows.Forms.DataGridView dgvKasutajad;
        private UmarPaneel pnlNupud;
        private System.Windows.Forms.Label lblTegevused;
        private UmarNupp btnLisaAdmin;
        private UmarNupp btnRoll;
        private UmarNupp btnBlokeeri;
        private System.Windows.Forms.Label lblVihje;
    }
}
