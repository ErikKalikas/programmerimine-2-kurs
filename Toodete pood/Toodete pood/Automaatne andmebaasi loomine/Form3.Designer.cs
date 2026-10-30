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
            txtOtsi = new TextBox();
            cmbSorteeri = new ComboBox();
            tabPood = new TabControl();
            btnOstukorv = new Button();
            SuspendLayout();
            // 
            // txtOtsi
            // 
            txtOtsi.Location = new Point(10, 12);
            txtOtsi.Name = "txtOtsi";
            txtOtsi.PlaceholderText = "🔍 Otsi toodet...";
            txtOtsi.Size = new Size(260, 23);
            txtOtsi.TextChanged += txtOtsi_TextChanged;
            // 
            // cmbSorteeri
            // 
            cmbSorteeri.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSorteeri.Location = new Point(285, 12);
            cmbSorteeri.Name = "cmbSorteeri";
            cmbSorteeri.Size = new Size(200, 23);
            cmbSorteeri.SelectedIndexChanged += cmbSorteeri_SelectedIndexChanged;
            // 
            // tabPood
            // 
            tabPood.Location = new Point(10, 45);
            tabPood.Name = "tabPood";
            tabPood.Size = new Size(900, 570);
            // 
            // btnOstukorv
            // 
            btnOstukorv.Location = new Point(10, 625);
            btnOstukorv.Name = "btnOstukorv";
            btnOstukorv.Size = new Size(320, 35);
            btnOstukorv.Text = "Ostukorv";
            btnOstukorv.Click += btnOstukorv_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 670);
            Controls.Add(txtOtsi);
            Controls.Add(cmbSorteeri);
            Controls.Add(tabPood);
            Controls.Add(btnOstukorv);
            Name = "Form3";
            BackColor = Color.LightBlue;
            Text = "Pood";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtOtsi;
        private System.Windows.Forms.ComboBox cmbSorteeri;
        private System.Windows.Forms.TabControl tabPood;
        private System.Windows.Forms.Button btnOstukorv;
    }
}
