using System.Globalization;

namespace Automaatne_andmebaasi_loomine
{
    // Kasutajaliidese keel: eesti (et), vene (ru) ja inglise (en).
    // Tekstid on koodis eesti keeles; T("eesti tekst") tagastab tõlke valitud keelde (sõnastik on failis KeeleSonastik.cs).
    // Valitud keel jäetakse meelde faili, nii et järgmisel käivitamisel on sama keel.
    public static partial class Keel
    {
        public static readonly string[] Keeled = { "et", "ru", "en" };

        public static string Praegune { get; private set; } = "et";

        // Käivitub pärast keele vahetamist (avatud aknad uuendavad oma tekste)
        public static event Action? Muutus;

        private static string Fail
        {
            get
            {
                string kaust = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ToodedApp");
                Directory.CreateDirectory(kaust);
                return Path.Combine(kaust, "keel.txt");
            }
        }

        static Keel()
        {
            try
            {
                if (File.Exists(Fail))
                {
                    string kood = File.ReadAllText(Fail).Trim();
                    if (Keeled.Contains(kood)) Praegune = kood;
                }
            }
            catch (IOException) { }
        }

        public static void Maara(string kood)
        {
            if (!Keeled.Contains(kood) || kood == Praegune) return;
            Praegune = kood;
            try { File.WriteAllText(Fail, kood); } catch (IOException) { }
            Muutus?.Invoke();
        }

        // Tõlge valitud keelde; kui tõlget pole, jääb eestikeelne tekst
        public static string T(string eesti)
        {
            if (Praegune == "et" || string.IsNullOrEmpty(eesti)) return eesti;
            if (!Sonastik.TryGetValue(eesti, out var t)) return eesti;
            return Praegune == "ru" ? t.Ru : t.En;
        }

        // Tõlge koos väärtustega, nt T("Laos: {0} tk", 5)
        public static string T(string eesti, params object?[] vaartused) =>
            string.Format(CultureInfo.CurrentCulture, T(eesti), vaartused);

        // Tõlgib vormi kõik eestikeelsed tekstid (nupud, sildid, vihjed tekstikastides, tabelite päised)
        public static void Tolgi(Control juur)
        {
            if (juur is Form f) f.Text = T(f.Text);

            foreach (Control c in juur.Controls)
            {
                switch (c)
                {
                    case TextBox t:
                        t.PlaceholderText = T(t.PlaceholderText);
                        break;
                    case DataGridView g:
                        TolgiPaised(g);
                        g.DataBindingComplete += (_, _) => TolgiPaised(g);
                        break;
                    case ComboBox:
                    case NumericUpDown:
                    case DateTimePicker:
                        break;
                    default:
                        if (!string.IsNullOrEmpty(c.Text)) c.Text = T(c.Text);
                        break;
                }
                Tolgi(c);
            }
        }

        // Tabeli veergude pealkirjad tulevad andmete väljade nimedest (nt "Kuupäev", "Summa")
        public static void TolgiPaised(DataGridView g)
        {
            foreach (DataGridViewColumn veerg in g.Columns)
            {
                string voti = string.IsNullOrEmpty(veerg.DataPropertyName) ? veerg.Name : veerg.DataPropertyName;
                veerg.HeaderText = T(voti);
            }
        }
    }
}
