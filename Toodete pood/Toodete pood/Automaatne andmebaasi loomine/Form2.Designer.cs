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
            dataGridViewTooted = new DataGridView();
            txtOtsi = new TextBox();
            cmbFilter = new ComboBox();
            chkOtsakorral = new CheckBox();
            lblHoiatus = new Label();
            txtNimetus = new TextBox();
            txtKogus = new TextBox();
            txtHind = new TextBox();
            comboKategooria = new ComboBox();
            picturePilt = new PictureBox();
            btnLisa = new Button();
            btnUuenda = new Button();
            btnKustuta = new Button();
            btnValiPilt = new Button();
            btnArve = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTooted).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picturePilt).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTooted
            // 
            dataGridViewTooted.AllowUserToAddRows = false;
            dataGridViewTooted.Location = new Point(12, 45);
            dataGridViewTooted.MultiSelect = false;
            dataGridViewTooted.Name = "dataGridViewTooted";
            dataGridViewTooted.ReadOnly = true;
            dataGridViewTooted.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTooted.Size = new Size(600, 300);
            dataGridViewTooted.TabIndex = 0;
            dataGridViewTooted.CellClick += dataGridViewTooted_CellClick;
            dataGridViewTooted.DataBindingComplete += dataGridViewTooted_DataBindingComplete;
            // 
            // txtOtsi
            // 
            txtOtsi.Location = new Point(12, 12);
            txtOtsi.Name = "txtOtsi";
            txtOtsi.PlaceholderText = "🔍 Otsi toodet...";
            txtOtsi.Size = new Size(240, 23);
            txtOtsi.TextChanged += Filter_Changed;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Location = new Point(262, 12);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(170, 23);
            cmbFilter.SelectedIndexChanged += Filter_Changed;
            // 
            // chkOtsakorral
            // 
            chkOtsakorral.AutoSize = true;
            chkOtsakorral.Location = new Point(445, 14);
            chkOtsakorral.Name = "chkOtsakorral";
            chkOtsakorral.Text = "Ainult otsakorral";
            chkOtsakorral.CheckedChanged += Filter_Changed;
            // 
            // lblHoiatus
            // 
            lblHoiatus.AutoSize = true;
            lblHoiatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHoiatus.ForeColor = Color.Firebrick;
            lblHoiatus.Location = new Point(12, 352);
            lblHoiatus.Name = "lblHoiatus";
            // 
            // txtNimetus
            // 
            txtNimetus.Location = new Point(630, 30);
            txtNimetus.Name = "txtNimetus";
            txtNimetus.PlaceholderText = "Toote nimetus";
            txtNimetus.Size = new Size(200, 23);
            txtNimetus.TabIndex = 1;
            // 
            // txtKogus
            // 
            txtKogus.Location = new Point(630, 70);
            txtKogus.Name = "txtKogus";
            txtKogus.PlaceholderText = "Kogus";
            txtKogus.Size = new Size(200, 23);
            txtKogus.TabIndex = 2;
            // 
            // txtHind
            // 
            txtHind.Location = new Point(630, 110);
            txtHind.Name = "txtHind";
            txtHind.PlaceholderText = "Hind €";
            txtHind.Size = new Size(200, 23);
            txtHind.TabIndex = 3;
            // 
            // comboKategooria
            // 
            comboKategooria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboKategooria.Location = new Point(630, 150);
            comboKategooria.Name = "comboKategooria";
            comboKategooria.Size = new Size(200, 23);
            comboKategooria.TabIndex = 4;
            // 
            // picturePilt
            // 
            picturePilt.BorderStyle = BorderStyle.FixedSingle;
            picturePilt.Location = new Point(630, 190);
            picturePilt.Name = "picturePilt";
            picturePilt.Size = new Size(150, 150);
            picturePilt.SizeMode = PictureBoxSizeMode.Zoom;
            picturePilt.TabIndex = 5;
            picturePilt.TabStop = false;
            // 
            // btnLisa
            // 
            btnLisa.Location = new Point(630, 390);
            btnLisa.Name = "btnLisa";
            btnLisa.Size = new Size(75, 23);
            btnLisa.TabIndex = 7;
            btnLisa.Text = "Lisa";
            btnLisa.Click += btnLisa_Click;
            // 
            // btnUuenda
            // 
            btnUuenda.Location = new Point(630, 430);
            btnUuenda.Name = "btnUuenda";
            btnUuenda.Size = new Size(75, 23);
            btnUuenda.TabIndex = 8;
            btnUuenda.Text = "Uuenda";
            btnUuenda.Click += btnUuenda_Click;
            // 
            // btnKustuta
            // 
            btnKustuta.Location = new Point(630, 470);
            btnKustuta.Name = "btnKustuta";
            btnKustuta.Size = new Size(75, 23);
            btnKustuta.TabIndex = 9;
            btnKustuta.Text = "Kustuta";
            btnKustuta.Click += btnKustuta_Click;
            // 
            // btnValiPilt
            // 
            btnValiPilt.Location = new Point(630, 350);
            btnValiPilt.Name = "btnValiPilt";
            btnValiPilt.Size = new Size(75, 23);
            btnValiPilt.TabIndex = 6;
            btnValiPilt.Text = "Vali pilt";
            btnValiPilt.Click += btnValiPilt_Click;
            // 
            // btnArve
            // 
            btnArve.Location = new Point(630, 510);
            btnArve.Name = "btnArve";
            btnArve.Size = new Size(75, 23);
            btnArve.TabIndex = 10;
            btnArve.Text = "Lisa arvele";
            btnArve.Click += btnArve_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 560);
            Controls.Add(dataGridViewTooted);
            Controls.Add(txtOtsi);
            Controls.Add(cmbFilter);
            Controls.Add(chkOtsakorral);
            Controls.Add(lblHoiatus);
            Controls.Add(txtNimetus);
            Controls.Add(txtKogus);
            Controls.Add(txtHind);
            Controls.Add(comboKategooria);
            Controls.Add(picturePilt);
            Controls.Add(btnValiPilt);
            Controls.Add(btnLisa);
            Controls.Add(btnUuenda);
            Controls.Add(btnKustuta);
            Controls.Add(btnArve);
            Name = "Form2";
            BackColor = Color.LightBlue;
            Text = "Toodete haldus";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTooted).EndInit();
            ((System.ComponentModel.ISupportInitialize)picturePilt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTooted;
        private System.Windows.Forms.TextBox txtOtsi;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.CheckBox chkOtsakorral;
        private System.Windows.Forms.Label lblHoiatus;
        private System.Windows.Forms.TextBox txtNimetus;
        private System.Windows.Forms.TextBox txtKogus;
        private System.Windows.Forms.TextBox txtHind;
        private System.Windows.Forms.ComboBox comboKategooria;
        private System.Windows.Forms.PictureBox picturePilt;
        private System.Windows.Forms.Button btnLisa;
        private System.Windows.Forms.Button btnUuenda;
        private System.Windows.Forms.Button btnKustuta;
        private System.Windows.Forms.Button btnValiPilt;
        private System.Windows.Forms.Button btnArve;
    }
}
