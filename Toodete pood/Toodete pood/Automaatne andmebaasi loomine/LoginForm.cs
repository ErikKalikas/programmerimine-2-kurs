using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Automaatne_andmebaasi_loomine
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            using var db = new ToodedContext();

            // Loob andmebaasi migratsiooni järgi, kui seda veel pole
            db.Database.Migrate();

            // Kui kasutajaid pole, lisame admini, et saaks sisse logida
            if (!db.Kasutajad.Any())
            {
                var kasutaja = new Kasutaja
                {
                    Nimi = "Admin",
                    Email = "admin@admin.ee",
                    ParoolHash = PasswordHelper.Hash("admin123"),
                    Roll = "admin"
                };
                db.Kasutajad.Add(kasutaja);
                db.SaveChanges();
            }

            // Kui kategooriaid pole, lisame mõned, et ComboBox poleks tühi
            if (!db.Kategooriatabel.Any())
            {
                db.Kategooriatabel.AddRange(
                    new Kategooria { Kategooria_nimetus = "Joogid", Kirjeldus = "Erinevad joogid" },
                    new Kategooria { Kategooria_nimetus = "Toit", Kirjeldus = "Toiduained" },
                    new Kategooria { Kategooria_nimetus = "Muu", Kirjeldus = "Muud tooted" });
                db.SaveChanges();
            }

            LisaNaidisTooted(db);
        }

        // Lisab näidistooted koos piltidega (pildid on kaustas Images), kui neid veel pole
        private static void LisaNaidisTooted(ToodedContext db)
        {
            var naidised = new[]
            {
                ("Õun", 50, 0.40f, "oun.jpg", "Toit"),
                ("Banaan", 40, 0.30f, "banaan.jpg", "Toit"),
                ("Apelsin", 35, 0.45f, "apelsin.jpg", "Toit"),
                ("Sidrun", 30, 0.35f, "sidrun.jpg", "Toit"),
                ("Pirn", 25, 0.50f, "pirn.jpg", "Toit"),
                ("Kiivi", 30, 0.25f, "kiivi.jpg", "Toit"),
                ("Ananass", 10, 2.49f, "ananass.jpg", "Toit"),
                ("Arbuus", 8, 3.99f, "arbuus.jpg", "Toit"),
                ("Maasikas", 60, 0.10f, "maasikas.jpg", "Toit"),
                ("Viinamari", 40, 0.05f, "viinamari.jpg", "Toit"),
                ("Avokaado", 20, 1.19f, "avokaado.jpg", "Toit"),
                ("Tomat", 45, 0.30f, "tomat.jpg", "Toit"),
                ("Kartul", 100, 0.15f, "kartul.jpg", "Toit"),
                ("Sibul", 70, 0.12f, "sibul.jpg", "Toit"),
                ("Mais", 25, 0.89f, "mais.jpg", "Toit"),
                ("Pusa must", 5, 34.99f, "pusa_must.jpg", "Muu"),
                ("Pusa sinine", 5, 34.99f, "pusa_sinine.jpg", "Muu"),
                ("Pusa lilla", 5, 34.99f, "pusa_lilla.jpg", "Muu"),
                ("T-särk valge", 10, 14.99f, "tsark_valge.jpg", "Muu"),
                ("T-särk lilla", 10, 14.99f, "tsark_lilla.jpg", "Muu"),
                ("T-särk punane", 10, 14.99f, "tsark_punane.jpg", "Muu"),
                ("Kruus .NET", 15, 8.99f, "kruus_dotnet.jpg", "Muu"),
                ("Kruus Cup<T>", 15, 8.99f, "kruus_cup.jpg", "Muu"),
                ("Märk punane", 30, 1.99f, "mark_punane.jpg", "Muu"),
                ("Märk lilla", 30, 1.99f, "mark_lilla.jpg", "Muu")
            };

            foreach (var (nimetus, kogus, hind, pilt, kategooria) in naidised)
            {
                if (db.Toodetabel.Any(t => t.Toodenimetus == nimetus)) continue;

                var kat = db.Kategooriatabel.FirstOrDefault(k => k.Kategooria_nimetus == kategooria);
                if (kat == null) continue;

                db.Toodetabel.Add(new Toode
                {
                    Toodenimetus = nimetus,
                    Kogus = kogus,
                    Hind = hind,
                    Pilt = pilt,
                    KategooriaId = kat.Id
                });
            }
            db.SaveChanges();
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            using var db = new ToodedContext();

            string email = txtEmail.Text;
            string parool = txtParool.Text;

            var kasutaja = db.Kasutajad.FirstOrDefault(k => k.Email == email);

            if (kasutaja == null)
            {
                lblVeateade.Text = "Vale email!";
                return;
            }

            if (!PasswordHelper.Verify(parool, kasutaja.ParoolHash))
            {
                lblVeateade.Text = "Vale parool!";
                return;
            }

            // roll salvestatakse globaalselt
            AktiivneKasutaja.Roll = kasutaja.Roll;

            AvaPeamenyy();
        }

        // Ostja režiim: parooli pole vaja, saab ainult poes osta
        private void btnOstja_Click(object? sender, EventArgs e)
        {
            AktiivneKasutaja.Roll = "kasutaja";
            AvaPeamenyy();
        }

        private void AvaPeamenyy()
        {
            lblVeateade.Text = "";
            txtParool.Clear();

            FormMain main = new FormMain();
            main.FormClosed += (_, _) =>
            {
                // "Logi välja" tühjendab rolli: siis tuleb tagasi sisselogimise aken,
                // muidu (akna sulgemisel) sulgub kogu programm
                if (AktiivneKasutaja.Roll == "")
                    this.Show();
                else
                    this.Close();
            };
            main.Show();
            this.Hide();
        }
    }
}
