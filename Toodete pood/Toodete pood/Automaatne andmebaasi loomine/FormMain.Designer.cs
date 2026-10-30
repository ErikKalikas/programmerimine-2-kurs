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
            lblTere = new Label();
            btnPood = new Button();
            btnArve = new Button();
            btnTellimused = new Button();
            btnLemmikud = new Button();
            btnProfiil = new Button();
            btnTooted = new Button();
            btnKategooriad = new Button();
            btnLogiValja = new Button();
            btnKoikTellimused = new Button();
            btnAruanded = new Button();
            btnKasutajad = new Button();
            btnLogi = new Button();
            btnSeaded = new Button();
            SuspendLayout();
            // 
            // lblTere
            // 
            lblTere.AutoSize = true;
            lblTere.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTere.Location = new Point(30, 15);
            lblTere.Name = "lblTere";
            // 
            // btnPood
            // 
            btnPood.Name = "btnPood";
            btnPood.Size = new Size(220, 38);
            btnPood.Text = "Pood";
            btnPood.Click += btnPood_Click;
            // 
            // btnArve
            // 
            btnArve.Name = "btnArve";
            btnArve.Size = new Size(220, 38);
            btnArve.Text = "Ostukorv";
            btnArve.Click += btnArve_Click;
            // 
            // btnTellimused
            // 
            btnTellimused.Name = "btnTellimused";
            btnTellimused.Size = new Size(220, 38);
            btnTellimused.Text = "Minu tellimused";
            btnTellimused.Click += btnTellimused_Click;
            // 
            // btnLemmikud
            // 
            btnLemmikud.Name = "btnLemmikud";
            btnLemmikud.Size = new Size(220, 38);
            btnLemmikud.Text = "Lemmikud";
            btnLemmikud.Click += btnLemmikud_Click;
            // 
            // btnProfiil
            // 
            btnProfiil.Name = "btnProfiil";
            btnProfiil.Size = new Size(220, 38);
            btnProfiil.Text = "Minu profiil";
            btnProfiil.Click += btnProfiil_Click;
            // 
            // btnTooted
            // 
            btnTooted.Name = "btnTooted";
            btnTooted.Size = new Size(220, 38);
            btnTooted.Text = "Tootehaldus";
            btnTooted.Click += btnTooted_Click;
            // 
            // btnKategooriad
            // 
            btnKategooriad.Name = "btnKategooriad";
            btnKategooriad.Size = new Size(220, 38);
            btnKategooriad.Text = "Kategooriad";
            btnKategooriad.Click += btnKategooriad_Click;
            // 
            // btnLogiValja
            // 
            btnLogiValja.Name = "btnLogiValja";
            btnLogiValja.Size = new Size(220, 38);
            btnLogiValja.Text = "Logi välja";
            btnLogiValja.Click += btnLogiValja_Click;
            // 
            // btnKoikTellimused
            // 
            btnKoikTellimused.Name = "btnKoikTellimused";
            btnKoikTellimused.Size = new Size(220, 38);
            btnKoikTellimused.Text = "Kõik tellimused";
            btnKoikTellimused.Click += btnKoikTellimused_Click;
            // 
            // btnAruanded
            // 
            btnAruanded.Name = "btnAruanded";
            btnAruanded.Size = new Size(220, 38);
            btnAruanded.Text = "Müügiaruanne";
            btnAruanded.Click += btnAruanded_Click;
            // 
            // btnKasutajad
            // 
            btnKasutajad.Name = "btnKasutajad";
            btnKasutajad.Size = new Size(220, 38);
            btnKasutajad.Text = "Kasutajad";
            btnKasutajad.Click += btnKasutajad_Click;
            // 
            // btnLogi
            // 
            btnLogi.Name = "btnLogi";
            btnLogi.Size = new Size(220, 38);
            btnLogi.Text = "Tegevuste logi";
            btnLogi.Click += btnLogi_Click;
            // 
            // btnSeaded
            // 
            btnSeaded.Name = "btnSeaded";
            btnSeaded.Size = new Size(220, 38);
            btnSeaded.Text = "Poe seaded";
            btnSeaded.Click += btnSeaded_Click;
            // 
            // FormMain
            // 
            ClientSize = new Size(280, 300);
            Controls.Add(lblTere);
            Controls.Add(btnPood);
            Controls.Add(btnArve);
            Controls.Add(btnTellimused);
            Controls.Add(btnLemmikud);
            Controls.Add(btnProfiil);
            Controls.Add(btnTooted);
            Controls.Add(btnKategooriad);
            Controls.Add(btnLogiValja);
            Controls.Add(btnKoikTellimused);
            Controls.Add(btnAruanded);
            Controls.Add(btnKasutajad);
            Controls.Add(btnLogi);
            Controls.Add(btnSeaded);
            Name = "FormMain";
            BackColor = Color.LightBlue;
            Text = "Peamenüü";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTere;
        private System.Windows.Forms.Button btnPood;
        private System.Windows.Forms.Button btnArve;
        private System.Windows.Forms.Button btnTellimused;
        private System.Windows.Forms.Button btnLemmikud;
        private System.Windows.Forms.Button btnProfiil;
        private System.Windows.Forms.Button btnTooted;
        private System.Windows.Forms.Button btnKategooriad;
        private System.Windows.Forms.Button btnLogiValja;
        private System.Windows.Forms.Button btnKoikTellimused;
        private System.Windows.Forms.Button btnAruanded;
        private System.Windows.Forms.Button btnKasutajad;
        private System.Windows.Forms.Button btnLogi;
        private System.Windows.Forms.Button btnSeaded;
    }
}
