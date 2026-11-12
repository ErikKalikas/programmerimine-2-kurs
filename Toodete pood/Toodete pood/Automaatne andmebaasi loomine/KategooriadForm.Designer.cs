namespace Automaatne_andmebaasi_loomine
{
    partial class KategooriadForm
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
            tlp = new TableLayoutPanel();
            pnlTabel = new UmarPaneel();
            dataGridViewKategooriad = new DataGridView();
            pnlVorm = new UmarPaneel();
            lblVorm = new Label();
            lblNimetus = new Label();
            txtNimetus = new TextBox();
            lblKirjeldus = new Label();
            txtKirjeldus = new TextBox();
            btnLisa = new UmarNupp();
            btnUuenda = new UmarNupp();
            btnKustuta = new UmarNupp();
            lblVihje = new Label();
            tlp.SuspendLayout();
            pnlTabel.SuspendLayout();
            pnlVorm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKategooriad).BeginInit();
            SuspendLayout();
            // 
            // tlp
            // 
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 340F));
            tlp.Controls.Add(pnlTabel, 0, 0);
            tlp.Controls.Add(pnlVorm, 1, 0);
            tlp.Dock = DockStyle.Fill;
            tlp.Location = new Point(0, 0);
            tlp.Name = "tlp";
            tlp.RowCount = 1;
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp.Size = new Size(1000, 650);
            // 
            // pnlTabel
            // 
            pnlTabel.Controls.Add(dataGridViewKategooriad);
            pnlTabel.Dock = DockStyle.Fill;
            pnlTabel.Margin = new Padding(0, 0, 20, 0);
            pnlTabel.Name = "pnlTabel";
            pnlTabel.Padding = new Padding(14);
            // 
            // dataGridViewKategooriad
            // 
            dataGridViewKategooriad.AllowUserToAddRows = false;
            dataGridViewKategooriad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewKategooriad.Dock = DockStyle.Fill;
            dataGridViewKategooriad.MultiSelect = false;
            dataGridViewKategooriad.Name = "dataGridViewKategooriad";
            dataGridViewKategooriad.ReadOnly = true;
            dataGridViewKategooriad.RowHeadersVisible = false;
            dataGridViewKategooriad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKategooriad.CellClick += dataGridViewKategooriad_CellClick;
            // 
            // pnlVorm
            // 
            pnlVorm.Controls.Add(lblVorm);
            pnlVorm.Controls.Add(lblNimetus);
            pnlVorm.Controls.Add(txtNimetus);
            pnlVorm.Controls.Add(lblKirjeldus);
            pnlVorm.Controls.Add(txtKirjeldus);
            pnlVorm.Controls.Add(btnLisa);
            pnlVorm.Controls.Add(btnUuenda);
            pnlVorm.Controls.Add(btnKustuta);
            pnlVorm.Controls.Add(lblVihje);
            pnlVorm.Dock = DockStyle.Fill;
            pnlVorm.Margin = new Padding(0);
            pnlVorm.Name = "pnlVorm";
            // 
            // lblVorm
            // 
            lblVorm.AutoSize = true;
            lblVorm.Font = new Font("Segoe UI Semibold", 13F);
            lblVorm.Location = new Point(20, 18);
            lblVorm.Name = "lblVorm";
            lblVorm.Text = "Kategooria";
            // 
            // lblNimetus
            // 
            lblNimetus.AutoSize = true;
            lblNimetus.ForeColor = Color.FromArgb(110, 110, 118);
            lblNimetus.Location = new Point(20, 62);
            lblNimetus.Name = "lblNimetus";
            lblNimetus.Text = "Nimetus";
            // 
            // txtNimetus
            // 
            txtNimetus.Font = new Font("Segoe UI", 11F);
            txtNimetus.Location = new Point(20, 84);
            txtNimetus.Name = "txtNimetus";
            txtNimetus.PlaceholderText = "Kategooria nimetus";
            txtNimetus.Size = new Size(280, 27);
            // 
            // lblKirjeldus
            // 
            lblKirjeldus.AutoSize = true;
            lblKirjeldus.ForeColor = Color.FromArgb(110, 110, 118);
            lblKirjeldus.Location = new Point(20, 124);
            lblKirjeldus.Name = "lblKirjeldus";
            lblKirjeldus.Text = "Kirjeldus";
            // 
            // txtKirjeldus
            // 
            txtKirjeldus.Font = new Font("Segoe UI", 11F);
            txtKirjeldus.Location = new Point(20, 146);
            txtKirjeldus.Name = "txtKirjeldus";
            txtKirjeldus.PlaceholderText = "Kirjeldus";
            txtKirjeldus.Size = new Size(280, 27);
            // 
            // btnLisa
            // 
            btnLisa.Ikoon = "\uE710";
            btnLisa.Location = new Point(20, 198);
            btnLisa.Name = "btnLisa";
            btnLisa.Size = new Size(280, 44);
            btnLisa.Stiil = NupuStiil.Punane;
            btnLisa.Text = "Lisa uus";
            btnLisa.Click += btnLisa_Click;
            // 
            // btnUuenda
            // 
            btnUuenda.Ikoon = "\uE74E";
            btnUuenda.Location = new Point(20, 252);
            btnUuenda.Name = "btnUuenda";
            btnUuenda.Size = new Size(280, 44);
            btnUuenda.Text = "Salvesta muudatused";
            btnUuenda.Click += btnUuenda_Click;
            // 
            // btnKustuta
            // 
            btnKustuta.Ikoon = "\uE74D";
            btnKustuta.Location = new Point(20, 306);
            btnKustuta.Name = "btnKustuta";
            btnKustuta.Size = new Size(280, 44);
            btnKustuta.Stiil = NupuStiil.Kontuur;
            btnKustuta.Text = "Kustuta";
            btnKustuta.Click += btnKustuta_Click;
            // 
            // lblVihje
            // 
            lblVihje.ForeColor = Color.FromArgb(110, 110, 118);
            lblVihje.Location = new Point(20, 366);
            lblVihje.Name = "lblVihje";
            lblVihje.Size = new Size(280, 60);
            lblVihje.Text = "Vali tabelist kategooria, et seda muuta või kustutada.";
            // 
            // KategooriadForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 650);
            Controls.Add(tlp);
            Name = "KategooriadForm";
            Text = "Kategooriate haldus";
            tlp.ResumeLayout(false);
            tlp.PerformLayout();
            pnlTabel.ResumeLayout(false);
            pnlTabel.PerformLayout();
            pnlVorm.ResumeLayout(false);
            pnlVorm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKategooriad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private UmarPaneel pnlTabel;
        private System.Windows.Forms.DataGridView dataGridViewKategooriad;
        private UmarPaneel pnlVorm;
        private System.Windows.Forms.Label lblVorm;
        private System.Windows.Forms.Label lblNimetus;
        private System.Windows.Forms.TextBox txtNimetus;
        private System.Windows.Forms.Label lblKirjeldus;
        private System.Windows.Forms.TextBox txtKirjeldus;
        private UmarNupp btnLisa;
        private UmarNupp btnUuenda;
        private UmarNupp btnKustuta;
        private System.Windows.Forms.Label lblVihje;
    }
}
