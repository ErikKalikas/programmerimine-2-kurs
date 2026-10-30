namespace Automaatne_andmebaasi_loomine
{
    partial class ArveForm
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
            listOstukorv = new ListBox();
            btnMiinus = new Button();
            btnPluss = new Button();
            btnEemalda = new Button();
            txtSooduskood = new TextBox();
            btnRakenda = new Button();
            lblKokku = new Label();
            comboTooted = new ComboBox();
            btnLisaKorvi = new Button();
            btnGenPDF = new Button();
            btnSaadaEmail = new Button();
            btnGmailValja = new Button();
            SuspendLayout();
            // 
            // listOstukorv
            // 
            listOstukorv.Location = new Point(20, 20);
            listOstukorv.Name = "listOstukorv";
            listOstukorv.Size = new Size(360, 260);
            // 
            // btnMiinus
            // 
            btnMiinus.Location = new Point(20, 288);
            btnMiinus.Name = "btnMiinus";
            btnMiinus.Size = new Size(40, 30);
            btnMiinus.Text = "−";
            btnMiinus.Click += btnMiinus_Click;
            // 
            // btnPluss
            // 
            btnPluss.Location = new Point(65, 288);
            btnPluss.Name = "btnPluss";
            btnPluss.Size = new Size(40, 30);
            btnPluss.Text = "+";
            btnPluss.Click += btnPluss_Click;
            // 
            // btnEemalda
            // 
            btnEemalda.Location = new Point(110, 288);
            btnEemalda.Name = "btnEemalda";
            btnEemalda.Size = new Size(120, 30);
            btnEemalda.Text = "Eemalda rida";
            btnEemalda.Click += btnEemalda_Click;
            // 
            // txtSooduskood
            // 
            txtSooduskood.Location = new Point(20, 332);
            txtSooduskood.Name = "txtSooduskood";
            txtSooduskood.PlaceholderText = "Sooduskood";
            txtSooduskood.Size = new Size(150, 23);
            // 
            // btnRakenda
            // 
            btnRakenda.Location = new Point(175, 330);
            btnRakenda.Name = "btnRakenda";
            btnRakenda.Size = new Size(90, 27);
            btnRakenda.Text = "Rakenda";
            btnRakenda.Click += btnRakenda_Click;
            // 
            // lblKokku
            // 
            lblKokku.AutoSize = true;
            lblKokku.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKokku.Location = new Point(20, 368);
            lblKokku.Name = "lblKokku";
            lblKokku.Text = "Kokku: 0,00 €";
            // 
            // comboTooted
            // 
            comboTooted.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTooted.Location = new Point(400, 20);
            comboTooted.Name = "comboTooted";
            comboTooted.Size = new Size(180, 23);
            // 
            // btnLisaKorvi
            // 
            btnLisaKorvi.Location = new Point(400, 55);
            btnLisaKorvi.Name = "btnLisaKorvi";
            btnLisaKorvi.Size = new Size(180, 30);
            btnLisaKorvi.Text = "Lisa toode korvi";
            btnLisaKorvi.Click += btnLisaKorvi_Click;
            // 
            // btnGenPDF
            // 
            btnGenPDF.Location = new Point(400, 110);
            btnGenPDF.Name = "btnGenPDF";
            btnGenPDF.Size = new Size(180, 30);
            btnGenPDF.Text = "Genereeri PDF";
            btnGenPDF.Click += btnGenPDF_Click;
            // 
            // btnSaadaEmail
            // 
            btnSaadaEmail.Location = new Point(400, 150);
            btnSaadaEmail.Name = "btnSaadaEmail";
            btnSaadaEmail.Size = new Size(180, 30);
            btnSaadaEmail.Text = "Saada emailiga";
            btnSaadaEmail.Click += btnSaadaEmail_Click;
            // 
            // btnGmailValja
            // 
            btnGmailValja.Location = new Point(400, 190);
            btnGmailValja.Name = "btnGmailValja";
            btnGmailValja.Size = new Size(180, 30);
            btnGmailValja.Text = "Vaheta Gmaili kontot";
            btnGmailValja.Click += btnGmailValja_Click;
            // 
            // ArveForm
            // 
            ClientSize = new Size(600, 420);
            Controls.Add(listOstukorv);
            Controls.Add(btnMiinus);
            Controls.Add(btnPluss);
            Controls.Add(btnEemalda);
            Controls.Add(txtSooduskood);
            Controls.Add(btnRakenda);
            Controls.Add(lblKokku);
            Controls.Add(comboTooted);
            Controls.Add(btnLisaKorvi);
            Controls.Add(btnGenPDF);
            Controls.Add(btnSaadaEmail);
            Controls.Add(btnGmailValja);
            Name = "ArveForm";
            BackColor = Color.LightBlue;
            Text = "Ostukorv";
            Load += ArveForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox listOstukorv;
        private System.Windows.Forms.Button btnMiinus;
        private System.Windows.Forms.Button btnPluss;
        private System.Windows.Forms.Button btnEemalda;
        private System.Windows.Forms.TextBox txtSooduskood;
        private System.Windows.Forms.Button btnRakenda;
        private System.Windows.Forms.Label lblKokku;
        private System.Windows.Forms.ComboBox comboTooted;
        private System.Windows.Forms.Button btnLisaKorvi;
        private System.Windows.Forms.Button btnGenPDF;
        private System.Windows.Forms.Button btnSaadaEmail;
        private System.Windows.Forms.Button btnGmailValja;
    }
}
