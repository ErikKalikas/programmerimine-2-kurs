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
            AcceptButton = btnOstja;

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
                ("Avokaado", 20, 1.19f, "avokaado.jpg", "Toit"),
                ("Tomat", 45, 0.30f, "tomat.jpg", "Toit"),
                ("Kartul", 100, 0.15f, "kartul.jpg", "Toit"),
                ("Sibul", 70, 0.12f, "sibul.jpg", "Toit"),
                ("Mango", 20, 1.49f, "mango.jpg", "Toit"),
                ("Porgand", 80, 0.20f, "porgand.jpg", "Toit"),
                ("Kurk", 30, 0.99f, "kurk.jpg", "Toit"),
                ("Paprika punane", 30, 0.79f, "paprika.jpg", "Toit"),
                ("Õunamahl Bravo 1 l", 25, 2.19f, "mahl_oun_bravo.jpg", "Joogid"),
                ("Apelsinimahl Bravo 1 l", 25, 2.19f, "mahl_apelsin_bravo.jpg", "Joogid"),
                ("Apelsinimahl Tropicana 1 l", 20, 3.49f, "mahl_tropicana.jpg", "Joogid"),
                ("Greibimahl Tropicana 1 l", 15, 3.49f, "mahl_greip_tropicana.jpg", "Joogid"),
                ("Mandariinimahl Tropicana 1 l", 15, 3.49f, "mahl_mandariin_tropicana.jpg", "Joogid"),
                ("Apelsini-greibimahl God Morgon 1 l", 20, 2.79f, "mahl_godmorgon.jpg", "Joogid"),
                ("Piim Arla 3% 1 l", 40, 1.29f, "piim_arla.jpg", "Joogid"),
                ("Piim Arla 1,5% 1 l", 40, 1.19f, "piim_arla_15.jpg", "Joogid"),
                ("Laktoosivaba piim Arla 1 l", 25, 1.59f, "piim_laktoosivaba.jpg", "Joogid"),
                ("Kaerajook Oatly 1 l", 25, 2.49f, "kaerajook_oatly.jpg", "Joogid"),
                ("Sojajook Alpro 1 l", 20, 2.29f, "sojajook_alpro.jpg", "Joogid"),
                ("Hapupiim Arla 1 l", 30, 1.39f, "hapupiim_arla.jpg", "Joogid"),
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

            // Varasemad näidistooted, mille jaoks head pilti polnud: eemaldame need
            foreach (var (vanaNimi, vanaPilt) in new[] { ("Maasikas", "maasikas.jpg"), ("Viinamari", "viinamari.jpg"), ("Mais", "mais.jpg") })
            {
                var vana = db.Toodetabel.FirstOrDefault(t => t.Toodenimetus == vanaNimi && t.Pilt == vanaPilt);
                if (vana != null) db.Toodetabel.Remove(vana);
            }

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

            if (kasutaja.Roll != "admin")
            {
                lblVeateade.Text = "See konto ei ole administraator!";
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

        // "Logi sisse administraatorina": näitab e-posti ja parooli välju
        private void btnAdmin_Click(object? sender, EventArgs e) => NaitaAdminiVorm(true);

        private void btnTagasi_Click(object? sender, EventArgs e) => NaitaAdminiVorm(false);

        private void NaitaAdminiVorm(bool admin)
        {
            btnOstja.Visible = !admin;
            btnAdmin.Visible = !admin;

            txtEmail.Visible = admin;
            txtParool.Visible = admin;
            btnLogin.Visible = admin;
            btnTagasi.Visible = admin;

            AcceptButton = admin ? btnLogin : btnOstja;   // Enter vajutab õiget nuppu
            lblVeateade.Text = "";
            txtParool.Clear();
            if (admin) txtEmail.Focus();
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
                {
                    NaitaAdminiVorm(false);
                    this.Show();
                }
                else
                    this.Close();
            };
            main.Show();
            this.Hide();
        }
    }
}
