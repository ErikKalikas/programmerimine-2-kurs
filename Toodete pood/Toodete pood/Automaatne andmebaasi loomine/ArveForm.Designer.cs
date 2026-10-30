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
            comboTooted = new ComboBox();
            btnLisaKorvi = new Button();
            btnEemalda = new Button();
            btnGenPDF = new Button();
            btnSaadaEmail = new Button();
            lblKokku = new Label();
            SuspendLayout();
            // 
            // listOstukorv
            // 
            listOstukorv.Location = new Point(20, 20);
            listOstukorv.Name = "listOstukorv";
            listOstukorv.Size = new Size(300, 300);
            // 
            // comboTooted
            // 
            comboTooted.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTooted.Location = new Point(350, 20);
            comboTooted.Name = "comboTooted";
            comboTooted.Size = new Size(180, 23);
            // 
            // btnLisaKorvi
            // 
            btnLisaKorvi.Location = new Point(350, 55);
            btnLisaKorvi.Name = "btnLisaKorvi";
            btnLisaKorvi.Size = new Size(180, 30);
            btnLisaKorvi.Text = "Lisa toode korvi";
            btnLisaKorvi.Click += btnLisaKorvi_Click;
            // 
            // btnEemalda
            // 
            btnEemalda.Location = new Point(350, 95);
            btnEemalda.Name = "btnEemalda";
            btnEemalda.Size = new Size(180, 30);
            btnEemalda.Text = "Eemalda korvist";
            btnEemalda.Click += btnEemalda_Click;
            // 
            // btnGenPDF
            // 
            btnGenPDF.Location = new Point(350, 145);
            btnGenPDF.Name = "btnGenPDF";
            btnGenPDF.Size = new Size(180, 30);
            btnGenPDF.Text = "Genereeri PDF";
            btnGenPDF.Click += btnGenPDF_Click;
            // 
            // btnSaadaEmail
            // 
            btnSaadaEmail.Location = new Point(350, 185);
            btnSaadaEmail.Name = "btnSaadaEmail";
            btnSaadaEmail.Size = new Size(180, 30);
            btnSaadaEmail.Text = "Saada emailiga";
            btnSaadaEmail.Click += btnSaadaEmail_Click;
            // 
            // lblKokku
            // 
            lblKokku.AutoSize = true;
            lblKokku.Location = new Point(20, 325);
            lblKokku.Name = "lblKokku";
            lblKokku.Text = "Kokku: 0 €";
            // 
            // ArveForm
            // 
            ClientSize = new Size(560, 350);
            Controls.Add(listOstukorv);
            Controls.Add(comboTooted);
            Controls.Add(btnLisaKorvi);
            Controls.Add(btnEemalda);
            Controls.Add(btnGenPDF);
            Controls.Add(btnSaadaEmail);
            Controls.Add(lblKokku);
            Name = "ArveForm";
            BackColor = Color.LightBlue;
            Text = "Arve";
            Load += ArveForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox listOstukorv;
        private System.Windows.Forms.ComboBox comboTooted;
        private System.Windows.Forms.Button btnLisaKorvi;
        private System.Windows.Forms.Button btnEemalda;
        private System.Windows.Forms.Button btnGenPDF;
        private System.Windows.Forms.Button btnSaadaEmail;
        private System.Windows.Forms.Label lblKokku;
    }
}
