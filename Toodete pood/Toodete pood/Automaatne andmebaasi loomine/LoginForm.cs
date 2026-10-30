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

            LisaKirjeldusedJaSoodustused(db);
        }

        // Näidistoodetele kirjeldus ja mõnele soodushind (ainult siis, kui neid veel pole)
        private static void LisaKirjeldusedJaSoodustused(ToodedContext db)
        {
            var kirjeldused = new Dictionary<string, string>
            {
                ["Õun"] = "Mahlane ja magus Royal Gala õun.",
                ["Banaan"] = "Küps kollane banaan, hea vahepala.",
                ["Apelsin"] = "Mahlane apelsin, palju C-vitamiini.",
                ["Sidrun"] = "Hapukas sidrun teesse ja küpsetistesse.",
                ["Pirn"] = "Magus Conference pirn.",
                ["Kiivi"] = "Roheline kiivi, söö lusikaga.",
                ["Ananass"] = "Terve ananass, magus ja aromaatne.",
                ["Arbuus"] = "Värskendav arbuus suveks.",
                ["Avokaado"] = "Kreemjas avokaado salatisse ja võileivale.",
                ["Tomat"] = "Punane tomat salatisse.",
                ["Kartul"] = "Eesti kartul keetmiseks ja praadimiseks.",
                ["Sibul"] = "Kollane sibul toidu maitsestamiseks.",
                ["Mango"] = "Küps ja magus mango.",
                ["Porgand"] = "Krõmpsuv porgand.",
                ["Kurk"] = "Värske kurk.",
                ["Paprika punane"] = "Magus punane paprika.",
                ["Õunamahl Bravo 1 l"] = "100% õunamahl, 1 liiter.",
                ["Apelsinimahl Bravo 1 l"] = "100% apelsinimahl, 1 liiter.",
                ["Apelsinimahl Tropicana 1 l"] = "Viljalihata apelsinimahl, 1 liiter.",
                ["Greibimahl Tropicana 1 l"] = "Kuldne greibimahl, 1 liiter.",
                ["Mandariinimahl Tropicana 1 l"] = "Mandariini- ja apelsinimahl, 1 liiter.",
                ["Apelsini-greibimahl God Morgon 1 l"] = "Apelsini ja punase greibi mahl, 1 liiter.",
                ["Piim Arla 3% 1 l"] = "Täispiim 3%, 1 liiter.",
                ["Piim Arla 1,5% 1 l"] = "Piim 1,5%, 1 liiter.",
                ["Laktoosivaba piim Arla 1 l"] = "Laktoosivaba piim 1,5%, 1 liiter.",
                ["Kaerajook Oatly 1 l"] = "Taimne kaerajook, 1 liiter.",
                ["Sojajook Alpro 1 l"] = "Taimne sojajook, 1 liiter.",
                ["Hapupiim Arla 1 l"] = "Hapupiim, 1 liiter.",
            };
            foreach (var t in db.Toodetabel.Where(t => t.Kirjeldus == null).ToList())
                if (kirjeldused.TryGetValue(t.Toodenimetus, out var tekst))
                    t.Kirjeldus = tekst;

            // Näidissoodustused, kui ühelgi tootel pole veel soodushinda
            if (!db.Toodetabel.Any(t => t.SoodusHind != null))
            {
                var soodus = new Dictionary<string, float>
                {
                    ["Banaan"] = 0.25f,
                    ["Apelsinimahl Tropicana 1 l"] = 2.79f,
                    ["Kaerajook Oatly 1 l"] = 1.99f,
                    ["Pusa must"] = 27.99f,
                };
                foreach (var t in db.Toodetabel.ToList())
                    if (soodus.TryGetValue(t.Toodenimetus, out float h))
                        t.SoodusHind = h;
            }

            db.SaveChanges();
        }

        // "" = algvaade, "klient" = ostja konto, "admin" = administraator
        private string reziim = "";

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            using var db = new ToodedContext();

            string email = txtEmail.Text.Trim().ToLower();
            string parool = txtParool.Text;

            var kasutaja = db.Kasutajad.FirstOrDefault(k => k.Email.ToLower() == email);

            if (kasutaja == null || !PasswordHelper.Verify(parool, kasutaja.ParoolHash))
            {
                lblVeateade.Text = "Vale e-post või parool!";
                txtParool.Clear();
                return;
            }

            if (kasutaja.Blokeeritud)
            {
                lblVeateade.Text = "See konto on blokeeritud.";
                return;
            }

            if (reziim == "admin" && kasutaja.Roll != "admin")
            {
                lblVeateade.Text = "See konto ei ole administraator!";
                return;
            }

            if (reziim == "klient" && kasutaja.Roll == "admin")
            {
                lblVeateade.Text = "Administraator logib sisse eraldi nupuga.";
                return;
            }

            AktiivneKasutaja.LogiSisse(kasutaja);
            if (kasutaja.Roll == "admin") Tegevuslogi.Kirjuta("Logis sisse administraatorina");
            AvaPeamenyy();
        }

        // Külaline: parooli pole vaja, saab poes osta
        private void btnOstja_Click(object? sender, EventArgs e)
        {
            AktiivneKasutaja.Kulaline();
            AvaPeamenyy();
        }

        private void btnKlient_Click(object? sender, EventArgs e) => NaitaVaade("klient");

        private void btnAdmin_Click(object? sender, EventArgs e) => NaitaVaade("admin");

        private void btnTagasi_Click(object? sender, EventArgs e) => NaitaVaade("");

        private void btnRegistreeru_Click(object? sender, EventArgs e)
        {
            using var f = new RegistreerimineForm();
            if (f.ShowDialog(this) == DialogResult.OK && f.UusKasutaja != null)
            {
                // pärast registreerimist ollakse kohe sisse logitud
                AktiivneKasutaja.LogiSisse(f.UusKasutaja);
                AvaPeamenyy();
            }
        }

        // Vahetab algvaate (nupud) ja sisselogimise vaate (e-post + parool)
        private void NaitaVaade(string uus)
        {
            reziim = uus;
            bool vorm = uus != "";

            btnOstja.Visible = !vorm;
            btnKlient.Visible = !vorm;
            btnRegistreeru.Visible = !vorm;
            btnAdmin.Visible = !vorm;

            lblPealkiri.Visible = vorm;
            lblPealkiri.Text = uus == "admin" ? "Administraatori sisselogimine" : "Kliendi sisselogimine";
            txtEmail.Visible = vorm;
            txtParool.Visible = vorm;
            btnLogin.Visible = vorm;
            btnTagasi.Visible = vorm;

            AcceptButton = vorm ? btnLogin : btnOstja;   // Enter vajutab õiget nuppu
            lblVeateade.Text = "";
            txtParool.Clear();
            if (vorm) txtEmail.Focus();
        }

        private void AvaPeamenyy()
        {
            lblVeateade.Text = "";
            txtParool.Clear();

            Ostukorv.Lae();   // eelmisel korral pooleli jäänud ostukorv

            FormMain main = new FormMain();
            main.FormClosed += (_, _) =>
            {
                // "Logi välja" tühjendab rolli: siis tuleb tagasi sisselogimise aken,
                // muidu (akna sulgemisel) sulgub kogu programm
                if (AktiivneKasutaja.Roll == "")
                {
                    NaitaVaade("");
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
