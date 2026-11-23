namespace Automaatne_andmebaasi_loomine
{
    partial class Form2
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
            cmbFilter = new ComboBox();
            chkOtsakorral = new CheckBox();
            lblHoiatus = new Label();
            tlp = new TableLayoutPanel();
            pnlTabel = new UmarPaneel();
            dataGridViewTooted = new DataGridView();
            pnlVorm = new UmarPaneel();
            lblVorm = new Label();
            picturePilt = new PictureBox();
            btnValiPilt = new UmarNupp();
            lblNimetus = new Label();
            txtNimetus = new TextBox();
            lblKogus = new Label();
            txtKogus = new TextBox();
            lblHind = new Label();
            txtHind = new TextBox();
            lblKategooria = new Label();
            comboKategooria = new ComboBox();
            lblSoodusHind = new Label();
            txtSoodusHind = new TextBox();
            chkSoodusKuni = new CheckBox();
            dtpSoodusKuni = new DateTimePicker();
            lblKirjeldus = new Label();
            txtKirjeldus = new TextBox();
            lblTootja = new Label();
            txtTootja = new TextBox();
            btnLisa = new UmarNupp();
            btnUuenda = new UmarNupp();
            btnLisaLattu = new UmarNupp();
            btnKustuta = new UmarNupp();
            pnlYlal.SuspendLayout();
            tlp.SuspendLayout();
            pnlTabel.SuspendLayout();
            pnlVorm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTooted).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picturePilt).BeginInit();
            SuspendLayout();
            // 
            // pnlYlal
            // 
            pnlYlal.Controls.Add(txtOtsi);
            pnlYlal.Controls.Add(cmbFilter);
            pnlYlal.Controls.Add(chkOtsakorral);
            pnlYlal.Controls.Add(lblHoiatus);
            pnlYlal.Dock = DockStyle.Top;
            pnlYlal.Name = "pnlYlal";
            pnlYlal.Size = new Size(1000, 56);
            // 
            // txtOtsi
            // 
            txtOtsi.Font = new Font("Segoe UI", 11F);
            txtOtsi.Location = new Point(0, 8);
            txtOtsi.Name = "txtOtsi";
            txtOtsi.PlaceholderText = "🔍 Otsi toodet...";
            txtOtsi.Size = new Size(300, 27);
            txtOtsi.Font = new Font("Segoe UI", 12F);
            txtOtsi.TextChanged += Filter_Changed;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Font = new Font("Segoe UI", 12F);
            cmbFilter.Location = new Point(316, 8);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(220, 29);
            cmbFilter.SelectedIndexChanged += Filter_Changed;
            // 
            // chkOtsakorral
            // 
            chkOtsakorral.AutoSize = true;
            chkOtsakorral.Location = new Point(554, 12);
            chkOtsakorral.Name = "chkOtsakorral";
            chkOtsakorral.Text = "Ainult otsakorral";
            chkOtsakorral.CheckedChanged += Filter_Changed;
            // 
            // lblHoiatus
            // 
            lblHoiatus.AutoSize = true;
            lblHoiatus.Font = new Font("Segoe UI Semibold", 10F);
            lblHoiatus.ForeColor = Color.FromArgb(220, 38, 38);
            lblHoiatus.Location = new Point(730, 13);
            lblHoiatus.Name = "lblHoiatus";
            // 
            // tlp
            // 
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tlp.Controls.Add(pnlTabel, 0, 0);
            tlp.Controls.Add(pnlVorm, 1, 0);
            tlp.Dock = DockStyle.Fill;
            tlp.Location = new Point(0, 56);
            tlp.Name = "tlp";
            tlp.RowCount = 1;
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp.Size = new Size(1000, 594);
            // 
            // pnlTabel
            // 
            pnlTabel.Controls.Add(dataGridViewTooted);
            pnlTabel.Dock = DockStyle.Fill;
            pnlTabel.Margin = new Padding(0, 0, 20, 0);
            pnlTabel.Name = "pnlTabel";
            pnlTabel.Padding = new Padding(14);
            // 
            // dataGridViewTooted
            // 
            dataGridViewTooted.AllowUserToAddRows = false;
            dataGridViewTooted.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTooted.Dock = DockStyle.Fill;
            dataGridViewTooted.MultiSelect = false;
            dataGridViewTooted.Name = "dataGridViewTooted";
            dataGridViewTooted.ReadOnly = true;
            dataGridViewTooted.RowHeadersVisible = false;
            dataGridViewTooted.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTooted.CellClick += dataGridViewTooted_CellClick;
            dataGridViewTooted.DataBindingComplete += dataGridViewTooted_DataBindingComplete;
            // 
            // pnlVorm
            // 
            pnlVorm.Controls.Add(lblVorm);
            pnlVorm.Controls.Add(picturePilt);
            pnlVorm.Controls.Add(btnValiPilt);
            pnlVorm.Controls.Add(lblNimetus);
            pnlVorm.Controls.Add(txtNimetus);
            pnlVorm.Controls.Add(lblKogus);
            pnlVorm.Controls.Add(txtKogus);
            pnlVorm.Controls.Add(lblHind);
            pnlVorm.Controls.Add(txtHind);
            pnlVorm.Controls.Add(lblKategooria);
            pnlVorm.Controls.Add(comboKategooria);
            pnlVorm.Controls.Add(lblSoodusHind);
            pnlVorm.Controls.Add(txtSoodusHind);
            pnlVorm.Controls.Add(chkSoodusKuni);
            pnlVorm.Controls.Add(dtpSoodusKuni);
            pnlVorm.Controls.Add(lblKirjeldus);
            pnlVorm.Controls.Add(txtKirjeldus);
            pnlVorm.Controls.Add(lblTootja);
            pnlVorm.Controls.Add(txtTootja);
            pnlVorm.Controls.Add(btnLisa);
            pnlVorm.Controls.Add(btnUuenda);
            pnlVorm.Controls.Add(btnLisaLattu);
            pnlVorm.Controls.Add(btnKustuta);
            pnlVorm.Dock = DockStyle.Fill;
            pnlVorm.Margin = new Padding(0);
            pnlVorm.Name = "pnlVorm";
            pnlVorm.AutoScroll = true;
            // 
            // lblVorm
            // 
            lblVorm.AutoSize = true;
            lblVorm.Font = new Font("Segoe UI Semibold", 13F);
            lblVorm.Location = new Point(20, 16);
            lblVorm.Name = "lblVorm";
            lblVorm.Text = "Toote andmed";
            // 
            // picturePilt
            // 
            picturePilt.BackColor = Color.White;
            picturePilt.BorderStyle = BorderStyle.FixedSingle;
            picturePilt.Location = new Point(20, 54);
            picturePilt.Name = "picturePilt";
            picturePilt.Size = new Size(130, 130);
            picturePilt.SizeMode = PictureBoxSizeMode.Zoom;
            picturePilt.TabStop = false;
            // 
            // btnValiPilt
            // 
            btnValiPilt.Ikoon = "\uE8B9";
            btnValiPilt.Location = new Point(166, 54);
            btnValiPilt.Name = "btnValiPilt";
            btnValiPilt.Size = new Size(194, 42);
            btnValiPilt.Stiil = NupuStiil.Kontuur;
            btnValiPilt.Text = "Vali pilt";
            btnValiPilt.Click += btnValiPilt_Click;
            // 
            // lblNimetus
            // 
            lblNimetus.AutoSize = true;
            lblNimetus.ForeColor = Color.FromArgb(110, 110, 118);
            lblNimetus.Location = new Point(20, 198);
            lblNimetus.Name = "lblNimetus";
            lblNimetus.Text = "Nimetus";
            // 
            // txtNimetus
            // 
            txtNimetus.Font = new Font("Segoe UI", 11F);
            txtNimetus.Location = new Point(20, 220);
            txtNimetus.Name = "txtNimetus";
            txtNimetus.PlaceholderText = "Toote nimetus";
            txtNimetus.Size = new Size(340, 27);
            // 
            // lblKogus
            // 
            lblKogus.AutoSize = true;
            lblKogus.ForeColor = Color.FromArgb(110, 110, 118);
            lblKogus.Location = new Point(20, 258);
            lblKogus.Name = "lblKogus";
            lblKogus.Text = "Kogus (tk)";
            // 
            // txtKogus
            // 
            txtKogus.Font = new Font("Segoe UI", 11F);
            txtKogus.Location = new Point(20, 280);
            txtKogus.Name = "txtKogus";
            txtKogus.PlaceholderText = "Kogus";
            txtKogus.Size = new Size(160, 27);
            // 
            // lblHind
            // 
            lblHind.AutoSize = true;
            lblHind.ForeColor = Color.FromArgb(110, 110, 118);
            lblHind.Location = new Point(200, 258);
            lblHind.Name = "lblHind";
            lblHind.Text = "Hind €";
            // 
            // txtHind
            // 
            txtHind.Font = new Font("Segoe UI", 11F);
            txtHind.Location = new Point(200, 280);
            txtHind.Name = "txtHind";
            txtHind.PlaceholderText = "Hind €";
            txtHind.Size = new Size(160, 27);
            // 
            // lblKategooria
            // 
            lblKategooria.AutoSize = true;
            lblKategooria.ForeColor = Color.FromArgb(110, 110, 118);
            lblKategooria.Location = new Point(20, 318);
            lblKategooria.Name = "lblKategooria";
            lblKategooria.Text = "Kategooria";
            // 
            // comboKategooria
            // 
            comboKategooria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboKategooria.Font = new Font("Segoe UI", 11F);
            comboKategooria.Location = new Point(20, 340);
            comboKategooria.Name = "comboKategooria";
            comboKategooria.Size = new Size(340, 28);
            // 
            // lblSoodusHind
            // 
            lblSoodusHind.AutoSize = true;
            lblSoodusHind.ForeColor = Color.FromArgb(110, 110, 118);
            lblSoodusHind.Location = new Point(20, 380);
            lblSoodusHind.Name = "lblSoodusHind";
            lblSoodusHind.Text = "Soodushind €";
            // 
            // txtSoodusHind
            // 
            txtSoodusHind.Font = new Font("Segoe UI", 11F);
            txtSoodusHind.Location = new Point(20, 402);
            txtSoodusHind.Name = "txtSoodusHind";
            txtSoodusHind.PlaceholderText = "tühi = soodustust pole";
            txtSoodusHind.Size = new Size(160, 27);
            // 
            // chkSoodusKuni
            // 
            chkSoodusKuni.AutoSize = true;
            chkSoodusKuni.Location = new Point(200, 378);
            chkSoodusKuni.Name = "chkSoodusKuni";
            chkSoodusKuni.Text = "Soodus kuni:";
            chkSoodusKuni.CheckedChanged += chkSoodusKuni_CheckedChanged;
            // 
            // dtpSoodusKuni
            // 
            dtpSoodusKuni.Enabled = false;
            dtpSoodusKuni.Font = new Font("Segoe UI", 11F);
            dtpSoodusKuni.Format = DateTimePickerFormat.Short;
            dtpSoodusKuni.Location = new Point(200, 402);
            dtpSoodusKuni.Name = "dtpSoodusKuni";
            dtpSoodusKuni.Size = new Size(160, 27);
            // 
            // lblKirjeldus
            // 
            lblKirjeldus.AutoSize = true;
            lblKirjeldus.ForeColor = Color.FromArgb(110, 110, 118);
            lblKirjeldus.Location = new Point(20, 442);
            lblKirjeldus.Name = "lblKirjeldus";
            lblKirjeldus.Text = "Kirjeldus";
            // 
            // txtKirjeldus
            // 
            txtKirjeldus.Font = new Font("Segoe UI", 11F);
            txtKirjeldus.Location = new Point(20, 464);
            txtKirjeldus.Name = "txtKirjeldus";
            txtKirjeldus.PlaceholderText = "Kirjeldus (näidatakse tootekaardil)";
            txtKirjeldus.Size = new Size(340, 72);
            txtKirjeldus.Multiline = true;
            txtKirjeldus.ScrollBars = ScrollBars.Vertical;
            // 
            // lblTootja
            // 
            lblTootja.AutoSize = true;
            lblTootja.ForeColor = Color.FromArgb(110, 110, 118);
            lblTootja.Location = new Point(20, 546);
            lblTootja.Name = "lblTootja";
            lblTootja.Text = "Tootja";
            // 
            // txtTootja
            // 
            txtTootja.Font = new Font("Segoe UI", 11F);
            txtTootja.Location = new Point(20, 568);
            txtTootja.Name = "txtTootja";
            txtTootja.PlaceholderText = "Tootja (nt Arla)";
            txtTootja.Size = new Size(340, 27);
            // 
            // btnLisa
            // 
            btnLisa.Ikoon = "\uE710";
            btnLisa.Location = new Point(20, 614);
            btnLisa.Name = "btnLisa";
            btnLisa.Size = new Size(165, 44);
            btnLisa.Stiil = NupuStiil.Punane;
            btnLisa.Text = "Lisa uus";
            btnLisa.Click += btnLisa_Click;
            // 
            // btnUuenda
            // 
            btnUuenda.Ikoon = "\uE74E";
            btnUuenda.Location = new Point(195, 614);
            btnUuenda.Name = "btnUuenda";
            btnUuenda.Size = new Size(165, 44);
            btnUuenda.Text = "Uuenda";
            btnUuenda.Click += btnUuenda_Click;
            // 
            // btnLisaLattu
            // 
            btnLisaLattu.Location = new Point(20, 666);
            btnLisaLattu.Name = "btnLisaLattu";
            btnLisaLattu.Size = new Size(340, 40);
            btnLisaLattu.Stiil = NupuStiil.Hall;
            btnLisaLattu.Text = "Lisa lattu +";
            btnLisaLattu.Click += btnLisaLattu_Click;
            // 
            // btnKustuta
            // 
            btnKustuta.Ikoon = "\uE74D";
            btnKustuta.Location = new Point(20, 714);
            btnKustuta.Name = "btnKustuta";
            btnKustuta.Size = new Size(340, 40);
            btnKustuta.Stiil = NupuStiil.Kontuur;
            btnKustuta.Text = "Kustuta";
            btnKustuta.Click += btnKustuta_Click;
            // spacer
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 650);
            Controls.Add(tlp);
            Controls.Add(pnlYlal);
            Name = "Form2";
            Text = "Toodete haldus";
            Load += Form2_Load;
            pnlYlal.ResumeLayout(false);
            pnlYlal.PerformLayout();
            tlp.ResumeLayout(false);
            tlp.PerformLayout();
            pnlTabel.ResumeLayout(false);
            pnlTabel.PerformLayout();
            pnlVorm.ResumeLayout(false);
            pnlVorm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTooted).EndInit();
            ((System.ComponentModel.ISupportInitialize)picturePilt).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlYlal;
        private System.Windows.Forms.TextBox txtOtsi;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.CheckBox chkOtsakorral;
        private System.Windows.Forms.Label lblHoiatus;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private UmarPaneel pnlTabel;
        private System.Windows.Forms.DataGridView dataGridViewTooted;
        private UmarPaneel pnlVorm;
        private System.Windows.Forms.Label lblVorm;
        private System.Windows.Forms.PictureBox picturePilt;
        private UmarNupp btnValiPilt;
        private System.Windows.Forms.Label lblNimetus;
        private System.Windows.Forms.TextBox txtNimetus;
        private System.Windows.Forms.Label lblKogus;
        private System.Windows.Forms.TextBox txtKogus;
        private System.Windows.Forms.Label lblHind;
        private System.Windows.Forms.TextBox txtHind;
        private System.Windows.Forms.Label lblKategooria;
        private System.Windows.Forms.ComboBox comboKategooria;
        private System.Windows.Forms.Label lblSoodusHind;
        private System.Windows.Forms.TextBox txtSoodusHind;
        private System.Windows.Forms.CheckBox chkSoodusKuni;
        private System.Windows.Forms.DateTimePicker dtpSoodusKuni;
        private System.Windows.Forms.Label lblKirjeldus;
        private System.Windows.Forms.TextBox txtKirjeldus;
        private System.Windows.Forms.Label lblTootja;
        private System.Windows.Forms.TextBox txtTootja;
        private UmarNupp btnLisa;
        private UmarNupp btnUuenda;
        private UmarNupp btnLisaLattu;
        private UmarNupp btnKustuta;
    }
}
