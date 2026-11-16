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
            pnlAndmed = new UmarPaneel();
            lblAndmed = new Label();
            lblEmail = new Label();
            lblNimi = new Label();
            txtNimi = new TextBox();
            lblTelefon = new Label();
            txtTelefon = new TextBox();
            lblAadress = new Label();
            txtAadress = new TextBox();
            btnSalvesta = new UmarNupp();
            pnlParool = new UmarPaneel();
            lblParool = new Label();
            lblVanaParool = new Label();
            txtVanaParool = new TextBox();
            lblUusParool = new Label();
            txtUusParool = new TextBox();
            lblUusParool2 = new Label();
            txtUusParool2 = new TextBox();
            btnMuudaParool = new UmarNupp();
            pnlAndmed.SuspendLayout();
            pnlParool.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAndmed
            // 
            pnlAndmed.Controls.Add(lblAndmed);
            pnlAndmed.Controls.Add(lblEmail);
            pnlAndmed.Controls.Add(lblNimi);
            pnlAndmed.Controls.Add(txtNimi);
            pnlAndmed.Controls.Add(lblTelefon);
            pnlAndmed.Controls.Add(txtTelefon);
            pnlAndmed.Controls.Add(lblAadress);
            pnlAndmed.Controls.Add(txtAadress);
            pnlAndmed.Controls.Add(btnSalvesta);
            pnlAndmed.Margin = new Padding(0);
            pnlAndmed.Name = "pnlAndmed";
            pnlAndmed.Location = new Point(0, 0);
            pnlAndmed.Size = new Size(420, 360);
            // 
            // lblAndmed
            // 
            lblAndmed.AutoSize = true;
            lblAndmed.Font = new Font("Segoe UI Semibold", 13F);
            lblAndmed.Location = new Point(24, 20);
            lblAndmed.Name = "lblAndmed";
            lblAndmed.Text = "Minu andmed";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ForeColor = Color.FromArgb(110, 110, 118);
            lblEmail.Location = new Point(24, 54);
            lblEmail.Name = "lblEmail";
            // 
            // lblNimi
            // 
            lblNimi.AutoSize = true;
            lblNimi.ForeColor = Color.FromArgb(110, 110, 118);
            lblNimi.Location = new Point(24, 90);
            lblNimi.Name = "lblNimi";
            lblNimi.Text = "Nimi";
            // 
            // txtNimi
            // 
            txtNimi.Font = new Font("Segoe UI", 11F);
            txtNimi.Location = new Point(24, 112);
            txtNimi.Name = "txtNimi";
            txtNimi.PlaceholderText = "Nimi";
            txtNimi.Size = new Size(372, 27);
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.ForeColor = Color.FromArgb(110, 110, 118);
            lblTelefon.Location = new Point(24, 150);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Text = "Telefon";
            // 
            // txtTelefon
            // 
            txtTelefon.Font = new Font("Segoe UI", 11F);
            txtTelefon.Location = new Point(24, 172);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.PlaceholderText = "Telefon";
            txtTelefon.Size = new Size(372, 27);
            // 
            // lblAadress
            // 
            lblAadress.AutoSize = true;
            lblAadress.ForeColor = Color.FromArgb(110, 110, 118);
            lblAadress.Location = new Point(24, 210);
            lblAadress.Name = "lblAadress";
            lblAadress.Text = "Aadress";
            // 
            // txtAadress
            // 
            txtAadress.Font = new Font("Segoe UI", 11F);
            txtAadress.Location = new Point(24, 232);
            txtAadress.Name = "txtAadress";
            txtAadress.PlaceholderText = "Aadress";
            txtAadress.Size = new Size(372, 27);
            // 
            // btnSalvesta
            // 
            btnSalvesta.Ikoon = "\uE74E";
            btnSalvesta.Location = new Point(24, 286);
            btnSalvesta.Name = "btnSalvesta";
            btnSalvesta.Size = new Size(372, 46);
            btnSalvesta.Stiil = NupuStiil.Punane;
            btnSalvesta.Text = "Salvesta andmed";
            btnSalvesta.Click += btnSalvesta_Click;
            // 
            // pnlParool
            // 
            pnlParool.Controls.Add(lblParool);
            pnlParool.Controls.Add(lblVanaParool);
            pnlParool.Controls.Add(txtVanaParool);
            pnlParool.Controls.Add(lblUusParool);
            pnlParool.Controls.Add(txtUusParool);
            pnlParool.Controls.Add(lblUusParool2);
            pnlParool.Controls.Add(txtUusParool2);
            pnlParool.Controls.Add(btnMuudaParool);
            pnlParool.Margin = new Padding(0);
            pnlParool.Name = "pnlParool";
            pnlParool.Location = new Point(440, 0);
            pnlParool.Size = new Size(420, 360);
            // 
            // lblParool
            // 
            lblParool.AutoSize = true;
            lblParool.Font = new Font("Segoe UI Semibold", 13F);
            lblParool.Location = new Point(24, 20);
            lblParool.Name = "lblParool";
            lblParool.Text = "Parooli muutmine";
            // 
            // lblVanaParool
            // 
            lblVanaParool.AutoSize = true;
            lblVanaParool.ForeColor = Color.FromArgb(110, 110, 118);
            lblVanaParool.Location = new Point(24, 64);
            lblVanaParool.Name = "lblVanaParool";
            lblVanaParool.Text = "Praegune parool";
            // 
            // txtVanaParool
            // 
            txtVanaParool.Font = new Font("Segoe UI", 11F);
            txtVanaParool.Location = new Point(24, 86);
            txtVanaParool.Name = "txtVanaParool";
            txtVanaParool.PlaceholderText = "Praegune parool";
            txtVanaParool.Size = new Size(372, 27);
            txtVanaParool.PasswordChar = '*';
            // 
            // lblUusParool
            // 
            lblUusParool.AutoSize = true;
            lblUusParool.ForeColor = Color.FromArgb(110, 110, 118);
            lblUusParool.Location = new Point(24, 126);
            lblUusParool.Name = "lblUusParool";
            lblUusParool.Text = "Uus parool";
            // 
            // txtUusParool
            // 
            txtUusParool.Font = new Font("Segoe UI", 11F);
            txtUusParool.Location = new Point(24, 148);
            txtUusParool.Name = "txtUusParool";
            txtUusParool.PlaceholderText = "Uus parool (vähemalt 6 märki)";
            txtUusParool.Size = new Size(372, 27);
            txtUusParool.PasswordChar = '*';
            // 
            // lblUusParool2
            // 
            lblUusParool2.AutoSize = true;
            lblUusParool2.ForeColor = Color.FromArgb(110, 110, 118);
            lblUusParool2.Location = new Point(24, 188);
            lblUusParool2.Name = "lblUusParool2";
            lblUusParool2.Text = "Uus parool uuesti";
            // 
            // txtUusParool2
            // 
            txtUusParool2.Font = new Font("Segoe UI", 11F);
            txtUusParool2.Location = new Point(24, 210);
            txtUusParool2.Name = "txtUusParool2";
            txtUusParool2.PlaceholderText = "Uus parool uuesti";
            txtUusParool2.Size = new Size(372, 27);
            txtUusParool2.PasswordChar = '*';
            // 
            // btnMuudaParool
            // 
            btnMuudaParool.Ikoon = "\uE72E";
            btnMuudaParool.Location = new Point(24, 286);
            btnMuudaParool.Name = "btnMuudaParool";
            btnMuudaParool.Size = new Size(372, 46);
            btnMuudaParool.Text = "Muuda parool";
            btnMuudaParool.Click += btnMuudaParool_Click;
            // 
            // ProfiilForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 650);
            Controls.Add(pnlAndmed);
            Controls.Add(pnlParool);
            AutoScroll = true;
            Name = "ProfiilForm";
            Text = "Minu profiil";
            pnlAndmed.ResumeLayout(false);
            pnlAndmed.PerformLayout();
            pnlParool.ResumeLayout(false);
            pnlParool.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private UmarPaneel pnlAndmed;
        private System.Windows.Forms.Label lblAndmed;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblNimi;
        private System.Windows.Forms.TextBox txtNimi;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label lblAadress;
        private System.Windows.Forms.TextBox txtAadress;
        private UmarNupp btnSalvesta;
        private UmarPaneel pnlParool;
        private System.Windows.Forms.Label lblParool;
        private System.Windows.Forms.Label lblVanaParool;
        private System.Windows.Forms.TextBox txtVanaParool;
        private System.Windows.Forms.Label lblUusParool;
        private System.Windows.Forms.TextBox txtUusParool;
        private System.Windows.Forms.Label lblUusParool2;
        private System.Windows.Forms.TextBox txtUusParool2;
        private UmarNupp btnMuudaParool;
    }
}
