namespace Automaatne_andmebaasi_loomine
{
    partial class KasutajadForm
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
            dgvKasutajad = new DataGridView();
            btnLisaAdmin = new Button();
            btnRoll = new Button();
            btnBlokeeri = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKasutajad).BeginInit();
            SuspendLayout();
            // 
            // dgvKasutajad
            // 
            dgvKasutajad.AllowUserToAddRows = false;
            dgvKasutajad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKasutajad.Location = new Point(12, 12);
            dgvKasutajad.MultiSelect = false;
            dgvKasutajad.Name = "dgvKasutajad";
            dgvKasutajad.ReadOnly = true;
            dgvKasutajad.RowHeadersVisible = false;
            dgvKasutajad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKasutajad.Size = new Size(600, 330);
            dgvKasutajad.DataBindingComplete += dgvKasutajad_DataBindingComplete;
            // 
            // btnLisaAdmin
            // 
            btnLisaAdmin.Location = new Point(630, 12);
            btnLisaAdmin.Name = "btnLisaAdmin";
            btnLisaAdmin.Size = new Size(190, 34);
            btnLisaAdmin.Text = "Lisa administraator";
            btnLisaAdmin.Click += btnLisaAdmin_Click;
            // 
            // btnRoll
            // 
            btnRoll.Location = new Point(630, 54);
            btnRoll.Name = "btnRoll";
            btnRoll.Size = new Size(190, 34);
            btnRoll.Text = "Muuda rolli";
            btnRoll.Click += btnRoll_Click;
            // 
            // btnBlokeeri
            // 
            btnBlokeeri.Location = new Point(630, 96);
            btnBlokeeri.Name = "btnBlokeeri";
            btnBlokeeri.Size = new Size(190, 34);
            btnBlokeeri.Text = "Blokeeri / ava";
            btnBlokeeri.Click += btnBlokeeri_Click;
            // 
            // KasutajadForm
            // 
            ClientSize = new Size(835, 355);
            Controls.Add(dgvKasutajad);
            Controls.Add(btnLisaAdmin);
            Controls.Add(btnRoll);
            Controls.Add(btnBlokeeri);
            Name = "KasutajadForm";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.LightBlue;
            Text = "Kasutajad";
            ((System.ComponentModel.ISupportInitialize)dgvKasutajad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKasutajad;
        private System.Windows.Forms.Button btnLisaAdmin;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Button btnBlokeeri;
    }
}
