using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Automaatne_andmebaasi_loomine
{
    // Üks ostukorv kogu programmi jaoks: sama korv on näha poes (Form3) ja arvel (ArveForm).
    // Korv salvestatakse faili, nii et see jääb alles ka pärast programmi sulgemist.
    public static class Ostukorv
    {
        public static List<OstukorviRida> Ridad { get; } = new();

        public static string? Sooduskood { get; private set; }
        public static int SoodusProtsent { get; private set; }

        public static float Vahesumma => (float)Math.Round(Ridad.Sum(r => (decimal)r.Summa), 2);
        public static float Soodustus => (float)Math.Round((decimal)Vahesumma * SoodusProtsent / 100m, 2);
        public static float Kokku => (float)Math.Round((decimal)Vahesumma - (decimal)Soodustus, 2);
        public static int TooteidKokku => Ridad.Sum(r => r.Kogus);

        // Lisab toote korvi. Tagastab veateate või null, kui lisamine õnnestus.
        public static string? Lisa(Toode toode, int kogus)
        {
            if (kogus <= 0) return "Vale kogus.";
            if (toode.Kogus <= 0) return $"{toode.Toodenimetus} on otsas.";

            var olemas = Ridad.FirstOrDefault(r => r.Toode.Id == toode.Id);
            int korvis = olemas?.Kogus ?? 0;

            if (korvis + kogus > toode.Kogus)
                return $"Laos on ainult {toode.Kogus} tk (korvis juba {korvis} tk).";

            if (olemas != null)
                olemas.Kogus += kogus;
            else
                Ridad.Add(new OstukorviRida { Toode = toode, Kogus = kogus });

            Salvesta();
            return null;
        }

        // Muudab rea kogust (+1 / -1). Kui kogus jõuab nulli, rida eemaldatakse.
        public static string? MuudaKogust(int indeks, int muutus)
        {
            if (indeks < 0 || indeks >= Ridad.Count) return null;
            var rida = Ridad[indeks];

            int uus = rida.Kogus + muutus;
            if (uus > rida.Toode.Kogus) return $"Laos on ainult {rida.Toode.Kogus} tk.";

            if (uus <= 0) Ridad.RemoveAt(indeks);
            else rida.Kogus = uus;

            Salvesta();
            return null;
        }

        public static void Eemalda(int indeks)
        {
            if (indeks < 0 || indeks >= Ridad.Count) return;
            Ridad.RemoveAt(indeks);
            Salvesta();
        }

        // Tagastab veateate või null, kui kood kehtib
        public static string? RakendaKood(string kood)
        {
            int? p = Sooduskoodid.Protsent(kood);
            if (p == null) return "Sellist sooduskoodi pole.";

            Sooduskood = kood.Trim().ToUpper();
            SoodusProtsent = p.Value;
            return null;
        }

        public static void EemaldaKood()
        {
            Sooduskood = null;
            SoodusProtsent = 0;
        }

        // Ost on tehtud: salvestab tellimuse, vähendab laoseisu ja tühjendab korvi
        public static Tellimus KinnitaOst(string nr, string email, string pdfFail)
        {
            using var db = new ToodedContext();

            var tellimus = new Tellimus
            {
                Nr = nr,
                KasutajaId = AktiivneKasutaja.Id,
                Kuupaev = DateTime.Now,
                Email = email,
                Summa = Kokku,
                Soodustus = Soodustus,
                Sooduskood = Sooduskood,
                PdfFail = pdfFail
            };

            foreach (var rida in Ridad)
            {
                tellimus.Read.Add(new TellimuseRida
                {
                    ToodeId = rida.Toode.Id,
                    Toodenimetus = rida.Toode.Toodenimetus,
                    Hind = rida.Toode.HetkeHind,
                    Kogus = rida.Kogus
                });

                var toode = db.Toodetabel.Find(rida.Toode.Id);
                if (toode != null)
                    toode.Kogus = Math.Max(0, toode.Kogus - rida.Kogus);
            }

            db.Tellimused.Add(tellimus);
            db.SaveChanges();

            Ridad.Clear();
            EemaldaKood();
            Salvesta();
            return tellimus;
        }

        // Tühjendab korvi mälus (väljalogimisel), faili ei puuduta
        public static void Unusta()
        {
            Ridad.Clear();
            EemaldaKood();
        }

        // ---------- Salvestamine faili ----------

        private record SalvestatudRida(int ToodeId, int Kogus);

        // Iga konto korv on eraldi failis, külalisel oma fail
        private static string Fail
        {
            get
            {
                string kaust = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ToodedApp");
                Directory.CreateDirectory(kaust);
                string kes = AktiivneKasutaja.Id?.ToString() ?? "kulaline";
                return Path.Combine(kaust, $"ostukorv_{kes}.json");
            }
        }

        private static void Salvesta()
        {
            try
            {
                var read = Ridad.Select(r => new SalvestatudRida(r.Toode.Id, r.Kogus)).ToList();
                File.WriteAllText(Fail, JsonSerializer.Serialize(read));
            }
            catch (IOException) { }   // korvi salvestamata jäämine ei tohi programmi katki teha
        }

        // Laeb sisselogitud kasutaja (või külalise) korvi failist; hinnad ja laoseis tulevad andmebaasist
        public static void Lae()
        {
            Unusta();
            if (!File.Exists(Fail)) return;

            List<SalvestatudRida>? read;
            try { read = JsonSerializer.Deserialize<List<SalvestatudRida>>(File.ReadAllText(Fail)); }
            catch (Exception) { return; }
            if (read == null) return;

            using var db = new ToodedContext();
            var idd = read.Select(r => r.ToodeId).ToList();
            var tooted = db.Toodetabel.AsNoTracking().Where(t => idd.Contains(t.Id)).ToList();

            foreach (var r in read)
            {
                var toode = tooted.FirstOrDefault(t => t.Id == r.ToodeId);
                if (toode == null || toode.Kogus <= 0) continue;   // toodet pole enam või on otsas
                Ridad.Add(new OstukorviRida { Toode = toode, Kogus = Math.Min(r.Kogus, toode.Kogus) });
            }
        }
    }
}
