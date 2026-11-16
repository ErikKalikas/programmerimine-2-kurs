namespace Automaatne_andmebaasi_loomine
{
    partial class LogiForm
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
            txtOtsi = new TextBox();
            pnlTabel = new UmarPaneel();
            dgvLogi = new DataGridView();
            pnlYlal.SuspendLayout();
            pnlTabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogi).BeginInit();
            SuspendLayout();
            // 
            // pnlYlal
            // 
            pnlYlal.Controls.Add(txtOtsi);
            pnlYlal.Dock = DockStyle.Top;
            pnlYlal.Name = "pnlYlal";
            pnlYlal.Size = new Size(1000, 56);
            // 
            // txtOtsi
            // 
            txtOtsi.Font = new Font("Segoe UI", 11F);
            txtOtsi.Location = new Point(0, 8);
            txtOtsi.Name = "txtOtsi";
            txtOtsi.PlaceholderText = "🔍 Otsi (kasutaja või tegevus)";
            txtOtsi.Size = new Size(380, 27);
            txtOtsi.Font = new Font("Segoe UI", 12F);
            txtOtsi.TextChanged += txtOtsi_TextChanged;
            // 
            // pnlTabel
            // 
            pnlTabel.Controls.Add(dgvLogi);
            pnlTabel.Dock = DockStyle.Fill;
            pnlTabel.Margin = new Padding(0);
            pnlTabel.Name = "pnlTabel";
            pnlTabel.Padding = new Padding(14);
            // 
            // dgvLogi
            // 
            dgvLogi.AllowUserToAddRows = false;
            dgvLogi.Dock = DockStyle.Fill;
            dgvLogi.MultiSelect = false;
            dgvLogi.Name = "dgvLogi";
            dgvLogi.ReadOnly = true;
            dgvLogi.RowHeadersVisible = false;
            dgvLogi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // LogiForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 650);
            Controls.Add(pnlTabel);
            Controls.Add(pnlYlal);
            Name = "LogiForm";
            Text = "Tegevuste logi";
            pnlYlal.ResumeLayout(false);
            pnlYlal.PerformLayout();
            pnlTabel.ResumeLayout(false);
            pnlTabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlYlal;
        private System.Windows.Forms.TextBox txtOtsi;
        private UmarPaneel pnlTabel;
        private System.Windows.Forms.DataGridView dgvLogi;
    }
}
