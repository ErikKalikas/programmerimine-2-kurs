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
            lblPealkiri = new Label();
            txtNimi = new TextBox();
            txtEmail = new TextBox();
            txtParool = new TextBox();
            txtParool2 = new TextBox();
            txtTelefon = new TextBox();
            txtAadress = new TextBox();
            btnRegistreeru = new UmarNupp();
            btnLoobu = new UmarNupp();
            lblViga = new Label();
            SuspendLayout();
            // 
            // lblPealkiri
            // 
            lblPealkiri.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPealkiri.Location = new Point(36, 26);
            lblPealkiri.Name = "lblPealkiri";
            lblPealkiri.Size = new Size(368, 44);
            lblPealkiri.Text = "Registreerumine";
            // 
            // txtNimi
            // 
            txtNimi.Font = new Font("Segoe UI", 12F);
            txtNimi.Location = new Point(36, 84);
            txtNimi.Name = "txtNimi";
            txtNimi.PlaceholderText = "Nimi *";
            txtNimi.Size = new Size(368, 29);
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(36, 126);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-post *";
            txtEmail.Size = new Size(368, 29);
            // 
            // txtParool
            // 
            txtParool.Font = new Font("Segoe UI", 12F);
            txtParool.Location = new Point(36, 168);
            txtParool.Name = "txtParool";
            txtParool.PlaceholderText = "Parool (vähemalt 6 märki) *";
            txtParool.Size = new Size(368, 29);
            txtParool.PasswordChar = '*';
            // 
            // txtParool2
            // 
            txtParool2.Font = new Font("Segoe UI", 12F);
            txtParool2.Location = new Point(36, 210);
            txtParool2.Name = "txtParool2";
            txtParool2.PlaceholderText = "Parool uuesti *";
            txtParool2.Size = new Size(368, 29);
            txtParool2.PasswordChar = '*';
            // 
            // txtTelefon
            // 
            txtTelefon.Font = new Font("Segoe UI", 12F);
            txtTelefon.Location = new Point(36, 252);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.PlaceholderText = "Telefon";
            txtTelefon.Size = new Size(368, 29);
            // 
            // txtAadress
            // 
            txtAadress.Font = new Font("Segoe UI", 12F);
            txtAadress.Location = new Point(36, 294);
            txtAadress.Name = "txtAadress";
            txtAadress.PlaceholderText = "Aadress";
            txtAadress.Size = new Size(368, 29);
            // 
            // btnRegistreeru
            // 
            btnRegistreeru.Location = new Point(36, 348);
            btnRegistreeru.Name = "btnRegistreeru";
            btnRegistreeru.Size = new Size(178, 46);
            btnRegistreeru.Stiil = NupuStiil.Punane;
            btnRegistreeru.Text = "Registreeru";
            btnRegistreeru.Click += btnRegistreeru_Click;
            // 
            // btnLoobu
            // 
            btnLoobu.Location = new Point(226, 348);
            btnLoobu.Name = "btnLoobu";
            btnLoobu.Size = new Size(178, 46);
            btnLoobu.Stiil = NupuStiil.Kontuur;
            btnLoobu.Text = "Loobu";
            btnLoobu.DialogResult = DialogResult.Cancel;
            // 
            // lblViga
            // 
            lblViga.ForeColor = Color.FromArgb(220, 38, 38);
            lblViga.Location = new Point(36, 406);
            lblViga.Name = "lblViga";
            lblViga.Size = new Size(368, 46);
            // 
            // RegistreerimineForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AcceptButton = btnRegistreeru;
            BackColor = Color.White;
            CancelButton = btnLoobu;
            ClientSize = new Size(440, 466);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Controls.Add(lblPealkiri);
            Controls.Add(txtNimi);
            Controls.Add(txtEmail);
            Controls.Add(txtParool);
            Controls.Add(txtParool2);
            Controls.Add(txtTelefon);
            Controls.Add(txtAadress);
            Controls.Add(btnRegistreeru);
            Controls.Add(btnLoobu);
            Controls.Add(lblViga);
            Name = "RegistreerimineForm";
            Text = "Registreerumine";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblPealkiri;
        private System.Windows.Forms.TextBox txtNimi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtParool;
        private System.Windows.Forms.TextBox txtParool2;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtAadress;
        private UmarNupp btnRegistreeru;
        private UmarNupp btnLoobu;
        private System.Windows.Forms.Label lblViga;
    }
}
