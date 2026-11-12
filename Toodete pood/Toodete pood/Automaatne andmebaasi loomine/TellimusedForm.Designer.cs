namespace Automaatne_andmebaasi_loomine
{
    partial class TellimusedForm
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
            pnlTellimused = new UmarPaneel();
            dgvTellimused = new DataGridView();
            pnlRead = new UmarPaneel();
            dgvRead = new DataGridView();
            lblRead = new Label();
            pnlNupud = new UmarPaneel();
            lblTegevused = new Label();
            btnAvaArve = new UmarNupp();
            btnTelliUuesti = new UmarNupp();
            lblVihje = new Label();
            tlp.SuspendLayout();
            pnlTellimused.SuspendLayout();
            pnlRead.SuspendLayout();
            pnlNupud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTellimused).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRead).BeginInit();
            SuspendLayout();
            // 
            // tlp
            // 
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tlp.Controls.Add(pnlTellimused, 0, 0);
            tlp.Controls.Add(pnlRead, 0, 1);
            tlp.Controls.Add(pnlNupud, 1, 0);
            tlp.SetRowSpan(pnlNupud, 2);
            tlp.Dock = DockStyle.Fill;
            tlp.Name = "tlp";
            tlp.RowCount = 2;
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tlp.Size = new Size(1000, 650);
            // 
            // pnlTellimused
            // 
            pnlTellimused.Controls.Add(dgvTellimused);
            pnlTellimused.Dock = DockStyle.Fill;
            pnlTellimused.Margin = new Padding(0, 0, 0, 10);
            pnlTellimused.Name = "pnlTellimused";
            pnlTellimused.Padding = new Padding(14);
            // 
            // dgvTellimused
            // 
            dgvTellimused.AllowUserToAddRows = false;
            dgvTellimused.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTellimused.Dock = DockStyle.Fill;
            dgvTellimused.MultiSelect = false;
            dgvTellimused.Name = "dgvTellimused";
            dgvTellimused.ReadOnly = true;
            dgvTellimused.RowHeadersVisible = false;
            dgvTellimused.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTellimused.SelectionChanged += dgvTellimused_SelectionChanged;
            // 
            // pnlRead
            // 
            pnlRead.Controls.Add(dgvRead);
            pnlRead.Controls.Add(lblRead);
            pnlRead.Dock = DockStyle.Fill;
            pnlRead.Margin = new Padding(0, 10, 0, 0);
            pnlRead.Name = "pnlRead";
            pnlRead.Padding = new Padding(14);
            // 
            // dgvRead
            // 
            dgvRead.AllowUserToAddRows = false;
            dgvRead.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRead.Dock = DockStyle.Fill;
            dgvRead.Name = "dgvRead";
            dgvRead.ReadOnly = true;
            dgvRead.RowHeadersVisible = false;
            // 
            // lblRead
            // 
            lblRead.Dock = DockStyle.Top;
            lblRead.Font = new Font("Segoe UI Semibold", 13F);
            lblRead.Name = "lblRead";
            lblRead.Size = new Size(600, 36);
            lblRead.Text = "Tellimuse tooted";
            // 
            // pnlNupud
            // 
            pnlNupud.Controls.Add(lblTegevused);
            pnlNupud.Controls.Add(btnAvaArve);
            pnlNupud.Controls.Add(btnTelliUuesti);
            pnlNupud.Controls.Add(lblVihje);
            pnlNupud.Dock = DockStyle.Fill;
            pnlNupud.Margin = new Padding(20, 0, 0, 0);
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
            // btnAvaArve
            // 
            btnAvaArve.Ikoon = "\uE8A5";
            btnAvaArve.Location = new Point(20, 58);
            btnAvaArve.Name = "btnAvaArve";
            btnAvaArve.Size = new Size(240, 46);
            btnAvaArve.Stiil = NupuStiil.Punane;
            btnAvaArve.Text = "Ava arve (PDF)";
            btnAvaArve.Click += btnAvaArve_Click;
            // 
            // btnTelliUuesti
            // 
            btnTelliUuesti.Ikoon = "\uE72C";
            btnTelliUuesti.Location = new Point(20, 114);
            btnTelliUuesti.Name = "btnTelliUuesti";
            btnTelliUuesti.Size = new Size(240, 46);
            btnTelliUuesti.Text = "Telli uuesti";
            btnTelliUuesti.Click += btnTelliUuesti_Click;
            // 
            // lblVihje
            // 
            lblVihje.ForeColor = Color.FromArgb(110, 110, 118);
            lblVihje.Location = new Point(20, 176);
            lblVihje.Name = "lblVihje";
            lblVihje.Size = new Size(240, 90);
            lblVihje.Text = "Vali tabelist tellimus, et näha selle tooteid. \"Telli uuesti\" lisab samad tooted ostukorvi.";
            // 
            // TellimusedForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 650);
            Controls.Add(tlp);
            Name = "TellimusedForm";
            Text = "Minu tellimused";
            tlp.ResumeLayout(false);
            pnlTellimused.ResumeLayout(false);
            pnlRead.ResumeLayout(false);
            pnlNupud.ResumeLayout(false);
            pnlNupud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTellimused).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRead).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private UmarPaneel pnlTellimused;
        private System.Windows.Forms.DataGridView dgvTellimused;
        private UmarPaneel pnlRead;
        private System.Windows.Forms.DataGridView dgvRead;
        private System.Windows.Forms.Label lblRead;
        private UmarPaneel pnlNupud;
        private System.Windows.Forms.Label lblTegevused;
        private UmarNupp btnAvaArve;
        private UmarNupp btnTelliUuesti;
        private System.Windows.Forms.Label lblVihje;
    }
}
