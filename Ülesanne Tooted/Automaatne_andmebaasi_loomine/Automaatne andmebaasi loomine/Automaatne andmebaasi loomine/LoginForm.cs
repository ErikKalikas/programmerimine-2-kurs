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

            LisaNaidisTooted(db);
        }

        // Lisab näidistooted koos piltidega (pildid on kaustas Images), kui neid veel pole
        private static void LisaNaidisTooted(ToodedContext db)
        {
            var naidised = new[]
            {
                ("Õun", 50, 0.40m, "oun.jpg", "Toit"),
                ("Banaan", 40, 0.30m, "banaan.jpg", "Toit"),
                ("Apelsin", 35, 0.45m, "apelsin.jpg", "Toit"),
                ("Sidrun", 30, 0.35m, "sidrun.jpg", "Toit"),
                ("Pirn", 25, 0.50m, "pirn.jpg", "Toit"),
                ("Kiivi", 30, 0.25m, "kiivi.jpg", "Toit"),
                ("Ananass", 10, 2.49m, "ananass.jpg", "Toit"),
                ("Arbuus", 8, 3.99m, "arbuus.jpg", "Toit"),
                ("Maasikas", 60, 0.10m, "maasikas.jpg", "Toit"),
                ("Viinamari", 40, 0.05m, "viinamari.jpg", "Toit"),
                ("Avokaado", 20, 1.19m, "avokaado.jpg", "Toit"),
                ("Tomat", 45, 0.30m, "tomat.jpg", "Toit"),
                ("Kartul", 100, 0.15m, "kartul.jpg", "Toit"),
                ("Sibul", 70, 0.12m, "sibul.jpg", "Toit"),
                ("Mais", 25, 0.89m, "mais.jpg", "Toit"),
                ("Pusa must", 5, 34.99m, "pusa_must.jpg", "Muu"),
                ("Pusa sinine", 5, 34.99m, "pusa_sinine.jpg", "Muu"),
                ("Pusa lilla", 5, 34.99m, "pusa_lilla.jpg", "Muu"),
                ("T-särk valge", 10, 14.99m, "tsark_valge.jpg", "Muu"),
                ("T-särk lilla", 10, 14.99m, "tsark_lilla.jpg", "Muu"),
                ("T-särk punane", 10, 14.99m, "tsark_punane.jpg", "Muu"),
                ("Kruus .NET", 15, 8.99m, "kruus_dotnet.jpg", "Muu"),
                ("Kruus Cup<T>", 15, 8.99m, "kruus_cup.jpg", "Muu"),
                ("Märk punane", 30, 1.99m, "mark_punane.jpg", "Muu"),
                ("Märk lilla", 30, 1.99m, "mark_lilla.jpg", "Muu")
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

            var kasutaja = new KasutajaTeenus(db).LogiSisse(txtEmail.Text, txtParool.Text);

            if (kasutaja == null)
            {
                lblVeateade.Text = "Vale e-post või parool.";
                txtParool.Clear();
                return;
            }

            // roll salvestatakse globaalselt
            AktiivneKasutaja.Roll = kasutaja.Roll;

            // peale login
            FormMain main = new FormMain();
            main.FormClosed += (_, _) => this.Close(); // FormMain sulgemisel sulgub kogu programm
            main.Show();
            this.Hide();
        }
    }
}
