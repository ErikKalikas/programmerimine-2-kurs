namespace Automaatne_andmebaasi_loomine
{
    partial class LemmikudForm
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
            dgvLemmikud = new DataGridView();
            pnlNupud = new UmarPaneel();
            lblTegevused = new Label();
            btnAva = new UmarNupp();
            btnLisaKorvi = new UmarNupp();
            btnEemalda = new UmarNupp();
            lblVihje = new Label();
            tlp.SuspendLayout();
            pnlTabel.SuspendLayout();
            pnlNupud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLemmikud).BeginInit();
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
            pnlTabel.Controls.Add(dgvLemmikud);
            pnlTabel.Dock = DockStyle.Fill;
            pnlTabel.Margin = new Padding(0, 0, 20, 0);
            pnlTabel.Name = "pnlTabel";
            pnlTabel.Padding = new Padding(14);
            // 
            // dgvLemmikud
            // 
            dgvLemmikud.AllowUserToAddRows = false;
            dgvLemmikud.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLemmikud.Dock = DockStyle.Fill;
            dgvLemmikud.MultiSelect = false;
            dgvLemmikud.Name = "dgvLemmikud";
            dgvLemmikud.ReadOnly = true;
            dgvLemmikud.RowHeadersVisible = false;
            dgvLemmikud.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLemmikud.CellDoubleClick += dgvLemmikud_CellDoubleClick;
            // 
            // pnlNupud
            // 
            pnlNupud.Controls.Add(lblTegevused);
            pnlNupud.Controls.Add(btnAva);
            pnlNupud.Controls.Add(btnLisaKorvi);
            pnlNupud.Controls.Add(btnEemalda);
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
            // btnAva
            // 
            btnAva.Ikoon = "\uE8A7";
            btnAva.Location = new Point(20, 58);
            btnAva.Name = "btnAva";
            btnAva.Size = new Size(240, 44);
            btnAva.Text = "Ava toode";
            btnAva.Click += btnAva_Click;
            // 
            // btnLisaKorvi
            // 
            btnLisaKorvi.Ikoon = "\uE7BF";
            btnLisaKorvi.Location = new Point(20, 114);
            btnLisaKorvi.Name = "btnLisaKorvi";
            btnLisaKorvi.Size = new Size(240, 44);
            btnLisaKorvi.Stiil = NupuStiil.Punane;
            btnLisaKorvi.Text = "Lisa korvi (1 tk)";
            btnLisaKorvi.Click += btnLisaKorvi_Click;
            // 
            // btnEemalda
            // 
            btnEemalda.Ikoon = "\uE74D";
            btnEemalda.Location = new Point(20, 170);
            btnEemalda.Name = "btnEemalda";
            btnEemalda.Size = new Size(240, 44);
            btnEemalda.Stiil = NupuStiil.Kontuur;
            btnEemalda.Text = "Eemalda lemmikutest";
            btnEemalda.Click += btnEemalda_Click;
            // 
            // lblVihje
            // 
            lblVihje.ForeColor = Color.FromArgb(110, 110, 118);
            lblVihje.Location = new Point(20, 232);
            lblVihje.Name = "lblVihje";
            lblVihje.Size = new Size(240, 70);
            lblVihje.Text = "Lisa tooteid lemmikutesse poe tootekaardil nupuga ♡.";
            // 
            // LemmikudForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 650);
            Controls.Add(tlp);
            Name = "LemmikudForm";
            Text = "Lemmikud";
            tlp.ResumeLayout(false);
            tlp.PerformLayout();
            pnlTabel.ResumeLayout(false);
            pnlTabel.PerformLayout();
            pnlNupud.ResumeLayout(false);
            pnlNupud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLemmikud).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private UmarPaneel pnlTabel;
        private System.Windows.Forms.DataGridView dgvLemmikud;
        private UmarPaneel pnlNupud;
        private System.Windows.Forms.Label lblTegevused;
        private UmarNupp btnAva;
        private UmarNupp btnLisaKorvi;
        private UmarNupp btnEemalda;
        private System.Windows.Forms.Label lblVihje;
    }
}
