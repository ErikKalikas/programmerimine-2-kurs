using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    // Andmebaasi loomine ja algandmed. Seda kutsutakse üks kord programmi alguses (Program.cs).
    public static class AlgAndmed
    {
        public static void Loo()
        {
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

            // Kategooriad (Joogid, Toit, Muu) tulevad HasData kaudu, vt ToodedContext.OnModelCreating

            // Näidistooted lisame ainult siis, kui tooteid veel üldse pole (esimene käivitus)
            if (!db.Toodetabel.Any())
                LisaNaidisTooted(db);
        }

        // Lisab näidistooted koos piltidega (pildid on programmi kaustas Images)
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
                ("Avokaado", 20, 1.19m, "avokaado.jpg", "Toit"),
                ("Tomat", 45, 0.30m, "tomat.jpg", "Toit"),
                ("Kartul", 100, 0.15m, "kartul.jpg", "Toit"),
                ("Sibul", 70, 0.12m, "sibul.jpg", "Toit"),
                ("Mango", 20, 1.49m, "mango.jpg", "Toit"),
                ("Porgand", 80, 0.20m, "porgand.jpg", "Toit"),
                ("Kurk", 30, 0.99m, "kurk.jpg", "Toit"),
                ("Paprika punane", 30, 0.79m, "paprika.jpg", "Toit"),
                ("Õunamahl Bravo 1 l", 25, 2.19m, "mahl_oun_bravo.jpg", "Joogid"),
                ("Apelsinimahl Bravo 1 l", 25, 2.19m, "mahl_apelsin_bravo.jpg", "Joogid"),
                ("Apelsinimahl Tropicana 1 l", 20, 3.49m, "mahl_tropicana.jpg", "Joogid"),
                ("Greibimahl Tropicana 1 l", 15, 3.49m, "mahl_greip_tropicana.jpg", "Joogid"),
                ("Mandariinimahl Tropicana 1 l", 15, 3.49m, "mahl_mandariin_tropicana.jpg", "Joogid"),
                ("Apelsini-greibimahl God Morgon 1 l", 20, 2.79m, "mahl_godmorgon.jpg", "Joogid"),
                ("Piim Arla 3% 1 l", 40, 1.29m, "piim_arla.jpg", "Joogid"),
                ("Piim Arla 1,5% 1 l", 40, 1.19m, "piim_arla_15.jpg", "Joogid"),
                ("Laktoosivaba piim Arla 1 l", 25, 1.59m, "piim_laktoosivaba.jpg", "Joogid"),
                ("Kaerajook Oatly 1 l", 25, 2.49m, "kaerajook_oatly.jpg", "Joogid"),
                ("Sojajook Alpro 1 l", 20, 2.29m, "sojajook_alpro.jpg", "Joogid"),
                ("Hapupiim Arla 1 l", 30, 1.39m, "hapupiim_arla.jpg", "Joogid"),
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

        // Näidistoodetele kirjeldus ja mõnele soodushind
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
                var soodus = new Dictionary<string, decimal>
                {
                    ["Banaan"] = 0.25m,
                    ["Apelsinimahl Tropicana 1 l"] = 2.79m,
                    ["Kaerajook Oatly 1 l"] = 1.99m,
                    ["Pusa must"] = 27.99m,
                };
                foreach (var t in db.Toodetabel.ToList())
                    if (soodus.TryGetValue(t.Toodenimetus, out decimal h))
                        t.SoodusHind = h;
            }

            db.SaveChanges();
        }
    }
}
