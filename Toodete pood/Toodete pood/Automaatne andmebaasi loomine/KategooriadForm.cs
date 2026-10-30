using System;
using System.Linq;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    public partial class KategooriadForm : Form
    {
        private readonly ToodedContext _db;

        public KategooriadForm()
        {
            InitializeComponent();
            _db = new ToodedContext();
            LaeKategooriad();
        }

        private void LaeKategooriad()
        {
            dataGridViewKategooriad.DataSource = _db.Kategooriatabel
                .Select(k => new
                {
                    k.Id,
                    k.Kategooria_nimetus,
                    k.Kirjeldus,
                    Tooteid = k.Tooded.Count
                })
                .ToList();
        }

        private void dataGridViewKategooriad_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var rida = dataGridViewKategooriad.Rows[e.RowIndex];

            txtNimetus.Text = rida.Cells["Kategooria_nimetus"].Value?.ToString();
            txtKirjeldus.Text = rida.Cells["Kirjeldus"].Value?.ToString();
        }

        private void btnLisa_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNimetus.Text))
            {
                MessageBox.Show("Sisesta kategooria nimetus!");
                return;
            }

            _db.Kategooriatabel.Add(new Kategooria
            {
                Kategooria_nimetus = txtNimetus.Text,
                Kirjeldus = txtKirjeldus.Text
            });
            _db.SaveChanges();
            Tegevuslogi.Kirjuta($"Lisas kategooria \"{txtNimetus.Text}\"");
            LaeKategooriad();
        }

        private void btnUuenda_Click(object? sender, EventArgs e)
        {
            if (dataGridViewKategooriad.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vali tabelist kategooria!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNimetus.Text))
            {
                MessageBox.Show("Sisesta kategooria nimetus!");
                return;
            }

            int id = (int)dataGridViewKategooriad.SelectedRows[0].Cells["Id"].Value;

            var kat = _db.Kategooriatabel.Find(id);
            if (kat == null) return;

            string vanaNimi = kat.Kategooria_nimetus;
            kat.Kategooria_nimetus = txtNimetus.Text;
            kat.Kirjeldus = txtKirjeldus.Text;

            _db.SaveChanges();
            Tegevuslogi.Kirjuta(vanaNimi == kat.Kategooria_nimetus
                ? $"Muutis kategooriat \"{kat.Kategooria_nimetus}\""
                : $"Nimetas kategooria \"{vanaNimi}\" ümber: \"{kat.Kategooria_nimetus}\"");
            LaeKategooriad();
        }

        private void btnKustuta_Click(object? sender, EventArgs e)
        {
            if (dataGridViewKategooriad.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vali tabelist kategooria!");
                return;
            }

            int id = (int)dataGridViewKategooriad.SelectedRows[0].Cells["Id"].Value;

            // Andmebaasis on kaskaadkustutamine, seega ei lase kustutada kategooriat, kus on tooteid
            if (_db.Toodetabel.Any(t => t.KategooriaId == id))
            {
                MessageBox.Show("Selles kategoorias on tooteid. Kustuta või liiguta need enne teise kategooriasse.");
                return;
            }

            var kat = _db.Kategooriatabel.Find(id);
            if (kat == null) return;

            _db.Kategooriatabel.Remove(kat);
            _db.SaveChanges();
            Tegevuslogi.Kirjuta($"Kustutas kategooria \"{kat.Kategooria_nimetus}\"");
            LaeKategooriad();
            txtNimetus.Text = "";
            txtKirjeldus.Text = "";
        }
    }
}
