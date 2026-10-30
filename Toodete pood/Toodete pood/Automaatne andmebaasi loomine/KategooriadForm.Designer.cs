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
            dataGridViewKategooriad = new DataGridView();
            txtNimetus = new TextBox();
            txtKirjeldus = new TextBox();
            btnLisa = new Button();
            btnUuenda = new Button();
            btnKustuta = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKategooriad).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewKategooriad
            // 
            dataGridViewKategooriad.AllowUserToAddRows = false;
            dataGridViewKategooriad.Location = new Point(12, 12);
            dataGridViewKategooriad.MultiSelect = false;
            dataGridViewKategooriad.Name = "dataGridViewKategooriad";
            dataGridViewKategooriad.ReadOnly = true;
            dataGridViewKategooriad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKategooriad.Size = new Size(400, 250);
            dataGridViewKategooriad.TabIndex = 0;
            dataGridViewKategooriad.CellClick += dataGridViewKategooriad_CellClick;
            // 
            // txtNimetus
            // 
            txtNimetus.Location = new Point(430, 30);
            txtNimetus.Name = "txtNimetus";
            txtNimetus.PlaceholderText = "Kategooria nimetus";
            txtNimetus.Size = new Size(200, 23);
            txtNimetus.TabIndex = 1;
            // 
            // txtKirjeldus
            // 
            txtKirjeldus.Location = new Point(430, 70);
            txtKirjeldus.Name = "txtKirjeldus";
            txtKirjeldus.PlaceholderText = "Kirjeldus";
            txtKirjeldus.Size = new Size(200, 23);
            txtKirjeldus.TabIndex = 2;
            // 
            // btnLisa
            // 
            btnLisa.Location = new Point(430, 110);
            btnLisa.Name = "btnLisa";
            btnLisa.Size = new Size(75, 23);
            btnLisa.TabIndex = 3;
            btnLisa.Text = "Lisa";
            btnLisa.Click += btnLisa_Click;
            // 
            // btnUuenda
            // 
            btnUuenda.Location = new Point(430, 150);
            btnUuenda.Name = "btnUuenda";
            btnUuenda.Size = new Size(75, 23);
            btnUuenda.TabIndex = 4;
            btnUuenda.Text = "Uuenda";
            btnUuenda.Click += btnUuenda_Click;
            // 
            // btnKustuta
            // 
            btnKustuta.Location = new Point(430, 190);
            btnKustuta.Name = "btnKustuta";
            btnKustuta.Size = new Size(75, 23);
            btnKustuta.TabIndex = 5;
            btnKustuta.Text = "Kustuta";
            btnKustuta.Click += btnKustuta_Click;
            // 
            // KategooriadForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 280);
            Controls.Add(dataGridViewKategooriad);
            Controls.Add(txtNimetus);
            Controls.Add(txtKirjeldus);
            Controls.Add(btnLisa);
            Controls.Add(btnUuenda);
            Controls.Add(btnKustuta);
            Name = "KategooriadForm";
            BackColor = Color.LightBlue;
            Text = "Kategooriate haldus";
            ((System.ComponentModel.ISupportInitialize)dataGridViewKategooriad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewKategooriad;
        private System.Windows.Forms.TextBox txtNimetus;
        private System.Windows.Forms.TextBox txtKirjeldus;
        private System.Windows.Forms.Button btnLisa;
        private System.Windows.Forms.Button btnUuenda;
        private System.Windows.Forms.Button btnKustuta;
    }
}
