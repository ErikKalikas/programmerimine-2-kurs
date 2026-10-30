using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    // Admin: kes ja millal mida muutis (uuemad ees)
    public partial class LogiForm : Form
    {
        private readonly List<LogiKirje> kirjed;

        public LogiForm()
        {
            InitializeComponent();

            using var db = new ToodedContext();
            kirjed = db.Logid.AsNoTracking().OrderByDescending(l => l.Aeg).Take(1000).ToList();
            Naita();
        }

        private void Naita()
        {
            string otsing = txtOtsi.Text.Trim();
            dgvLogi.DataSource = kirjed
                .Where(l => otsing == "" ||
                            l.Kasutaja.Contains(otsing, StringComparison.CurrentCultureIgnoreCase) ||
                            l.Tegevus.Contains(otsing, StringComparison.CurrentCultureIgnoreCase))
                .Select(l => new { Aeg = l.Aeg.ToString("dd.MM.yyyy HH:mm:ss"), l.Kasutaja, l.Tegevus })
                .ToList();

            if (dgvLogi.Columns.Count == 3)
            {
                dgvLogi.Columns[0].Width = 130;
                dgvLogi.Columns[1].Width = 180;
                dgvLogi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void txtOtsi_TextChanged(object? sender, EventArgs e) => Naita();
    }
}
