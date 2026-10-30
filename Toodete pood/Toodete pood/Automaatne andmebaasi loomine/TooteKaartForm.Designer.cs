namespace Automaatne_andmebaasi_loomine
{
    partial class TooteKaartForm
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
            pbPilt = new PictureBox();
            lblNimi = new Label();
            lblHind = new Label();
            lblVanaHind = new Label();
            lblLaos = new Label();
            lblKirjeldus = new Label();
            lblKogus = new Label();
            numKogus = new NumericUpDown();
            btnLisa = new Button();
            btnLemmik = new Button();
            ((System.ComponentModel.ISupportInitialize)pbPilt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKogus).BeginInit();
            SuspendLayout();
            // 
            // pbPilt
            // 
            pbPilt.BackColor = Color.White;
            pbPilt.BorderStyle = BorderStyle.FixedSingle;
            pbPilt.Location = new Point(20, 20);
            pbPilt.Name = "pbPilt";
            pbPilt.Size = new Size(260, 260);
            pbPilt.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            // lblNimi
            // 
            lblNimi.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblNimi.Location = new Point(300, 20);
            lblNimi.Name = "lblNimi";
            lblNimi.Size = new Size(270, 55);
            // 
            // lblHind
            // 
            lblHind.AutoSize = true;
            lblHind.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHind.Location = new Point(300, 78);
            lblHind.Name = "lblHind";
            // 
            // lblVanaHind
            // 
            lblVanaHind.AutoSize = true;
            lblVanaHind.Font = new Font("Segoe UI", 10F, FontStyle.Strikeout);
            lblVanaHind.ForeColor = Color.DimGray;
            lblVanaHind.Location = new Point(300, 112);
            lblVanaHind.Name = "lblVanaHind";
            // 
            // lblLaos
            // 
            lblLaos.AutoSize = true;
            lblLaos.Location = new Point(300, 138);
            lblLaos.Name = "lblLaos";
            // 
            // lblKirjeldus
            // 
            lblKirjeldus.Location = new Point(300, 165);
            lblKirjeldus.Name = "lblKirjeldus";
            lblKirjeldus.Size = new Size(270, 75);
            // 
            // lblKogus
            // 
            lblKogus.AutoSize = true;
            lblKogus.Location = new Point(300, 252);
            lblKogus.Name = "lblKogus";
            lblKogus.Text = "Kogus:";
            // 
            // numKogus
            // 
            numKogus.Location = new Point(360, 249);
            numKogus.Minimum = 1;
            numKogus.Name = "numKogus";
            numKogus.Size = new Size(70, 23);
            numKogus.Value = 1;
            // 
            // btnLisa
            // 
            btnLisa.Location = new Point(300, 285);
            btnLisa.Name = "btnLisa";
            btnLisa.Size = new Size(270, 36);
            btnLisa.Text = "Lisa korvi";
            btnLisa.Click += btnLisa_Click;
            // 
            // btnLemmik
            // 
            btnLemmik.Location = new Point(300, 328);
            btnLemmik.Name = "btnLemmik";
            btnLemmik.Size = new Size(270, 30);
            btnLemmik.Click += btnLemmik_Click;
            // 
            // TooteKaartForm
            // 
            AcceptButton = btnLisa;
            ClientSize = new Size(590, 375);
            Controls.Add(pbPilt);
            Controls.Add(lblNimi);
            Controls.Add(lblHind);
            Controls.Add(lblVanaHind);
            Controls.Add(lblLaos);
            Controls.Add(lblKirjeldus);
            Controls.Add(lblKogus);
            Controls.Add(numKogus);
            Controls.Add(btnLisa);
            Controls.Add(btnLemmik);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "TooteKaartForm";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.LightBlue;
            Text = "Toode";
            ((System.ComponentModel.ISupportInitialize)pbPilt).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKogus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pbPilt;
        private System.Windows.Forms.Label lblNimi;
        private System.Windows.Forms.Label lblHind;
        private System.Windows.Forms.Label lblVanaHind;
        private System.Windows.Forms.Label lblLaos;
        private System.Windows.Forms.Label lblKirjeldus;
        private System.Windows.Forms.Label lblKogus;
        private System.Windows.Forms.NumericUpDown numKogus;
        private System.Windows.Forms.Button btnLisa;
        private System.Windows.Forms.Button btnLemmik;
    }
}
