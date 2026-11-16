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
            pnlMenyy = new Panel();
            flpMenyy = new FlowLayoutPanel();
            pnlAll = new Panel();
            keeleValik = new KeeleValik();
            btnLogiValja = new UmarNupp();
            pnlBrand = new Panel();
            pnlLogo = new UmarPaneel();
            lblLogoTaht = new Label();
            lblPoeNimi = new Label();
            lblTere = new Label();
            pnlPais = new Panel();
            lblPealkiri = new Label();
            btnKorv = new UmarNupp();
            pnlPaisJoon = new Panel();
            pnlSisu = new Panel();
            btnPood = new UmarNupp();
            btnArve = new UmarNupp();
            btnTellimused = new UmarNupp();
            btnLemmikud = new UmarNupp();
            btnProfiil = new UmarNupp();
            btnTooted = new UmarNupp();
            btnKategooriad = new UmarNupp();
            btnKoikTellimused = new UmarNupp();
            btnAruanded = new UmarNupp();
            btnKasutajad = new UmarNupp();
            btnLogi = new UmarNupp();
            btnSeaded = new UmarNupp();
            pnlMenyy.SuspendLayout();
            pnlAll.SuspendLayout();
            pnlBrand.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlPais.SuspendLayout();
            SuspendLayout();
            //
            // pnlMenyy
            //
            pnlMenyy.BackColor = Color.FromArgb(17, 17, 17);
            pnlMenyy.Controls.Add(flpMenyy);
            pnlMenyy.Controls.Add(pnlAll);
            pnlMenyy.Controls.Add(pnlBrand);
            pnlMenyy.Dock = DockStyle.Left;
            pnlMenyy.Name = "pnlMenyy";
            pnlMenyy.Padding = new Padding(14, 0, 14, 14);
            pnlMenyy.Location = new Point(0, 0);
            pnlMenyy.Size = new Size(260, 800);
            //
            // flpMenyy
            //
            flpMenyy.AutoScroll = true;
            flpMenyy.Dock = DockStyle.Fill;
            flpMenyy.FlowDirection = FlowDirection.TopDown;
            flpMenyy.Name = "flpMenyy";
            flpMenyy.Padding = new Padding(0, 6, 0, 0);
            flpMenyy.WrapContents = false;
            //
            // pnlAll
            //
            pnlAll.Controls.Add(btnLogiValja);
            pnlAll.Controls.Add(keeleValik);
            pnlAll.Dock = DockStyle.Bottom;
            pnlAll.Location = new Point(14, 682);
            pnlAll.Size = new Size(232, 104);
            pnlAll.Name = "pnlAll";
            //
            // keeleValik
            //
            keeleValik.Location = new Point(0, 10);
            keeleValik.Name = "keeleValik";
            keeleValik.Tume = true;
            //
            // btnLogiValja
            //
            btnLogiValja.Dock = DockStyle.Bottom;
            btnLogiValja.Height = 44;
            btnLogiValja.Ikoon = "";
            btnLogiValja.Name = "btnLogiValja";
            btnLogiValja.Stiil = NupuStiil.Menyy;
            btnLogiValja.Text = "Logi välja";
            btnLogiValja.Click += btnLogiValja_Click;
            //
            // pnlBrand
            //
            pnlBrand.Controls.Add(lblTere);
            pnlBrand.Controls.Add(lblPoeNimi);
            pnlBrand.Controls.Add(pnlLogo);
            pnlBrand.Dock = DockStyle.Top;
            pnlBrand.Height = 96;
            pnlBrand.Name = "pnlBrand";
            //
            // pnlLogo
            //
            pnlLogo.AareVarv = Color.Empty;
            pnlLogo.BackColor = Color.FromArgb(220, 38, 38);
            pnlLogo.Controls.Add(lblLogoTaht);
            pnlLogo.Location = new Point(4, 26);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Raadius = 10;
            pnlLogo.Size = new Size(44, 44);
            //
            // lblLogoTaht
            //
            lblLogoTaht.BackColor = Color.Transparent;
            lblLogoTaht.Dock = DockStyle.Fill;
            lblLogoTaht.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogoTaht.ForeColor = Color.White;
            lblLogoTaht.Name = "lblLogoTaht";
            lblLogoTaht.Text = "T";
            lblLogoTaht.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblPoeNimi
            //
            lblPoeNimi.AutoEllipsis = true;
            lblPoeNimi.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPoeNimi.ForeColor = Color.White;
            lblPoeNimi.Location = new Point(58, 24);
            lblPoeNimi.Name = "lblPoeNimi";
            lblPoeNimi.Size = new Size(170, 26);
            lblPoeNimi.Text = "Toodete pood";
            //
            // lblTere
            //
            lblTere.AutoEllipsis = true;
            lblTere.Font = new Font("Segoe UI", 9F);
            lblTere.ForeColor = Color.FromArgb(160, 160, 168);
            lblTere.Location = new Point(58, 50);
            lblTere.Name = "lblTere";
            lblTere.Size = new Size(170, 20);
            //
            // pnlPais
            //
            pnlPais.BackColor = Color.White;
            pnlPais.Controls.Add(lblPealkiri);
            pnlPais.Controls.Add(btnKorv);
            pnlPais.Controls.Add(pnlPaisJoon);
            pnlPais.Dock = DockStyle.Top;
            pnlPais.Location = new Point(260, 0);
            pnlPais.Size = new Size(1020, 76);
            pnlPais.Name = "pnlPais";
            //
            // lblPealkiri
            //
            lblPealkiri.AutoEllipsis = true;
            lblPealkiri.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPealkiri.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPealkiri.Location = new Point(28, 18);
            lblPealkiri.Name = "lblPealkiri";
            lblPealkiri.Size = new Size(640, 40);
            //
            // btnKorv
            //
            btnKorv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKorv.Ikoon = "";
            btnKorv.Location = new Point(696, 16);
            btnKorv.Name = "btnKorv";
            btnKorv.Raadius = 22;
            btnKorv.Size = new Size(300, 44);
            btnKorv.Stiil = NupuStiil.Punane;
            btnKorv.Text = "Ostukorv";
            btnKorv.Click += btnArve_Click;
            //
            // pnlPaisJoon
            //
            pnlPaisJoon.BackColor = Color.FromArgb(222, 222, 228);
            pnlPaisJoon.Dock = DockStyle.Bottom;
            pnlPaisJoon.Height = 1;
            pnlPaisJoon.Name = "pnlPaisJoon";
            //
            // pnlSisu
            //
            pnlSisu.Dock = DockStyle.Fill;
            pnlSisu.Name = "pnlSisu";
            pnlSisu.Padding = new Padding(24);
            //
            // btnPood
            //
            btnPood.Ikoon = "";
            btnPood.Name = "btnPood";
            btnPood.Stiil = NupuStiil.Menyy;
            btnPood.Text = "Pood";
            btnPood.Click += btnPood_Click;
            //
            // btnArve
            //
            btnArve.Ikoon = "";
            btnArve.Name = "btnArve";
            btnArve.Stiil = NupuStiil.Menyy;
            btnArve.Text = "Ostukorv";
            btnArve.Click += btnArve_Click;
            //
            // btnTellimused
            //
            btnTellimused.Ikoon = "";
            btnTellimused.Name = "btnTellimused";
            btnTellimused.Stiil = NupuStiil.Menyy;
            btnTellimused.Text = "Minu tellimused";
            btnTellimused.Click += btnTellimused_Click;
            //
            // btnLemmikud
            //
            btnLemmikud.Ikoon = "";
            btnLemmikud.Name = "btnLemmikud";
            btnLemmikud.Stiil = NupuStiil.Menyy;
            btnLemmikud.Text = "Lemmikud";
            btnLemmikud.Click += btnLemmikud_Click;
            //
            // btnProfiil
            //
            btnProfiil.Ikoon = "";
            btnProfiil.Name = "btnProfiil";
            btnProfiil.Stiil = NupuStiil.Menyy;
            btnProfiil.Text = "Minu profiil";
            btnProfiil.Click += btnProfiil_Click;
            //
            // btnTooted
            //
            btnTooted.Ikoon = "";
            btnTooted.Name = "btnTooted";
            btnTooted.Stiil = NupuStiil.Menyy;
            btnTooted.Text = "Tootehaldus";
            btnTooted.Click += btnTooted_Click;
            //
            // btnKategooriad
            //
            btnKategooriad.Ikoon = "";
            btnKategooriad.Name = "btnKategooriad";
            btnKategooriad.Stiil = NupuStiil.Menyy;
            btnKategooriad.Text = "Kategooriad";
            btnKategooriad.Click += btnKategooriad_Click;
            //
            // btnKoikTellimused
            //
            btnKoikTellimused.Ikoon = "";
            btnKoikTellimused.Name = "btnKoikTellimused";
            btnKoikTellimused.Stiil = NupuStiil.Menyy;
            btnKoikTellimused.Text = "Kõik tellimused";
            btnKoikTellimused.Click += btnKoikTellimused_Click;
            //
            // btnAruanded
            //
            btnAruanded.Ikoon = "";
            btnAruanded.Name = "btnAruanded";
            btnAruanded.Stiil = NupuStiil.Menyy;
            btnAruanded.Text = "Müügiaruanne";
            btnAruanded.Click += btnAruanded_Click;
            //
            // btnKasutajad
            //
            btnKasutajad.Ikoon = "";
            btnKasutajad.Name = "btnKasutajad";
            btnKasutajad.Stiil = NupuStiil.Menyy;
            btnKasutajad.Text = "Kasutajad";
            btnKasutajad.Click += btnKasutajad_Click;
            //
            // btnLogi
            //
            btnLogi.Ikoon = "";
            btnLogi.Name = "btnLogi";
            btnLogi.Stiil = NupuStiil.Menyy;
            btnLogi.Text = "Tegevuste logi";
            btnLogi.Click += btnLogi_Click;
            //
            // btnSeaded
            //
            btnSeaded.Ikoon = "";
            btnSeaded.Name = "btnSeaded";
            btnSeaded.Stiil = NupuStiil.Menyy;
            btnSeaded.Text = "Poe seaded";
            btnSeaded.Click += btnSeaded_Click;
            //
            // FormMain
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1280, 800);
            Controls.Add(pnlSisu);
            Controls.Add(pnlPais);
            Controls.Add(pnlMenyy);
            MinimumSize = new Size(1000, 640);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pood";
            WindowState = FormWindowState.Maximized;
            pnlMenyy.ResumeLayout(false);
            pnlAll.ResumeLayout(false);
            pnlAll.PerformLayout();
            pnlBrand.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlPais.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMenyy;
        private System.Windows.Forms.FlowLayoutPanel flpMenyy;
        private System.Windows.Forms.Panel pnlAll;
        private KeeleValik keeleValik;
        private UmarNupp btnLogiValja;
        private System.Windows.Forms.Panel pnlBrand;
        private UmarPaneel pnlLogo;
        private System.Windows.Forms.Label lblLogoTaht;
        private System.Windows.Forms.Label lblPoeNimi;
        private System.Windows.Forms.Label lblTere;
        private System.Windows.Forms.Panel pnlPais;
        private System.Windows.Forms.Label lblPealkiri;
        private UmarNupp btnKorv;
        private System.Windows.Forms.Panel pnlPaisJoon;
        private System.Windows.Forms.Panel pnlSisu;
        private UmarNupp btnPood;
        private UmarNupp btnArve;
        private UmarNupp btnTellimused;
        private UmarNupp btnLemmikud;
        private UmarNupp btnProfiil;
        private UmarNupp btnTooted;
        private UmarNupp btnKategooriad;
        private UmarNupp btnKoikTellimused;
        private UmarNupp btnAruanded;
        private UmarNupp btnKasutajad;
        private UmarNupp btnLogi;
        private UmarNupp btnSeaded;
    }
}
