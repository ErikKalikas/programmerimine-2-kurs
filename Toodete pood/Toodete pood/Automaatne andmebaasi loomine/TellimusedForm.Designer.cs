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
            dgvTellimused = new DataGridView();
            lblRead = new Label();
            dgvRead = new DataGridView();
            btnAvaArve = new Button();
            btnTelliUuesti = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTellimused).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRead).BeginInit();
            SuspendLayout();
            // 
            // dgvTellimused
            // 
            dgvTellimused.AllowUserToAddRows = false;
            dgvTellimused.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTellimused.Location = new Point(12, 12);
            dgvTellimused.MultiSelect = false;
            dgvTellimused.Name = "dgvTellimused";
            dgvTellimused.ReadOnly = true;
            dgvTellimused.RowHeadersVisible = false;
            dgvTellimused.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTellimused.Size = new Size(570, 200);
            dgvTellimused.SelectionChanged += dgvTellimused_SelectionChanged;
            // 
            // lblRead
            // 
            lblRead.AutoSize = true;
            lblRead.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRead.Location = new Point(12, 222);
            lblRead.Name = "lblRead";
            lblRead.Text = "Tellimuse tooted";
            // 
            // dgvRead
            // 
            dgvRead.AllowUserToAddRows = false;
            dgvRead.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRead.Location = new Point(12, 248);
            dgvRead.Name = "dgvRead";
            dgvRead.ReadOnly = true;
            dgvRead.RowHeadersVisible = false;
            dgvRead.Size = new Size(570, 180);
            // 
            // btnAvaArve
            // 
            btnAvaArve.Location = new Point(600, 12);
            btnAvaArve.Name = "btnAvaArve";
            btnAvaArve.Size = new Size(170, 34);
            btnAvaArve.Text = "Ava arve (PDF)";
            btnAvaArve.Click += btnAvaArve_Click;
            // 
            // btnTelliUuesti
            // 
            btnTelliUuesti.Location = new Point(600, 54);
            btnTelliUuesti.Name = "btnTelliUuesti";
            btnTelliUuesti.Size = new Size(170, 34);
            btnTelliUuesti.Text = "Telli uuesti";
            btnTelliUuesti.Click += btnTelliUuesti_Click;
            // 
            // TellimusedForm
            // 
            ClientSize = new Size(785, 442);
            Controls.Add(dgvTellimused);
            Controls.Add(lblRead);
            Controls.Add(dgvRead);
            Controls.Add(btnAvaArve);
            Controls.Add(btnTelliUuesti);
            Name = "TellimusedForm";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.LightBlue;
            Text = "Minu tellimused";
            ((System.ComponentModel.ISupportInitialize)dgvTellimused).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRead).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTellimused;
        private System.Windows.Forms.Label lblRead;
        private System.Windows.Forms.DataGridView dgvRead;
        private System.Windows.Forms.Button btnAvaArve;
        private System.Windows.Forms.Button btnTelliUuesti;
    }
}
