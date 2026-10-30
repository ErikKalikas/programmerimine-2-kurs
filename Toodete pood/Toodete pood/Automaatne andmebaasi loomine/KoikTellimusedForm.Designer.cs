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
            txtOtsi = new TextBox();
            lblAlates = new Label();
            dtpAlates = new DateTimePicker();
            lblKuni = new Label();
            dtpKuni = new DateTimePicker();
            dgvTellimused = new DataGridView();
            lblKokku = new Label();
            lblRead = new Label();
            dgvRead = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTellimused).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRead).BeginInit();
            SuspendLayout();
            // 
            // txtOtsi
            // 
            txtOtsi.Location = new Point(12, 12);
            txtOtsi.Name = "txtOtsi";
            txtOtsi.PlaceholderText = "🔍 Nr, ostja nimi või e-post";
            txtOtsi.Size = new Size(250, 23);
            txtOtsi.TextChanged += Filter_Changed;
            // 
            // lblAlates
            // 
            lblAlates.AutoSize = true;
            lblAlates.Location = new Point(280, 15);
            lblAlates.Name = "lblAlates";
            lblAlates.Text = "Alates:";
            // 
            // dtpAlates
            // 
            dtpAlates.Format = DateTimePickerFormat.Short;
            dtpAlates.Location = new Point(330, 12);
            dtpAlates.Name = "dtpAlates";
            dtpAlates.Size = new Size(110, 23);
            dtpAlates.ValueChanged += Filter_Changed;
            // 
            // lblKuni
            // 
            lblKuni.AutoSize = true;
            lblKuni.Location = new Point(455, 15);
            lblKuni.Name = "lblKuni";
            lblKuni.Text = "Kuni:";
            // 
            // dtpKuni
            // 
            dtpKuni.Format = DateTimePickerFormat.Short;
            dtpKuni.Location = new Point(495, 12);
            dtpKuni.Name = "dtpKuni";
            dtpKuni.Size = new Size(110, 23);
            dtpKuni.ValueChanged += Filter_Changed;
            // 
            // dgvTellimused
            // 
            dgvTellimused.AllowUserToAddRows = false;
            dgvTellimused.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTellimused.Location = new Point(12, 45);
            dgvTellimused.MultiSelect = false;
            dgvTellimused.Name = "dgvTellimused";
            dgvTellimused.ReadOnly = true;
            dgvTellimused.RowHeadersVisible = false;
            dgvTellimused.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTellimused.Size = new Size(760, 230);
            dgvTellimused.SelectionChanged += dgvTellimused_SelectionChanged;
            // 
            // lblKokku
            // 
            lblKokku.AutoSize = true;
            lblKokku.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKokku.Location = new Point(12, 282);
            lblKokku.Name = "lblKokku";
            // 
            // lblRead
            // 
            lblRead.AutoSize = true;
            lblRead.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRead.Location = new Point(12, 310);
            lblRead.Name = "lblRead";
            lblRead.Text = "Tellimuse tooted";
            // 
            // dgvRead
            // 
            dgvRead.AllowUserToAddRows = false;
            dgvRead.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRead.Location = new Point(12, 335);
            dgvRead.Name = "dgvRead";
            dgvRead.ReadOnly = true;
            dgvRead.RowHeadersVisible = false;
            dgvRead.Size = new Size(760, 170);
            // 
            // KoikTellimusedForm
            // 
            ClientSize = new Size(785, 518);
            Controls.Add(txtOtsi);
            Controls.Add(lblAlates);
            Controls.Add(dtpAlates);
            Controls.Add(lblKuni);
            Controls.Add(dtpKuni);
            Controls.Add(dgvTellimused);
            Controls.Add(lblKokku);
            Controls.Add(lblRead);
            Controls.Add(dgvRead);
            Name = "KoikTellimusedForm";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.LightBlue;
            Text = "Kõik tellimused";
            ((System.ComponentModel.ISupportInitialize)dgvTellimused).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRead).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtOtsi;
        private System.Windows.Forms.Label lblAlates;
        private System.Windows.Forms.DateTimePicker dtpAlates;
        private System.Windows.Forms.Label lblKuni;
        private System.Windows.Forms.DateTimePicker dtpKuni;
        private System.Windows.Forms.DataGridView dgvTellimused;
        private System.Windows.Forms.Label lblKokku;
        private System.Windows.Forms.Label lblRead;
        private System.Windows.Forms.DataGridView dgvRead;
    }
}
