namespace Automaatne_andmebaasi_loomine
{
    partial class Form3
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
            pnlYlal = new Panel();
            txtOtsi = new TextBox();
            cmbSorteeri = new ComboBox();
            lblLeitud = new Label();
            flpKategooriad = new FlowLayoutPanel();
            flpTooted = new FlowLayoutPanel();
            pnlYlal.SuspendLayout();
            SuspendLayout();
            //
            // pnlYlal
            //
            pnlYlal.Controls.Add(txtOtsi);
            pnlYlal.Controls.Add(cmbSorteeri);
            pnlYlal.Controls.Add(lblLeitud);
            pnlYlal.Dock = DockStyle.Top;
            pnlYlal.Location = new Point(0, 0);
            pnlYlal.Name = "pnlYlal";
            pnlYlal.Size = new Size(1000, 52);
            //
            // txtOtsi
            //
            txtOtsi.Font = new Font("Segoe UI", 12F);
            txtOtsi.Location = new Point(0, 6);
            txtOtsi.Name = "txtOtsi";
            txtOtsi.PlaceholderText = "🔍 Otsi toodet...";
            txtOtsi.Size = new Size(380, 29);
            txtOtsi.TextChanged += txtOtsi_TextChanged;
            //
            // cmbSorteeri
            //
            cmbSorteeri.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSorteeri.Font = new Font("Segoe UI", 12F);
            cmbSorteeri.Location = new Point(396, 6);
            cmbSorteeri.Name = "cmbSorteeri";
            cmbSorteeri.Size = new Size(230, 29);
            cmbSorteeri.SelectedIndexChanged += cmbSorteeri_SelectedIndexChanged;
            //
            // lblLeitud
            //
            lblLeitud.AutoSize = true;
            lblLeitud.ForeColor = Color.FromArgb(110, 110, 118);
            lblLeitud.Location = new Point(644, 12);
            lblLeitud.Name = "lblLeitud";
            //
            // flpKategooriad
            //
            flpKategooriad.AutoSize = true;
            flpKategooriad.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpKategooriad.Dock = DockStyle.Top;
            flpKategooriad.Location = new Point(0, 52);
            flpKategooriad.Name = "flpKategooriad";
            flpKategooriad.Padding = new Padding(0, 0, 0, 10);
            flpKategooriad.Size = new Size(1000, 50);
            //
            // flpTooted
            //
            flpTooted.AutoScroll = true;
            flpTooted.Dock = DockStyle.Fill;
            flpTooted.Location = new Point(0, 102);
            flpTooted.Name = "flpTooted";
            flpTooted.Padding = new Padding(0, 4, 0, 0);
            flpTooted.Size = new Size(1000, 548);
            //
            // Form3
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 650);
            Controls.Add(flpTooted);
            Controls.Add(flpKategooriad);
            Controls.Add(pnlYlal);
            Name = "Form3";
            Text = "Pood";
            pnlYlal.ResumeLayout(false);
            pnlYlal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlYlal;
        private System.Windows.Forms.TextBox txtOtsi;
        private System.Windows.Forms.ComboBox cmbSorteeri;
        private System.Windows.Forms.Label lblLeitud;
        private System.Windows.Forms.FlowLayoutPanel flpKategooriad;
        private System.Windows.Forms.FlowLayoutPanel flpTooted;
    }
}
