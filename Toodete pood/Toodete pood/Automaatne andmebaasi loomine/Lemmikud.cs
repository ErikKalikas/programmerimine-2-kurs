namespace Automaatne_andmebaasi_loomine
{
    // Sisselogitud ostja lemmiktooted andmebaasis
    public static class LemmikTooted
    {
        public static HashSet<int> Koik()
        {
            if (!AktiivneKasutaja.OnKonto) return new HashSet<int>();
            using var db = new ToodedContext();
            return db.Lemmikud.Where(l => l.KasutajaId == AktiivneKasutaja.Id)
                              .Select(l => l.ToodeId).ToHashSet();
        }

        public static bool OnLemmik(int toodeId)
        {
            if (!AktiivneKasutaja.OnKonto) return false;
            using var db = new ToodedContext();
            return db.Lemmikud.Any(l => l.KasutajaId == AktiivneKasutaja.Id && l.ToodeId == toodeId);
        }

        // Lisab või eemaldab; tagastab, kas toode on pärast seda lemmik
        public static bool Vaheta(int toodeId)
        {
            if (!AktiivneKasutaja.OnKonto) return false;
            using var db = new ToodedContext();

            var olemas = db.Lemmikud.FirstOrDefault(l => l.KasutajaId == AktiivneKasutaja.Id && l.ToodeId == toodeId);
            if (olemas != null)
            {
                db.Lemmikud.Remove(olemas);
                db.SaveChanges();
                return false;
            }

            db.Lemmikud.Add(new Lemmik { KasutajaId = AktiivneKasutaja.Id!.Value, ToodeId = toodeId });
            db.SaveChanges();
            return true;
        }
    }
}
