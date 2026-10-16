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
            btnLisaKorvi = new Button();
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
            // btnLisaKorvi
            // 
            btnLisaKorvi.Location = new Point(350, 20);
            btnLisaKorvi.Name = "btnLisaKorvi";
            btnLisaKorvi.Text = "Lisa toode korvi";
            btnLisaKorvi.Click += btnLisaKorvi_Click;
            // 
            // btnGenPDF
            // 
            btnGenPDF.Location = new Point(350, 70);
            btnGenPDF.Name = "btnGenPDF";
            btnGenPDF.Text = "Genereeri PDF";
            btnGenPDF.Click += btnGenPDF_Click;
            // 
            // btnSaadaEmail
            // 
            btnSaadaEmail.Location = new Point(350, 120);
            btnSaadaEmail.Name = "btnSaadaEmail";
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
            ClientSize = new Size(550, 350);
            Controls.Add(listOstukorv);
            Controls.Add(btnLisaKorvi);
            Controls.Add(btnGenPDF);
            Controls.Add(btnSaadaEmail);
            Controls.Add(lblKokku);
            Name = "ArveForm";
            BackColor = Color.LightBlue;
            Text = "Arve";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox listOstukorv;
        private System.Windows.Forms.Button btnLisaKorvi;
        private System.Windows.Forms.Button btnGenPDF;
        private System.Windows.Forms.Button btnSaadaEmail;
        private System.Windows.Forms.Label lblKokku;
    }
}
