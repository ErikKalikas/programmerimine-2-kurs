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
            txtEmail = new TextBox();
            txtParool = new TextBox();
            btnLogin = new Button();
            lblVeateade = new Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(30, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 0;
            // 
            // txtParool
            // 
            txtParool.Location = new Point(30, 70);
            txtParool.Name = "txtParool";
            txtParool.PasswordChar = '*';
            txtParool.PlaceholderText = "Parool";
            txtParool.Size = new Size(200, 23);
            txtParool.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(30, 110);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 30);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Logi sisse";
            btnLogin.Click += btnLogin_Click;
            // 
            // lblVeateade
            // 
            lblVeateade.AutoSize = true;
            lblVeateade.Location = new Point(30, 150);
            lblVeateade.Name = "lblVeateade";
            lblVeateade.Size = new Size(0, 15);
            // 
            // LoginForm
            // 
            ClientSize = new Size(260, 190);
            Controls.Add(txtEmail);
            Controls.Add(txtParool);
            Controls.Add(btnLogin);
            Controls.Add(lblVeateade);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtParool;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblVeateade;
    }
}
