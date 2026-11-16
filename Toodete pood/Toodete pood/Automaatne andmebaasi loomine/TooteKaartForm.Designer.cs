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
            btnLisa = new UmarNupp();
            btnLemmik = new UmarNupp();
            ((System.ComponentModel.ISupportInitialize)pbPilt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKogus).BeginInit();
            SuspendLayout();
            // 
            // pbPilt
            // 
            pbPilt.BackColor = Color.White;
            pbPilt.Location = new Point(28, 28);
            pbPilt.Name = "pbPilt";
            pbPilt.Size = new Size(340, 340);
            pbPilt.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            // lblNimi
            // 
            lblNimi.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblNimi.Location = new Point(396, 28);
            lblNimi.Name = "lblNimi";
            lblNimi.Size = new Size(360, 70);
            // 
            // lblHind
            // 
            lblHind.AutoSize = true;
            lblHind.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblHind.Location = new Point(394, 100);
            lblHind.Name = "lblHind";
            // 
            // lblVanaHind
            // 
            lblVanaHind.AutoSize = true;
            lblVanaHind.Font = new Font("Segoe UI", 11F, FontStyle.Strikeout);
            lblVanaHind.ForeColor = Color.FromArgb(110, 110, 118);
            lblVanaHind.Location = new Point(398, 146);
            lblVanaHind.Name = "lblVanaHind";
            // 
            // lblLaos
            // 
            lblLaos.AutoSize = true;
            lblLaos.Font = new Font("Segoe UI Semibold", 10F);
            lblLaos.Location = new Point(398, 174);
            lblLaos.Name = "lblLaos";
            // 
            // lblKirjeldus
            // 
            lblKirjeldus.ForeColor = Color.FromArgb(70, 70, 76);
            lblKirjeldus.Location = new Point(398, 204);
            lblKirjeldus.Name = "lblKirjeldus";
            lblKirjeldus.Size = new Size(356, 80);
            // 
            // lblKogus
            // 
            lblKogus.AutoSize = true;
            lblKogus.Location = new Point(398, 297);
            lblKogus.Name = "lblKogus";
            lblKogus.Text = "Kogus:";
            // 
            // numKogus
            // 
            numKogus.Font = new Font("Segoe UI", 12F);
            numKogus.Location = new Point(470, 292);
            numKogus.Minimum = 1;
            numKogus.Name = "numKogus";
            numKogus.Size = new Size(90, 29);
            numKogus.Value = 1;
            // 
            // btnLisa
            // 
            btnLisa.Ikoon = "\uE7BF";
            btnLisa.Location = new Point(398, 336);
            btnLisa.Name = "btnLisa";
            btnLisa.Size = new Size(356, 48);
            btnLisa.Stiil = NupuStiil.Punane;
            btnLisa.Text = "Lisa korvi";
            btnLisa.Click += btnLisa_Click;
            // 
            // btnLemmik
            // 
            btnLemmik.Location = new Point(398, 392);
            btnLemmik.Name = "btnLemmik";
            btnLemmik.Size = new Size(356, 42);
            btnLemmik.Stiil = NupuStiil.Kontuur;
            btnLemmik.Click += btnLemmik_Click;
            // 
            // TooteKaartForm
            // 
            AcceptButton = btnLisa;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(784, 462);
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
            MinimizeBox = false;
            Name = "TooteKaartForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
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
        private UmarNupp btnLisa;
        private UmarNupp btnLemmik;
    }
}
