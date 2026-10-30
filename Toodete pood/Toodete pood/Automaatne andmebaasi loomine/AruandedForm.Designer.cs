namespace Automaatne_andmebaasi_loomine
{
    partial class AruandedForm
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
            btnTana = new Button();
            btnNadal = new Button();
            btnKuu = new Button();
            btnKoik = new Button();
            dtpAlates = new DateTimePicker();
            lblKriips = new Label();
            dtpKuni = new DateTimePicker();
            lblKokkuvote = new Label();
            lblTop = new Label();
            dgvTop = new DataGridView();
            lblKat = new Label();
            dgvKategooriad = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKategooriad).BeginInit();
            SuspendLayout();
            // 
            // btnTana
            // 
            btnTana.Location = new Point(12, 12);
            btnTana.Name = "btnTana";
            btnTana.Size = new Size(80, 28);
            btnTana.Text = "Täna";
            btnTana.Click += btnTana_Click;
            // 
            // btnNadal
            // 
            btnNadal.Location = new Point(97, 12);
            btnNadal.Name = "btnNadal";
            btnNadal.Size = new Size(80, 28);
            btnNadal.Text = "7 päeva";
            btnNadal.Click += btnNadal_Click;
            // 
            // btnKuu
            // 
            btnKuu.Location = new Point(182, 12);
            btnKuu.Name = "btnKuu";
            btnKuu.Size = new Size(80, 28);
            btnKuu.Text = "30 päeva";
            btnKuu.Click += btnKuu_Click;
            // 
            // btnKoik
            // 
            btnKoik.Location = new Point(267, 12);
            btnKoik.Name = "btnKoik";
            btnKoik.Size = new Size(80, 28);
            btnKoik.Text = "Kõik";
            btnKoik.Click += btnKoik_Click;
            // 
            // dtpAlates
            // 
            dtpAlates.Format = DateTimePickerFormat.Short;
            dtpAlates.Location = new Point(370, 15);
            dtpAlates.Name = "dtpAlates";
            dtpAlates.Size = new Size(110, 23);
            dtpAlates.ValueChanged += Periood_Changed;
            // 
            // lblKriips
            // 
            lblKriips.AutoSize = true;
            lblKriips.Location = new Point(485, 18);
            lblKriips.Name = "lblKriips";
            lblKriips.Text = "–";
            // 
            // dtpKuni
            // 
            dtpKuni.Format = DateTimePickerFormat.Short;
            dtpKuni.Location = new Point(500, 15);
            dtpKuni.Name = "dtpKuni";
            dtpKuni.Size = new Size(110, 23);
            dtpKuni.ValueChanged += Periood_Changed;
            // 
            // lblKokkuvote
            // 
            lblKokkuvote.Font = new Font("Segoe UI", 10F);
            lblKokkuvote.Location = new Point(12, 55);
            lblKokkuvote.Name = "lblKokkuvote";
            lblKokkuvote.Size = new Size(275, 380);
            // 
            // lblTop
            // 
            lblTop.AutoSize = true;
            lblTop.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTop.Location = new Point(300, 52);
            lblTop.Name = "lblTop";
            lblTop.Text = "Top-10 enim müüdud tooted";
            // 
            // dgvTop
            // 
            dgvTop.AllowUserToAddRows = false;
            dgvTop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTop.Location = new Point(300, 75);
            dgvTop.Name = "dgvTop";
            dgvTop.ReadOnly = true;
            dgvTop.RowHeadersVisible = false;
            dgvTop.Size = new Size(585, 205);
            // 
            // lblKat
            // 
            lblKat.AutoSize = true;
            lblKat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKat.Location = new Point(300, 288);
            lblKat.Name = "lblKat";
            lblKat.Text = "Müük kategooriate kaupa";
            // 
            // dgvKategooriad
            // 
            dgvKategooriad.AllowUserToAddRows = false;
            dgvKategooriad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKategooriad.Location = new Point(300, 311);
            dgvKategooriad.Name = "dgvKategooriad";
            dgvKategooriad.ReadOnly = true;
            dgvKategooriad.RowHeadersVisible = false;
            dgvKategooriad.Size = new Size(585, 125);
            // 
            // AruandedForm
            // 
            ClientSize = new Size(900, 450);
            Controls.Add(btnTana);
            Controls.Add(btnNadal);
            Controls.Add(btnKuu);
            Controls.Add(btnKoik);
            Controls.Add(dtpAlates);
            Controls.Add(lblKriips);
            Controls.Add(dtpKuni);
            Controls.Add(lblKokkuvote);
            Controls.Add(lblTop);
            Controls.Add(dgvTop);
            Controls.Add(lblKat);
            Controls.Add(dgvKategooriad);
            Name = "AruandedForm";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.LightBlue;
            Text = "Müügiaruanne";
            ((System.ComponentModel.ISupportInitialize)dgvTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKategooriad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnTana;
        private System.Windows.Forms.Button btnNadal;
        private System.Windows.Forms.Button btnKuu;
        private System.Windows.Forms.Button btnKoik;
        private System.Windows.Forms.DateTimePicker dtpAlates;
        private System.Windows.Forms.Label lblKriips;
        private System.Windows.Forms.DateTimePicker dtpKuni;
        private System.Windows.Forms.Label lblKokkuvote;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.DataGridView dgvTop;
        private System.Windows.Forms.Label lblKat;
        private System.Windows.Forms.DataGridView dgvKategooriad;
    }
}
