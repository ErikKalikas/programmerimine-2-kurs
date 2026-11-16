namespace Automaatne_andmebaasi_loomine
{
    partial class LoginForm
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
            pnlBrand = new Panel();
            pnlTriip = new Panel();
            lblBrand = new Label();
            lblBrandAlam = new Label();
            pnlParem = new Panel();
            keeleValik = new KeeleValik();
            pnlKaart = new UmarPaneel();
            lblPealkiri = new Label();
            lblAlam = new Label();
            btnOstja = new UmarNupp();
            btnKlient = new UmarNupp();
            btnRegistreeru = new UmarNupp();
            btnAdmin = new UmarNupp();
            txtEmail = new TextBox();
            txtParool = new TextBox();
            btnLogin = new UmarNupp();
            btnTagasi = new UmarNupp();
            lblVeateade = new Label();
            pnlBrand.SuspendLayout();
            pnlParem.SuspendLayout();
            pnlKaart.SuspendLayout();
            SuspendLayout();
            //
            // pnlBrand
            //
            pnlBrand.BackColor = Color.FromArgb(17, 17, 17);
            pnlBrand.Controls.Add(pnlTriip);
            pnlBrand.Controls.Add(lblBrand);
            pnlBrand.Controls.Add(lblBrandAlam);
            pnlBrand.Dock = DockStyle.Left;
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Width = 400;
            //
            // pnlTriip
            //
            pnlTriip.BackColor = Color.FromArgb(220, 38, 38);
            pnlTriip.Location = new Point(48, 220);
            pnlTriip.Name = "pnlTriip";
            pnlTriip.Size = new Size(56, 6);
            //
            // lblBrand
            //
            lblBrand.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(42, 236);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(340, 60);
            lblBrand.Text = "Toodete pood";
            //
            // lblBrandAlam
            //
            lblBrandAlam.Font = new Font("Segoe UI", 12F);
            lblBrandAlam.ForeColor = Color.FromArgb(170, 170, 178);
            lblBrandAlam.Location = new Point(48, 300);
            lblBrandAlam.Name = "lblBrandAlam";
            lblBrandAlam.Size = new Size(330, 60);
            //
            // pnlParem
            //
            pnlParem.Controls.Add(keeleValik);
            pnlParem.Controls.Add(pnlKaart);
            pnlParem.Dock = DockStyle.Fill;
            pnlParem.Location = new Point(400, 0);
            pnlParem.Size = new Size(600, 620);
            pnlParem.Name = "pnlParem";
            pnlParem.Resize += pnlParem_Resize;
            //
            // keeleValik
            //
            keeleValik.Location = new Point(400, 20);
            keeleValik.Name = "keeleValik";
            //
            // pnlKaart
            //
            pnlKaart.Controls.Add(lblPealkiri);
            pnlKaart.Controls.Add(lblAlam);
            pnlKaart.Controls.Add(btnOstja);
            pnlKaart.Controls.Add(btnKlient);
            pnlKaart.Controls.Add(btnRegistreeru);
            pnlKaart.Controls.Add(btnAdmin);
            pnlKaart.Controls.Add(txtEmail);
            pnlKaart.Controls.Add(txtParool);
            pnlKaart.Controls.Add(btnLogin);
            pnlKaart.Controls.Add(btnTagasi);
            pnlKaart.Controls.Add(lblVeateade);
            pnlKaart.Location = new Point(100, 90);
            pnlKaart.Name = "pnlKaart";
            pnlKaart.Raadius = 16;
            pnlKaart.Size = new Size(400, 420);
            //
            // lblPealkiri
            //
            lblPealkiri.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblPealkiri.Location = new Point(36, 32);
            lblPealkiri.Name = "lblPealkiri";
            lblPealkiri.Size = new Size(330, 44);
            lblPealkiri.Text = "Tere tulemast!";
            //
            // lblAlam
            //
            lblAlam.ForeColor = Color.FromArgb(110, 110, 118);
            lblAlam.Location = new Point(38, 78);
            lblAlam.Name = "lblAlam";
            lblAlam.Size = new Size(330, 24);
            lblAlam.Text = "Vali, kuidas soovid jätkata";
            //
            // btnOstja
            //
            btnOstja.Ikoon = "";
            btnOstja.Location = new Point(36, 124);
            btnOstja.Name = "btnOstja";
            btnOstja.Size = new Size(328, 50);
            btnOstja.Stiil = NupuStiil.Punane;
            btnOstja.TabIndex = 0;
            btnOstja.Text = "Sisene poodi";
            btnOstja.Click += btnOstja_Click;
            //
            // btnKlient
            //
            btnKlient.Location = new Point(36, 186);
            btnKlient.Name = "btnKlient";
            btnKlient.Size = new Size(328, 46);
            btnKlient.TabIndex = 1;
            btnKlient.Text = "Logi sisse";
            btnKlient.Click += btnKlient_Click;
            //
            // btnRegistreeru
            //
            btnRegistreeru.Location = new Point(36, 242);
            btnRegistreeru.Name = "btnRegistreeru";
            btnRegistreeru.Size = new Size(328, 46);
            btnRegistreeru.Stiil = NupuStiil.Kontuur;
            btnRegistreeru.TabIndex = 2;
            btnRegistreeru.Text = "Registreeru";
            btnRegistreeru.Click += btnRegistreeru_Click;
            //
            // btnAdmin
            //
            btnAdmin.Font = new Font("Segoe UI", 9F);
            btnAdmin.Location = new Point(36, 330);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(328, 38);
            btnAdmin.Stiil = NupuStiil.Hall;
            btnAdmin.TabIndex = 3;
            btnAdmin.Text = "Logi sisse administraatorina";
            btnAdmin.Click += btnAdmin_Click;
            //
            // txtEmail
            //
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(36, 124);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-post";
            txtEmail.Size = new Size(328, 29);
            txtEmail.TabIndex = 4;
            txtEmail.Visible = false;
            //
            // txtParool
            //
            txtParool.Font = new Font("Segoe UI", 12F);
            txtParool.Location = new Point(36, 170);
            txtParool.Name = "txtParool";
            txtParool.PasswordChar = '*';
            txtParool.PlaceholderText = "Parool";
            txtParool.Size = new Size(328, 29);
            txtParool.TabIndex = 5;
            txtParool.Visible = false;
            //
            // btnLogin
            //
            btnLogin.Location = new Point(36, 222);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(328, 48);
            btnLogin.Stiil = NupuStiil.Punane;
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Logi sisse";
            btnLogin.Visible = false;
            btnLogin.Click += btnLogin_Click;
            //
            // btnTagasi
            //
            btnTagasi.Location = new Point(36, 280);
            btnTagasi.Name = "btnTagasi";
            btnTagasi.Size = new Size(328, 44);
            btnTagasi.Stiil = NupuStiil.Kontuur;
            btnTagasi.TabIndex = 7;
            btnTagasi.Text = "Tagasi";
            btnTagasi.Visible = false;
            btnTagasi.Click += btnTagasi_Click;
            //
            // lblVeateade
            //
            lblVeateade.ForeColor = Color.FromArgb(220, 38, 38);
            lblVeateade.Location = new Point(36, 334);
            lblVeateade.Name = "lblVeateade";
            lblVeateade.Size = new Size(328, 44);
            //
            // LoginForm
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 620);
            Controls.Add(pnlParem);
            Controls.Add(pnlBrand);
            MinimumSize = new Size(900, 600);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tere tulemast";
            pnlBrand.ResumeLayout(false);
            pnlParem.ResumeLayout(false);
            pnlParem.PerformLayout();
            pnlKaart.ResumeLayout(false);
            pnlKaart.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Panel pnlTriip;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandAlam;
        private System.Windows.Forms.Panel pnlParem;
        private KeeleValik keeleValik;
        private UmarPaneel pnlKaart;
        private System.Windows.Forms.Label lblPealkiri;
        private System.Windows.Forms.Label lblAlam;
        private UmarNupp btnOstja;
        private UmarNupp btnKlient;
        private UmarNupp btnRegistreeru;
        private UmarNupp btnAdmin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtParool;
        private UmarNupp btnLogin;
        private UmarNupp btnTagasi;
        private System.Windows.Forms.Label lblVeateade;
    }
}
