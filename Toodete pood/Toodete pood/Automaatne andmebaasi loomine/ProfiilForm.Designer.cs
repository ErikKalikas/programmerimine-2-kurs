namespace Automaatne_andmebaasi_loomine
{
    partial class ProfiilForm
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
            lblEmail = new Label();
            txtNimi = new TextBox();
            txtTelefon = new TextBox();
            txtAadress = new TextBox();
            btnSalvesta = new Button();
            lblParool = new Label();
            txtVanaParool = new TextBox();
            txtUusParool = new TextBox();
            txtUusParool2 = new TextBox();
            btnMuudaParool = new Button();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(30, 15);
            lblEmail.Name = "lblEmail";
            // 
            // txtNimi
            // 
            txtNimi.Location = new Point(30, 50);
            txtNimi.Name = "txtNimi";
            txtNimi.PlaceholderText = "Nimi";
            txtNimi.Size = new Size(260, 23);
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(30, 85);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.PlaceholderText = "Telefon";
            txtTelefon.Size = new Size(260, 23);
            // 
            // txtAadress
            // 
            txtAadress.Location = new Point(30, 120);
            txtAadress.Name = "txtAadress";
            txtAadress.PlaceholderText = "Aadress";
            txtAadress.Size = new Size(260, 23);
            // 
            // btnSalvesta
            // 
            btnSalvesta.Location = new Point(30, 155);
            btnSalvesta.Name = "btnSalvesta";
            btnSalvesta.Size = new Size(260, 30);
            btnSalvesta.Text = "Salvesta andmed";
            btnSalvesta.Click += btnSalvesta_Click;
            // 
            // lblParool
            // 
            lblParool.AutoSize = true;
            lblParool.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblParool.Location = new Point(30, 205);
            lblParool.Name = "lblParool";
            lblParool.Text = "Parooli muutmine";
            // 
            // txtVanaParool
            // 
            txtVanaParool.Location = new Point(30, 235);
            txtVanaParool.Name = "txtVanaParool";
            txtVanaParool.PasswordChar = '*';
            txtVanaParool.PlaceholderText = "Praegune parool";
            txtVanaParool.Size = new Size(260, 23);
            // 
            // txtUusParool
            // 
            txtUusParool.Location = new Point(30, 270);
            txtUusParool.Name = "txtUusParool";
            txtUusParool.PasswordChar = '*';
            txtUusParool.PlaceholderText = "Uus parool (vähemalt 6 märki)";
            txtUusParool.Size = new Size(260, 23);
            // 
            // txtUusParool2
            // 
            txtUusParool2.Location = new Point(30, 305);
            txtUusParool2.Name = "txtUusParool2";
            txtUusParool2.PasswordChar = '*';
            txtUusParool2.PlaceholderText = "Uus parool uuesti";
            txtUusParool2.Size = new Size(260, 23);
            // 
            // btnMuudaParool
            // 
            btnMuudaParool.Location = new Point(30, 340);
            btnMuudaParool.Name = "btnMuudaParool";
            btnMuudaParool.Size = new Size(260, 30);
            btnMuudaParool.Text = "Muuda parool";
            btnMuudaParool.Click += btnMuudaParool_Click;
            // 
            // ProfiilForm
            // 
            ClientSize = new Size(320, 390);
            Controls.Add(lblEmail);
            Controls.Add(txtNimi);
            Controls.Add(txtTelefon);
            Controls.Add(txtAadress);
            Controls.Add(btnSalvesta);
            Controls.Add(lblParool);
            Controls.Add(txtVanaParool);
            Controls.Add(txtUusParool);
            Controls.Add(txtUusParool2);
            Controls.Add(btnMuudaParool);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ProfiilForm";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.LightBlue;
            Text = "Minu profiil";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtNimi;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtAadress;
        private System.Windows.Forms.Button btnSalvesta;
        private System.Windows.Forms.Label lblParool;
        private System.Windows.Forms.TextBox txtVanaParool;
        private System.Windows.Forms.TextBox txtUusParool;
        private System.Windows.Forms.TextBox txtUusParool2;
        private System.Windows.Forms.Button btnMuudaParool;
    }
}
