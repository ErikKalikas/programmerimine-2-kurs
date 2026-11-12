namespace Automaatne_andmebaasi_loomine
{
    partial class KoikTellimusedForm
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
            pnlFilter = new Panel();
            txtOtsi = new TextBox();
            lblAlates = new Label();
            dtpAlates = new DateTimePicker();
            lblKuni = new Label();
            dtpKuni = new DateTimePicker();
            lblKokku = new Label();
            tlp = new TableLayoutPanel();
            pnlTellimused = new UmarPaneel();
            dgvTellimused = new DataGridView();
            pnlRead = new UmarPaneel();
            dgvRead = new DataGridView();
            lblRead = new Label();
            pnlFilter.SuspendLayout();
            tlp.SuspendLayout();
            pnlTellimused.SuspendLayout();
            pnlRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTellimused).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRead).BeginInit();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(txtOtsi);
            pnlFilter.Controls.Add(lblAlates);
            pnlFilter.Controls.Add(dtpAlates);
            pnlFilter.Controls.Add(lblKuni);
            pnlFilter.Controls.Add(dtpKuni);
            pnlFilter.Controls.Add(lblKokku);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1000, 56);
            // 
            // txtOtsi
            // 
            txtOtsi.Font = new Font("Segoe UI", 12F);
            txtOtsi.Location = new Point(0, 8);
            txtOtsi.Name = "txtOtsi";
            txtOtsi.PlaceholderText = "🔍 Nr, ostja nimi või e-post";
            txtOtsi.Size = new Size(320, 29);
            txtOtsi.TextChanged += Filter_Changed;
            // 
            // lblAlates
            // 
            lblAlates.AutoSize = true;
            lblAlates.Location = new Point(340, 14);
            lblAlates.Name = "lblAlates";
            lblAlates.Text = "Alates:";
            // 
            // dtpAlates
            // 
            dtpAlates.Font = new Font("Segoe UI", 11F);
            dtpAlates.Format = DateTimePickerFormat.Short;
            dtpAlates.Location = new Point(400, 9);
            dtpAlates.Name = "dtpAlates";
            dtpAlates.Size = new Size(130, 27);
            dtpAlates.ValueChanged += Filter_Changed;
            // 
            // lblKuni
            // 
            lblKuni.AutoSize = true;
            lblKuni.Location = new Point(546, 14);
            lblKuni.Name = "lblKuni";
            lblKuni.Text = "Kuni:";
            // 
            // dtpKuni
            // 
            dtpKuni.Font = new Font("Segoe UI", 11F);
            dtpKuni.Format = DateTimePickerFormat.Short;
            dtpKuni.Location = new Point(596, 9);
            dtpKuni.Name = "dtpKuni";
            dtpKuni.Size = new Size(130, 27);
            dtpKuni.ValueChanged += Filter_Changed;
            // 
            // lblKokku
            // 
            lblKokku.AutoSize = true;
            lblKokku.Font = new Font("Segoe UI Semibold", 11F);
            lblKokku.ForeColor = Color.FromArgb(220, 38, 38);
            lblKokku.Location = new Point(750, 13);
            lblKokku.Name = "lblKokku";
            // 
            // tlp
            // 
            tlp.ColumnCount = 1;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.Controls.Add(pnlTellimused, 0, 0);
            tlp.Controls.Add(pnlRead, 0, 1);
            tlp.Dock = DockStyle.Fill;
            tlp.Name = "tlp";
            tlp.RowCount = 2;
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tlp.Size = new Size(1000, 594);
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
            // KoikTellimusedForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 650);
            Controls.Add(tlp);
            Controls.Add(pnlFilter);
            Name = "KoikTellimusedForm";
            Text = "Kõik tellimused";
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            tlp.ResumeLayout(false);
            pnlTellimused.ResumeLayout(false);
            pnlRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTellimused).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRead).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox txtOtsi;
        private System.Windows.Forms.Label lblAlates;
        private System.Windows.Forms.DateTimePicker dtpAlates;
        private System.Windows.Forms.Label lblKuni;
        private System.Windows.Forms.DateTimePicker dtpKuni;
        private System.Windows.Forms.Label lblKokku;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private UmarPaneel pnlTellimused;
        private System.Windows.Forms.DataGridView dgvTellimused;
        private UmarPaneel pnlRead;
        private System.Windows.Forms.DataGridView dgvRead;
        private System.Windows.Forms.Label lblRead;
    }
}
