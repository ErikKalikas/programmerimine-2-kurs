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
            btnOstja = new Button();
            btnKlient = new Button();
            btnRegistreeru = new Button();
            btnAdmin = new Button();
            lblPealkiri = new Label();
            txtEmail = new TextBox();
            txtParool = new TextBox();
            btnLogin = new Button();
            btnTagasi = new Button();
            lblVeateade = new Label();
            SuspendLayout();
            // 
            // btnOstja
            // 
            btnOstja.Location = new Point(30, 25);
            btnOstja.Name = "btnOstja";
            btnOstja.Size = new Size(220, 45);
            btnOstja.TabIndex = 0;
            btnOstja.Text = "Sisene poodi";
            btnOstja.Click += btnOstja_Click;
            // 
            // btnKlient
            // 
            btnKlient.Location = new Point(30, 80);
            btnKlient.Name = "btnKlient";
            btnKlient.Size = new Size(220, 30);
            btnKlient.TabIndex = 1;
            btnKlient.Text = "Logi sisse";
            btnKlient.Click += btnKlient_Click;
            // 
            // btnRegistreeru
            // 
            btnRegistreeru.Location = new Point(30, 115);
            btnRegistreeru.Name = "btnRegistreeru";
            btnRegistreeru.Size = new Size(220, 30);
            btnRegistreeru.TabIndex = 2;
            btnRegistreeru.Text = "Registreeru";
            btnRegistreeru.Click += btnRegistreeru_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(30, 165);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(220, 28);
            btnAdmin.TabIndex = 3;
            btnAdmin.Text = "Logi sisse administraatorina";
            btnAdmin.Click += btnAdmin_Click;
            // 
            // lblPealkiri
            // 
            lblPealkiri.AutoSize = true;
            lblPealkiri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPealkiri.Location = new Point(30, 8);
            lblPealkiri.Name = "lblPealkiri";
            lblPealkiri.Visible = false;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(30, 35);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(220, 23);
            txtEmail.TabIndex = 4;
            txtEmail.Visible = false;
            // 
            // txtParool
            // 
            txtParool.Location = new Point(30, 70);
            txtParool.Name = "txtParool";
            txtParool.PasswordChar = '*';
            txtParool.PlaceholderText = "Parool";
            txtParool.Size = new Size(220, 23);
            txtParool.TabIndex = 5;
            txtParool.Visible = false;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(30, 110);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(220, 30);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Logi sisse";
            btnLogin.Visible = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnTagasi
            // 
            btnTagasi.Location = new Point(30, 150);
            btnTagasi.Name = "btnTagasi";
            btnTagasi.Size = new Size(220, 30);
            btnTagasi.TabIndex = 7;
            btnTagasi.Text = "Tagasi";
            btnTagasi.Visible = false;
            btnTagasi.Click += btnTagasi_Click;
            // 
            // lblVeateade
            // 
            lblVeateade.AutoSize = true;
            lblVeateade.Location = new Point(30, 200);
            lblVeateade.Name = "lblVeateade";
            lblVeateade.Size = new Size(0, 15);
            // 
            // LoginForm
            // 
            ClientSize = new Size(280, 235);
            Controls.Add(btnOstja);
            Controls.Add(btnKlient);
            Controls.Add(btnRegistreeru);
            Controls.Add(btnAdmin);
            Controls.Add(lblPealkiri);
            Controls.Add(txtEmail);
            Controls.Add(txtParool);
            Controls.Add(btnLogin);
            Controls.Add(btnTagasi);
            Controls.Add(lblVeateade);
            Name = "LoginForm";
            BackColor = Color.LightBlue;
            Text = "Tere tulemast";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnOstja;
        private System.Windows.Forms.Button btnKlient;
        private System.Windows.Forms.Button btnRegistreeru;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Label lblPealkiri;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtParool;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnTagasi;
        private System.Windows.Forms.Label lblVeateade;
    }
}
