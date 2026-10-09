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

        public Form2()
        {
            InitializeComponent();
            _db = new ToodedContext();

            // Loob andmebaasi migratsiooni järgi, kui seda veel pole
            _db.Database.Migrate();

            // Kaust piltide jaoks peab olemas olema, muidu File.Copy annab vea
            Directory.CreateDirectory("Images");

            // Kui kategooriaid pole, lisame mõned, et ComboBox poleks tühi
            if (!_db.Kategooriatabel.Any())
            {
                _db.Kategooriatabel.AddRange(
                    new Kategooria { Kategooria_nimetus = "Joogid", Kirjeldus = "Erinevad joogid" },
                    new Kategooria { Kategooria_nimetus = "Toit", Kirjeldus = "Toiduained" },
                    new Kategooria { Kategooria_nimetus = "Muu", Kirjeldus = "Muud tooted" });
                _db.SaveChanges();
            }

            LaeKategooriad();
            LaeTooted();
        }

        private void LaeKategooriad()
        {
            comboKategooria.DataSource = _db.Kategooriatabel.ToList();
            comboKategooria.DisplayMember = "Kategooria_nimetus";
            comboKategooria.ValueMember = "Id";
        }

        private void LaeTooted()
        {
            dataGridViewTooted.DataSource = _db.Toodetabel
                .Include(t => t.Kategooria)
                .Select(t => new
                {
                    t.Id,
                    t.Toodenimetus,
                    t.Kogus,
                    t.Hind,
                    Kategooria = t.Kategooria.Kategooria_nimetus,
                    t.KategooriaId,
                    t.Pilt
                })
                .ToList();

            var kategooriaIdVeerg = dataGridViewTooted.Columns["KategooriaId"];
            if (kategooriaIdVeerg != null) kategooriaIdVeerg.Visible = false;
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

            var uus = new Toode
            {
                Toodenimetus = txtNimetus.Text,
                Kogus = int.Parse(txtKogus.Text),
                Hind = float.Parse(txtHind.Text),
                KategooriaId = Convert.ToInt32(comboKategooria.SelectedValue),
                Pilt = string.IsNullOrEmpty(valitudPilt) ? string.Empty : Path.GetFileName(valitudPilt)
            };

            // kopeerime pildi projekti kausta
            if (!string.IsNullOrEmpty(valitudPilt))
            {
                File.Copy(valitudPilt, Path.Combine("Images", uus.Pilt), true);
            }

            _db.Toodetabel.Add(uus);
            _db.SaveChanges();
            LaeTooted();
            valitudPilt = null;
        }

        private void dataGridViewTooted_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var rida = dataGridViewTooted.Rows[e.RowIndex];

            txtNimetus.Text = rida.Cells["Toodenimetus"].Value?.ToString();
            txtKogus.Text = rida.Cells["Kogus"].Value?.ToString();
            txtHind.Text = rida.Cells["Hind"].Value?.ToString();
            comboKategooria.SelectedValue = rida.Cells["KategooriaId"].Value;

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

            int id = (int)dataGridViewTooted.SelectedRows[0].Cells["Id"].Value;

            var toode = _db.Toodetabel.Find(id);
            if (toode == null) return;

            toode.Toodenimetus = txtNimetus.Text;
            toode.Kogus = int.Parse(txtKogus.Text);
            toode.Hind = float.Parse(txtHind.Text);
            toode.KategooriaId = Convert.ToInt32(comboKategooria.SelectedValue);

            if (valitudPilt != null)
            {
                toode.Pilt = Path.GetFileName(valitudPilt);
                File.Copy(valitudPilt, Path.Combine("Images", toode.Pilt), true);
            }

            _db.SaveChanges();
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
            LaeTooted();
            picturePilt.Image = null;
        }
    }
}
