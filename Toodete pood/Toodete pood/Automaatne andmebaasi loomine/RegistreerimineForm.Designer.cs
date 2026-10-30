namespace Automaatne_andmebaasi_loomine
{
    partial class RegistreerimineForm
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
            txtNimi = new TextBox();
            txtEmail = new TextBox();
            txtParool = new TextBox();
            txtParool2 = new TextBox();
            txtTelefon = new TextBox();
            txtAadress = new TextBox();
            btnRegistreeru = new Button();
            btnLoobu = new Button();
            lblViga = new Label();
            SuspendLayout();
            // 
            // txtNimi
            // 
            txtNimi.Location = new Point(30, 25);
            txtNimi.Name = "txtNimi";
            txtNimi.PlaceholderText = "Nimi *";
            txtNimi.Size = new Size(240, 23);
            txtNimi.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(30, 60);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-post *";
            txtEmail.Size = new Size(240, 23);
            txtEmail.TabIndex = 1;
            // 
            // txtParool
            // 
            txtParool.Location = new Point(30, 95);
            txtParool.Name = "txtParool";
            txtParool.PasswordChar = '*';
            txtParool.PlaceholderText = "Parool (vähemalt 6 märki) *";
            txtParool.Size = new Size(240, 23);
            txtParool.TabIndex = 2;
            // 
            // txtParool2
            // 
            txtParool2.Location = new Point(30, 130);
            txtParool2.Name = "txtParool2";
            txtParool2.PasswordChar = '*';
            txtParool2.PlaceholderText = "Parool uuesti *";
            txtParool2.Size = new Size(240, 23);
            txtParool2.TabIndex = 3;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(30, 165);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.PlaceholderText = "Telefon";
            txtTelefon.Size = new Size(240, 23);
            txtTelefon.TabIndex = 4;
            // 
            // txtAadress
            // 
            txtAadress.Location = new Point(30, 200);
            txtAadress.Name = "txtAadress";
            txtAadress.PlaceholderText = "Aadress";
            txtAadress.Size = new Size(240, 23);
            txtAadress.TabIndex = 5;
            // 
            // btnRegistreeru
            // 
            btnRegistreeru.Location = new Point(30, 240);
            btnRegistreeru.Name = "btnRegistreeru";
            btnRegistreeru.Size = new Size(115, 30);
            btnRegistreeru.TabIndex = 6;
            btnRegistreeru.Text = "Registreeru";
            btnRegistreeru.Click += btnRegistreeru_Click;
            // 
            // btnLoobu
            // 
            btnLoobu.DialogResult = DialogResult.Cancel;
            btnLoobu.Location = new Point(155, 240);
            btnLoobu.Name = "btnLoobu";
            btnLoobu.Size = new Size(115, 30);
            btnLoobu.TabIndex = 7;
            btnLoobu.Text = "Loobu";
            // 
            // lblViga
            // 
            lblViga.Location = new Point(30, 280);
            lblViga.Name = "lblViga";
            lblViga.Size = new Size(240, 40);
            lblViga.ForeColor = Color.DarkRed;
            // 
            // RegistreerimineForm
            // 
            AcceptButton = btnRegistreeru;
            CancelButton = btnLoobu;
            ClientSize = new Size(300, 330);
            Controls.Add(txtNimi);
            Controls.Add(txtEmail);
            Controls.Add(txtParool);
            Controls.Add(txtParool2);
            Controls.Add(txtTelefon);
            Controls.Add(txtAadress);
            Controls.Add(btnRegistreeru);
            Controls.Add(btnLoobu);
            Controls.Add(lblViga);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RegistreerimineForm";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.LightBlue;
            Text = "Registreerumine";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtNimi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtParool;
        private System.Windows.Forms.TextBox txtParool2;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtAadress;
        private System.Windows.Forms.Button btnRegistreeru;
        private System.Windows.Forms.Button btnLoobu;
        private System.Windows.Forms.Label lblViga;
    }
}
