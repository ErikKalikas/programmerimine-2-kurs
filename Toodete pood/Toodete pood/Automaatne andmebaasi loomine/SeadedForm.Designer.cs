namespace Automaatne_andmebaasi_loomine
{
    partial class SeadedForm
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
            lblPoeNimi = new Label();
            txtPoeNimi = new TextBox();
            lblHyydlause = new Label();
            txtHyydlause = new TextBox();
            lblAadress = new Label();
            txtAadress = new TextBox();
            lblRegistrikood = new Label();
            txtRegistrikood = new TextBox();
            lblKmkrNr = new Label();
            txtKmkrNr = new TextBox();
            lblTelefon = new Label();
            txtTelefon = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblKm = new Label();
            numKm = new NumericUpDown();
            lblLogo = new Label();
            pbLogo = new PictureBox();
            btnLogo = new Button();
            btnEemaldaLogo = new Button();
            lblKirjaTeema = new Label();
            txtKirjaTeema = new TextBox();
            lblKirjaSisu = new Label();
            txtKirjaSisu = new TextBox();
            lblMall = new Label();
            btnSalvesta = new Button();
            ((System.ComponentModel.ISupportInitialize)numKm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // lblPoeNimi
            // 
            lblPoeNimi.AutoSize = true;
            lblPoeNimi.Location = new Point(20, 23);
            lblPoeNimi.Name = "lblPoeNimi";
            lblPoeNimi.Text = "Poe nimi:";
            // 
            // txtPoeNimi
            // 
            txtPoeNimi.Location = new Point(150, 20);
            txtPoeNimi.Name = "txtPoeNimi";
            txtPoeNimi.Size = new Size(400, 23);
            // 
            // lblHyydlause
            // 
            lblHyydlause.AutoSize = true;
            lblHyydlause.Location = new Point(20, 55);
            lblHyydlause.Name = "lblHyydlause";
            lblHyydlause.Text = "Hüüdlause:";
            // 
            // txtHyydlause
            // 
            txtHyydlause.Location = new Point(150, 52);
            txtHyydlause.Name = "txtHyydlause";
            txtHyydlause.Size = new Size(400, 23);
            // 
            // lblAadress
            // 
            lblAadress.AutoSize = true;
            lblAadress.Location = new Point(20, 87);
            lblAadress.Name = "lblAadress";
            lblAadress.Text = "Aadress:";
            // 
            // txtAadress
            // 
            txtAadress.Location = new Point(150, 84);
            txtAadress.Name = "txtAadress";
            txtAadress.Size = new Size(400, 23);
            // 
            // lblRegistrikood
            // 
            lblRegistrikood.AutoSize = true;
            lblRegistrikood.Location = new Point(20, 119);
            lblRegistrikood.Name = "lblRegistrikood";
            lblRegistrikood.Text = "Registrikood:";
            // 
            // txtRegistrikood
            // 
            txtRegistrikood.Location = new Point(150, 116);
            txtRegistrikood.Name = "txtRegistrikood";
            txtRegistrikood.Size = new Size(400, 23);
            // 
            // lblKmkrNr
            // 
            lblKmkrNr.AutoSize = true;
            lblKmkrNr.Location = new Point(20, 151);
            lblKmkrNr.Name = "lblKmkrNr";
            lblKmkrNr.Text = "KMKR nr:";
            // 
            // txtKmkrNr
            // 
            txtKmkrNr.Location = new Point(150, 148);
            txtKmkrNr.Name = "txtKmkrNr";
            txtKmkrNr.Size = new Size(400, 23);
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Location = new Point(20, 183);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Text = "Telefon:";
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(150, 180);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(400, 23);
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 215);
            lblEmail.Name = "lblEmail";
            lblEmail.Text = "E-post:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(150, 212);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 23);
            // 
            // lblKm
            // 
            lblKm.AutoSize = true;
            lblKm.Location = new Point(20, 247);
            lblKm.Name = "lblKm";
            lblKm.Text = "Käibemaks %:";
            // 
            // numKm
            // 
            numKm.Location = new Point(150, 244);
            numKm.Maximum = 50;
            numKm.Name = "numKm";
            numKm.Size = new Size(70, 23);
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Location = new Point(20, 284);
            lblLogo.Name = "lblLogo";
            lblLogo.Text = "Logo (arvel):";
            // 
            // pbLogo
            // 
            pbLogo.BackColor = Color.White;
            pbLogo.BorderStyle = BorderStyle.FixedSingle;
            pbLogo.Location = new Point(150, 281);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(120, 80);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            // btnLogo
            // 
            btnLogo.Location = new Point(285, 281);
            btnLogo.Name = "btnLogo";
            btnLogo.Size = new Size(130, 30);
            btnLogo.Text = "Vali logo...";
            btnLogo.Click += btnLogo_Click;
            // 
            // btnEemaldaLogo
            // 
            btnEemaldaLogo.Location = new Point(285, 316);
            btnEemaldaLogo.Name = "btnEemaldaLogo";
            btnEemaldaLogo.Size = new Size(130, 30);
            btnEemaldaLogo.Text = "Eemalda logo";
            btnEemaldaLogo.Click += btnEemaldaLogo_Click;
            // 
            // lblKirjaTeema
            // 
            lblKirjaTeema.AutoSize = true;
            lblKirjaTeema.Location = new Point(20, 379);
            lblKirjaTeema.Name = "lblKirjaTeema";
            lblKirjaTeema.Text = "Kirja teema:";
            // 
            // txtKirjaTeema
            // 
            txtKirjaTeema.Location = new Point(150, 376);
            txtKirjaTeema.Name = "txtKirjaTeema";
            txtKirjaTeema.Size = new Size(400, 23);
            // 
            // lblKirjaSisu
            // 
            lblKirjaSisu.AutoSize = true;
            lblKirjaSisu.Location = new Point(20, 411);
            lblKirjaSisu.Name = "lblKirjaSisu";
            lblKirjaSisu.Text = "Kirja sisu:";
            // 
            // txtKirjaSisu
            // 
            txtKirjaSisu.AcceptsReturn = true;
            txtKirjaSisu.Location = new Point(150, 408);
            txtKirjaSisu.Multiline = true;
            txtKirjaSisu.Name = "txtKirjaSisu";
            txtKirjaSisu.ScrollBars = ScrollBars.Vertical;
            txtKirjaSisu.Size = new Size(400, 110);
            // 
            // lblMall
            // 
            lblMall.ForeColor = Color.DimGray;
            lblMall.Location = new Point(150, 522);
            lblMall.Name = "lblMall";
            lblMall.Size = new Size(400, 32);
            lblMall.Text = "Kirjas asendatakse: {nr} arve number, {nimi} ostja nimi, {summa} summa, {pood} poe nimi";
            // 
            // btnSalvesta
            // 
            btnSalvesta.Location = new Point(150, 562);
            btnSalvesta.Name = "btnSalvesta";
            btnSalvesta.Size = new Size(200, 34);
            btnSalvesta.Text = "Salvesta";
            btnSalvesta.Click += btnSalvesta_Click;
            // 
            // SeadedForm
            // 
            ClientSize = new Size(580, 612);
            Controls.Add(lblPoeNimi);
            Controls.Add(txtPoeNimi);
            Controls.Add(lblHyydlause);
            Controls.Add(txtHyydlause);
            Controls.Add(lblAadress);
            Controls.Add(txtAadress);
            Controls.Add(lblRegistrikood);
            Controls.Add(txtRegistrikood);
            Controls.Add(lblKmkrNr);
            Controls.Add(txtKmkrNr);
            Controls.Add(lblTelefon);
            Controls.Add(txtTelefon);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblKm);
            Controls.Add(numKm);
            Controls.Add(lblLogo);
            Controls.Add(pbLogo);
            Controls.Add(btnLogo);
            Controls.Add(btnEemaldaLogo);
            Controls.Add(lblKirjaTeema);
            Controls.Add(txtKirjaTeema);
            Controls.Add(lblKirjaSisu);
            Controls.Add(txtKirjaSisu);
            Controls.Add(lblMall);
            Controls.Add(btnSalvesta);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SeadedForm";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.LightBlue;
            Text = "Poe seaded";
            ((System.ComponentModel.ISupportInitialize)numKm).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPoeNimi;
        private System.Windows.Forms.TextBox txtPoeNimi;
        private System.Windows.Forms.Label lblHyydlause;
        private System.Windows.Forms.TextBox txtHyydlause;
        private System.Windows.Forms.Label lblAadress;
        private System.Windows.Forms.TextBox txtAadress;
        private System.Windows.Forms.Label lblRegistrikood;
        private System.Windows.Forms.TextBox txtRegistrikood;
        private System.Windows.Forms.Label lblKmkrNr;
        private System.Windows.Forms.TextBox txtKmkrNr;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblKm;
        private System.Windows.Forms.NumericUpDown numKm;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnLogo;
        private System.Windows.Forms.Button btnEemaldaLogo;
        private System.Windows.Forms.Label lblKirjaTeema;
        private System.Windows.Forms.TextBox txtKirjaTeema;
        private System.Windows.Forms.Label lblKirjaSisu;
        private System.Windows.Forms.TextBox txtKirjaSisu;
        private System.Windows.Forms.Label lblMall;
        private System.Windows.Forms.Button btnSalvesta;
    }
}
