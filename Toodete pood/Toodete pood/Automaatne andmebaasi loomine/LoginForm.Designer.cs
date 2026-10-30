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
            btnAdmin = new Button();
            txtEmail = new TextBox();
            txtParool = new TextBox();
            btnLogin = new Button();
            btnTagasi = new Button();
            lblVeateade = new Label();
            SuspendLayout();
            // 
            // btnOstja
            // 
            btnOstja.Location = new Point(30, 30);
            btnOstja.Name = "btnOstja";
            btnOstja.Size = new Size(200, 45);
            btnOstja.TabIndex = 0;
            btnOstja.Text = "Sisene poodi";
            btnOstja.Click += btnOstja_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(30, 90);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(200, 30);
            btnAdmin.TabIndex = 1;
            btnAdmin.Text = "Logi sisse administraatorina";
            btnAdmin.Click += btnAdmin_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(30, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 2;
            txtEmail.Visible = false;
            // 
            // txtParool
            // 
            txtParool.Location = new Point(30, 70);
            txtParool.Name = "txtParool";
            txtParool.PasswordChar = '*';
            txtParool.PlaceholderText = "Parool";
            txtParool.Size = new Size(200, 23);
            txtParool.TabIndex = 3;
            txtParool.Visible = false;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(30, 110);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Logi sisse";
            btnLogin.Visible = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnTagasi
            // 
            btnTagasi.Location = new Point(30, 150);
            btnTagasi.Name = "btnTagasi";
            btnTagasi.Size = new Size(200, 30);
            btnTagasi.TabIndex = 5;
            btnTagasi.Text = "Tagasi";
            btnTagasi.Visible = false;
            btnTagasi.Click += btnTagasi_Click;
            // 
            // lblVeateade
            // 
            lblVeateade.AutoSize = true;
            lblVeateade.Location = new Point(30, 190);
            lblVeateade.Name = "lblVeateade";
            lblVeateade.Size = new Size(0, 15);
            // 
            // LoginForm
            // 
            ClientSize = new Size(260, 230);
            Controls.Add(btnOstja);
            Controls.Add(btnAdmin);
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
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtParool;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnTagasi;
        private System.Windows.Forms.Label lblVeateade;
    }
}
