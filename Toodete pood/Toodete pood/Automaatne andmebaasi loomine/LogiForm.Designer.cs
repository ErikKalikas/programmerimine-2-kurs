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
            txtOtsi = new TextBox();
            dgvLogi = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLogi).BeginInit();
            SuspendLayout();
            // 
            // txtOtsi
            // 
            txtOtsi.Location = new Point(12, 12);
            txtOtsi.Name = "txtOtsi";
            txtOtsi.PlaceholderText = "🔍 Otsi (kasutaja või tegevus)";
            txtOtsi.Size = new Size(300, 23);
            txtOtsi.TextChanged += txtOtsi_TextChanged;
            // 
            // dgvLogi
            // 
            dgvLogi.AllowUserToAddRows = false;
            dgvLogi.Location = new Point(12, 45);
            dgvLogi.Name = "dgvLogi";
            dgvLogi.ReadOnly = true;
            dgvLogi.RowHeadersVisible = false;
            dgvLogi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogi.Size = new Size(860, 450);
            // 
            // LogiForm
            // 
            ClientSize = new Size(885, 508);
            Controls.Add(txtOtsi);
            Controls.Add(dgvLogi);
            Name = "LogiForm";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.LightBlue;
            Text = "Tegevuste logi";
            ((System.ComponentModel.ISupportInitialize)dgvLogi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtOtsi;
        private System.Windows.Forms.DataGridView dgvLogi;
    }
}
