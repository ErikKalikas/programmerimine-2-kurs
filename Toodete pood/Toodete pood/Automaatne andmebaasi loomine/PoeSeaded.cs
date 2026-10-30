namespace Automaatne_andmebaasi_loomine
{
    // Poe andmed arve jaoks ja muud seaded (andmebaasis üks rida)
    public class PoeSeaded
    {
        public int Id { get; set; }
        public string PoeNimi { get; set; } = "Toodete pood";
        public string Hyydlause { get; set; } = "Värsked tooted iga päev";
        public string Aadress { get; set; } = string.Empty;
        public string Registrikood { get; set; } = string.Empty;
        public string KmkrNr { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public float KmProtsent { get; set; } = 24;     // Eesti käibemaks alates 01.07.2025
        public string? Logo { get; set; }                // pildifail kaustas Images
        public string KirjaTeema { get; set; } = "Arve nr {nr}";
        public string KirjaSisu { get; set; } = "Tere{nimi}!\n\nAitäh ostu eest. Arve summas {summa} on manuses.\n\n{pood}";

        // Tagastab seaded; kui neid veel pole, luuakse vaikeväärtustega
        public static PoeSeaded Lae()
        {
            using var db = new ToodedContext();
            var s = db.Seaded.OrderBy(x => x.Id).FirstOrDefault();
            if (s == null)
            {
                s = new PoeSeaded();
                db.Seaded.Add(s);
                db.SaveChanges();
            }
            return s;
        }
    }
}
