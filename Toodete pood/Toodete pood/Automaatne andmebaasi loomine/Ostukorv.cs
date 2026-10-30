namespace Automaatne_andmebaasi_loomine
{
    // Üks ostukorv kogu programmi jaoks: sama korv on näha poes (Form3) ja arvel (ArveForm)
    public static class Ostukorv
    {
        public static List<OstukorviRida> Ridad { get; } = new();

        public static float Kokku => Ridad.Sum(r => r.Summa);

        // Lisab toote korvi. Tagastab veateate või null, kui lisamine õnnestus.
        public static string? Lisa(Toode toode, int kogus)
        {
            if (kogus <= 0) return "Vale kogus.";

            var olemas = Ridad.FirstOrDefault(r => r.Toode.Id == toode.Id);
            int korvis = olemas?.Kogus ?? 0;

            if (korvis + kogus > toode.Kogus)
                return $"Laos on ainult {toode.Kogus} tk (korvis juba {korvis} tk).";

            if (olemas != null)
                olemas.Kogus += kogus;
            else
                Ridad.Add(new OstukorviRida { Toode = toode, Kogus = kogus });

            return null;
        }

        // Ost on tehtud: vähendab laoseisu andmebaasis ja tühjendab korvi
        public static void KinnitaOst()
        {
            using var db = new ToodedContext();
            foreach (var rida in Ridad)
            {
                var toode = db.Toodetabel.Find(rida.Toode.Id);
                if (toode != null)
                    toode.Kogus = Math.Max(0, toode.Kogus - rida.Kogus);
            }
            db.SaveChanges();
            Ridad.Clear();
        }
    }
}
