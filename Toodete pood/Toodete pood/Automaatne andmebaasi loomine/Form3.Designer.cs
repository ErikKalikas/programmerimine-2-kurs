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
            tabPood = new TabControl();
            btnOstukorv = new Button();
            SuspendLayout();
            // 
            // tabPood
            // 
            tabPood.Location = new Point(10, 10);
            tabPood.Name = "tabPood";
            tabPood.Size = new Size(900, 600);
            // 
            // btnOstukorv
            // 
            btnOstukorv.Location = new Point(10, 620);
            btnOstukorv.Name = "btnOstukorv";
            btnOstukorv.Size = new Size(300, 35);
            btnOstukorv.Text = "Ostukorv";
            btnOstukorv.Click += btnOstukorv_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 670);
            Controls.Add(tabPood);
            Controls.Add(btnOstukorv);
            Name = "Form3";
            BackColor = Color.LightBlue;
            Text = "Pood";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabPood;
        private System.Windows.Forms.Button btnOstukorv;
    }
}
