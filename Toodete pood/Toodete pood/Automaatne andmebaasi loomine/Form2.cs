using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    public partial class Form2 : Form
    {
        private readonly ToodedContext _db;
        private string? valitudPilt;

        // Nii väikese laoseisuga toode on "otsakorral" ja märgitakse punaseks
        private const int OtsakorralPiir = 5;

        public Form2()
        {
            InitializeComponent();
            _db = new ToodedContext();

            // Loob andmebaasi migratsiooni järgi, kui seda veel pole
            _db.Database.Migrate();

            // Kaust piltide jaoks peab olemas olema, muidu File.Copy annab vea
            Directory.CreateDirectory("Images");

            LaeKategooriad();
            LaeFilter();
            LaeTooted();
        }

        // Kategooria filter tabeli kohal: "Kõik kategooriad" + kõik kategooriad
        private void LaeFilter()
        {
            cmbFilter.SelectedIndexChanged -= Filter_Changed;
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("Kõik kategooriad");
            foreach (var k in _db.Kategooriatabel.OrderBy(k => k.Kategooria_nimetus).ToList())
                cmbFilter.Items.Add(k.Kategooria_nimetus);
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += Filter_Changed;
        }

        private void Filter_Changed(object? sender, EventArgs e) => LaeTooted();

        private void Form2_Load(object? sender, EventArgs e)
        {
            if (AktiivneKasutaja.Roll != "admin")
            {
                btnLisa.Enabled = false;
                btnUuenda.Enabled = false;
                btnKustuta.Enabled = false;
                btnLisaLattu.Enabled = false;
            }
        }

        private void LaeKategooriad()
        {
            comboKategooria.DataSource = _db.Kategooriatabel.ToList();
            comboKategooria.DisplayMember = "Kategooria_nimetus";
            comboKategooria.ValueMember = "Id";
        }

        private void LaeTooted()
        {
            var tooted = _db.Toodetabel
                .Include(t => t.Kategooria)
                .Select(t => new
                {
                    t.Id,
                    t.Toodenimetus,
                    t.Kogus,
                    t.Hind,
                    Kategooria = t.Kategooria.Kategooria_nimetus,
                    t.KategooriaId,
                    t.Pilt,
                    t.SoodusHind,
                    t.SoodusKuni,
                    t.Kirjeldus
                })
                .ToList();

            // Otsakorral tooted kogu laos (filtrist sõltumata)
            int otsakorral = tooted.Count(t => t.Kogus < OtsakorralPiir);
            lblHoiatus.Text = otsakorral > 0
                ? $"⚠ {otsakorral} toodet on otsakorral (alla {OtsakorralPiir} tk)"
                : "";

            // Otsing, kategooria ja "ainult otsakorral"
            string otsing = txtOtsi.Text.Trim();
            if (otsing != "")
                tooted = tooted.Where(t => t.Toodenimetus.Contains(otsing, StringComparison.CurrentCultureIgnoreCase)).ToList();
            if (cmbFilter.SelectedIndex > 0)
                tooted = tooted.Where(t => t.Kategooria == cmbFilter.SelectedItem?.ToString()).ToList();
            if (chkOtsakorral.Checked)
                tooted = tooted.Where(t => t.Kogus < OtsakorralPiir).ToList();

            dataGridViewTooted.DataSource = tooted;

            // Hind alati kahe komakohaga (float võib muidu näidata nt 30,000002)
            var hindVeerg = dataGridViewTooted.Columns["Hind"];
            if (hindVeerg != null) hindVeerg.DefaultCellStyle.Format = "0.00";

            var soodusVeerg = dataGridViewTooted.Columns["SoodusHind"];
            if (soodusVeerg != null) soodusVeerg.DefaultCellStyle.Format = "0.00";

            var kuniVeerg = dataGridViewTooted.Columns["SoodusKuni"];
            if (kuniVeerg != null) kuniVeerg.DefaultCellStyle.Format = "dd.MM.yyyy";

            foreach (var peidetud in new[] { "KategooriaId", "Kirjeldus" })
            {
                var veerg = dataGridViewTooted.Columns[peidetud];
                if (veerg != null) veerg.Visible = false;
            }
        }

        // Otsakorral read punaseks (otsas tooted tumedamalt)
        private void dataGridViewTooted_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rida in dataGridViewTooted.Rows)
            {
                int kogus = Convert.ToInt32(rida.Cells["Kogus"].Value);
                if (kogus <= 0)
                    rida.DefaultCellStyle.BackColor = Color.LightCoral;
                else if (kogus < OtsakorralPiir)
                    rida.DefaultCellStyle.BackColor = Color.MistyRose;
            }
        }

        // Kontrollib, et väljad on õigesti täidetud
        private bool VormOnKorras()
        {
            if (string.IsNullOrWhiteSpace(txtNimetus.Text) ||
                !int.TryParse(txtKogus.Text, out _) ||
                !float.TryParse(txtHind.Text, out _) ||
                comboKategooria.SelectedValue == null)
            {
                MessageBox.Show("Täida nimetus, kogus (täisarv), hind (number) ja vali kategooria!");
                return false;
            }
            return true;
        }

        // Soodushind on vabatahtlik: tühi = soodustust pole. Peab olema väiksem kui tavahind.
        private bool LoeSoodus(out float? soodus)
        {
            soodus = null;
            if (string.IsNullOrWhiteSpace(txtSoodusHind.Text)) return true;

            if (!float.TryParse(txtSoodusHind.Text, out float s) || s <= 0)
            {
                MessageBox.Show("Soodushind peab olema positiivne number (või jäta tühjaks).");
                return false;
            }
            if (s >= float.Parse(txtHind.Text))
            {
                MessageBox.Show("Soodushind peab olema väiksem kui tavahind.");
                return false;
            }

            soodus = (float)Math.Round(s, 2);
            return true;
        }

        private void chkSoodusKuni_CheckedChanged(object? sender, EventArgs e)
        {
            dtpSoodusKuni.Enabled = chkSoodusKuni.Checked;
        }

        // Laeb pildi nii, et fail ei jää lukku (Image.FromFile lukustab faili)
        private static Image LaePilt(string tee)
        {
            return Image.FromStream(new MemoryStream(File.ReadAllBytes(tee)));
        }

        private void btnValiPilt_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Pildid|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                valitudPilt = ofd.FileName;
                picturePilt.Image = LaePilt(valitudPilt);
            }
        }

        private void btnLisa_Click(object? sender, EventArgs e)
        {
            if (!VormOnKorras()) return;
            if (!LoeSoodus(out float? soodus)) return;

            var uus = new Toode
            {
                Toodenimetus = txtNimetus.Text,
                Kogus = int.Parse(txtKogus.Text),
                Hind = (float)Math.Round(float.Parse(txtHind.Text), 2),
                KategooriaId = Convert.ToInt32(comboKategooria.SelectedValue),
                Pilt = string.IsNullOrEmpty(valitudPilt) ? string.Empty : Path.GetFileName(valitudPilt),
                Kirjeldus = string.IsNullOrWhiteSpace(txtKirjeldus.Text) ? null : txtKirjeldus.Text.Trim(),
                SoodusHind = soodus,
                SoodusKuni = soodus != null && chkSoodusKuni.Checked ? dtpSoodusKuni.Value.Date : null
            };

            // kopeerime pildi projekti kausta
            if (!string.IsNullOrEmpty(valitudPilt))
            {
                File.Copy(valitudPilt, Path.Combine("Images", uus.Pilt), true);
            }

            _db.Toodetabel.Add(uus);
            _db.SaveChanges();
            Tegevuslogi.Kirjuta($"Lisas toote \"{uus.Toodenimetus}\" (hind {uus.Hind:0.00} €, laos {uus.Kogus} tk)");
            LaeTooted();
            valitudPilt = null;
        }

        private void dataGridViewTooted_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var rida = dataGridViewTooted.Rows[e.RowIndex];

            txtNimetus.Text = rida.Cells["Toodenimetus"].Value?.ToString();
            txtKogus.Text = rida.Cells["Kogus"].Value?.ToString();
            txtHind.Text = Convert.ToSingle(rida.Cells["Hind"].Value).ToString("0.00");
            comboKategooria.SelectedValue = rida.Cells["KategooriaId"].Value;

            txtKirjeldus.Text = rida.Cells["Kirjeldus"].Value?.ToString() ?? "";
            var soodus = rida.Cells["SoodusHind"].Value;
            txtSoodusHind.Text = soodus == null ? "" : Convert.ToSingle(soodus).ToString("0.00");
            var kuni = rida.Cells["SoodusKuni"].Value;
            chkSoodusKuni.Checked = kuni != null;
            if (kuni != null) dtpSoodusKuni.Value = (DateTime)kuni;

            // uus pilt pole veel valitud
            valitudPilt = null;

            string? pilt = rida.Cells["Pilt"].Value?.ToString();

            if (!string.IsNullOrEmpty(pilt) && File.Exists(Path.Combine("Images", pilt)))
                picturePilt.Image = LaePilt(Path.Combine("Images", pilt));
            else
                picturePilt.Image = null;
        }

        private void btnUuenda_Click(object? sender, EventArgs e)
        {
            if (dataGridViewTooted.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vali tabelist toode!");
                return;
            }
            if (!VormOnKorras()) return;
            if (!LoeSoodus(out float? soodus)) return;

            int id = (int)dataGridViewTooted.SelectedRows[0].Cells["Id"].Value;

            var toode = _db.Toodetabel.Find(id);
            if (toode == null) return;

            // vanad väärtused logi jaoks
            string vanaNimi = toode.Toodenimetus;
            float vanaHind = toode.Hind;
            int vanaKogus = toode.Kogus;
            float? vanaSoodus = toode.SoodusHind;

            toode.Toodenimetus = txtNimetus.Text;
            toode.Kogus = int.Parse(txtKogus.Text);
            toode.Hind = (float)Math.Round(float.Parse(txtHind.Text), 2);
            toode.KategooriaId = Convert.ToInt32(comboKategooria.SelectedValue);
            toode.Kirjeldus = string.IsNullOrWhiteSpace(txtKirjeldus.Text) ? null : txtKirjeldus.Text.Trim();
            toode.SoodusHind = soodus;
            toode.SoodusKuni = soodus != null && chkSoodusKuni.Checked ? dtpSoodusKuni.Value.Date : null;

            if (valitudPilt != null)
            {
                toode.Pilt = Path.GetFileName(valitudPilt);
                File.Copy(valitudPilt, Path.Combine("Images", toode.Pilt), true);
            }

            _db.SaveChanges();

            var muudatused = new List<string>();
            if (vanaNimi != toode.Toodenimetus) muudatused.Add($"nimi \"{vanaNimi}\" → \"{toode.Toodenimetus}\"");
            if (vanaHind != toode.Hind) muudatused.Add($"hind {vanaHind:0.00} → {toode.Hind:0.00} €");
            if (vanaKogus != toode.Kogus) muudatused.Add($"laos {vanaKogus} → {toode.Kogus} tk");
            if (vanaSoodus != toode.SoodusHind)
                muudatused.Add($"soodushind {(vanaSoodus?.ToString("0.00") ?? "–")} → {(toode.SoodusHind?.ToString("0.00") ?? "–")}");
            Tegevuslogi.Kirjuta($"Muutis toodet \"{toode.Toodenimetus}\"" +
                                (muudatused.Count > 0 ? ": " + string.Join(", ", muudatused) : ""));
            LaeTooted();
            valitudPilt = null;
        }

        private void btnKustuta_Click(object? sender, EventArgs e)
        {
            if (dataGridViewTooted.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vali tabelist toode!");
                return;
            }

            int id = (int)dataGridViewTooted.SelectedRows[0].Cells["Id"].Value;

            var toode = _db.Toodetabel.Find(id);
            if (toode == null) return;

            _db.Toodetabel.Remove(toode);
            _db.SaveChanges();
            Tegevuslogi.Kirjuta($"Kustutas toote \"{toode.Toodenimetus}\"");
            LaeTooted();
            picturePilt.Image = null;
        }

        // Kauba saabumine: valitud toote laoseisu suurendamine
        private void btnLisaLattu_Click(object? sender, EventArgs e)
        {
            if (dataGridViewTooted.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vali tabelist toode!");
                return;
            }

            int id = (int)dataGridViewTooted.SelectedRows[0].Cells["Id"].Value;
            var toode = _db.Toodetabel.Find(id);
            if (toode == null) return;

            string vastus = Microsoft.VisualBasic.Interaction.InputBox(
                $"{toode.Toodenimetus}\nPraegu laos: {toode.Kogus} tk\n\nMitu tükki lisada?", "Lisa lattu", "10");
            if (string.IsNullOrEmpty(vastus)) return;   // Cancel

            if (!int.TryParse(vastus, out int lisa) || lisa <= 0)
            {
                MessageBox.Show("Sisesta positiivne täisarv.");
                return;
            }

            toode.Kogus += lisa;
            _db.SaveChanges();
            Tegevuslogi.Kirjuta($"Lisas lattu \"{toode.Toodenimetus}\" +{lisa} tk (nüüd {toode.Kogus} tk)");
            LaeTooted();
            MessageBox.Show($"{toode.Toodenimetus}: laos nüüd {toode.Kogus} tk.");
        }

        private void btnArve_Click(object? sender, EventArgs e)
        {
            if (dataGridViewTooted.SelectedRows.Count == 0) return;

            int id = (int)dataGridViewTooted.SelectedRows[0].Cells["Id"].Value;
            var toode = _db.Toodetabel.Find(id);

            ArveForm arve = new ArveForm();
            arve.SelectedToode = toode;
            arve.ShowDialog();
        }
    }
}
//.