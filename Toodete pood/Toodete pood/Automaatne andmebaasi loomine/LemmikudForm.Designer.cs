namespace Automaatne_andmebaasi_loomine
{
    partial class LemmikudForm
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
            dgvLemmikud = new DataGridView();
            btnAva = new Button();
            btnLisaKorvi = new Button();
            btnEemalda = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLemmikud).BeginInit();
            SuspendLayout();
            // 
            // dgvLemmikud
            // 
            dgvLemmikud.AllowUserToAddRows = false;
            dgvLemmikud.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLemmikud.Location = new Point(12, 12);
            dgvLemmikud.MultiSelect = false;
            dgvLemmikud.Name = "dgvLemmikud";
            dgvLemmikud.ReadOnly = true;
            dgvLemmikud.RowHeadersVisible = false;
            dgvLemmikud.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLemmikud.Size = new Size(460, 300);
            dgvLemmikud.CellDoubleClick += dgvLemmikud_CellDoubleClick;
            // 
            // btnAva
            // 
            btnAva.Location = new Point(490, 12);
            btnAva.Name = "btnAva";
            btnAva.Size = new Size(170, 34);
            btnAva.Text = "Ava toode";
            btnAva.Click += btnAva_Click;
            // 
            // btnLisaKorvi
            // 
            btnLisaKorvi.Location = new Point(490, 54);
            btnLisaKorvi.Name = "btnLisaKorvi";
            btnLisaKorvi.Size = new Size(170, 34);
            btnLisaKorvi.Text = "Lisa korvi (1 tk)";
            btnLisaKorvi.Click += btnLisaKorvi_Click;
            // 
            // btnEemalda
            // 
            btnEemalda.Location = new Point(490, 96);
            btnEemalda.Name = "btnEemalda";
            btnEemalda.Size = new Size(170, 34);
            btnEemalda.Text = "Eemalda lemmikutest";
            btnEemalda.Click += btnEemalda_Click;
            // 
            // LemmikudForm
            // 
            ClientSize = new Size(675, 325);
            Controls.Add(dgvLemmikud);
            Controls.Add(btnAva);
            Controls.Add(btnLisaKorvi);
            Controls.Add(btnEemalda);
            Name = "LemmikudForm";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.LightBlue;
            Text = "Lemmikud";
            ((System.ComponentModel.ISupportInitialize)dgvLemmikud).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLemmikud;
        private System.Windows.Forms.Button btnAva;
        private System.Windows.Forms.Button btnLisaKorvi;
        private System.Windows.Forms.Button btnEemalda;
    }
}
