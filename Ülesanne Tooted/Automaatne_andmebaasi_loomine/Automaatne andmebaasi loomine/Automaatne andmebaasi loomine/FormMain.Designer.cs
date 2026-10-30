namespace Automaatne_andmebaasi_loomine
{
    partial class FormMain
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
            btnTooted = new Button();
            btnPood = new Button();
            btnArve = new Button();
            btnKategooriad = new Button();
            SuspendLayout();
            // 
            // btnTooted
            // 
            btnTooted.Location = new Point(30, 30);
            btnTooted.Name = "btnTooted";
            btnTooted.Size = new Size(200, 40);
            btnTooted.Text = "Tootehaldus";
            btnTooted.Click += btnTooted_Click;
            // 
            // btnPood
            // 
            btnPood.Location = new Point(30, 80);
            btnPood.Name = "btnPood";
            btnPood.Size = new Size(200, 40);
            btnPood.Text = "Pood";
            btnPood.Click += btnPood_Click;
            // 
            // btnArve
            // 
            btnArve.Location = new Point(30, 130);
            btnArve.Name = "btnArve";
            btnArve.Size = new Size(200, 40);
            btnArve.Text = "Arve";
            btnArve.Click += btnArve_Click;
            // 
            // btnKategooriad
            // 
            btnKategooriad.Location = new Point(30, 180);
            btnKategooriad.Name = "btnKategooriad";
            btnKategooriad.Size = new Size(200, 40);
            btnKategooriad.Text = "Kategooriad";
            btnKategooriad.Click += btnKategooriad_Click;
            // 
            // FormMain
            // 
            ClientSize = new Size(300, 260);
            Controls.Add(btnTooted);
            Controls.Add(btnPood);
            Controls.Add(btnArve);
            Controls.Add(btnKategooriad);
            Name = "FormMain";
            BackColor = Color.LightBlue;
            Text = "Peamenüü";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnTooted;
        private System.Windows.Forms.Button btnPood;
        private System.Windows.Forms.Button btnArve;
        private System.Windows.Forms.Button btnKategooriad;
    }
}
