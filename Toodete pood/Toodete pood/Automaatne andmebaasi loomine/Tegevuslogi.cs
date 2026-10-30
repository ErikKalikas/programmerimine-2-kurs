namespace Automaatne_andmebaasi_loomine
{
    // Üks rida tegevuste logis: kes, millal ja mida muutis
    public class LogiKirje
    {
        public int Id { get; set; }
        public DateTime Aeg { get; set; }
        public string Kasutaja { get; set; } = string.Empty;
        public string Tegevus { get; set; } = string.Empty;
    }

    public static class Tegevuslogi
    {
        public static void Kirjuta(string tegevus)
        {
            try
            {
                using var db = new ToodedContext();
                db.Logid.Add(new LogiKirje
                {
                    Aeg = DateTime.Now,
                    Kasutaja = AktiivneKasutaja.OnKonto ? AktiivneKasutaja.Email : "külaline",
                    Tegevus = tegevus
                });
                db.SaveChanges();
            }
            catch (Exception) { }   // logi kirjutamise viga ei tohi tegevust ennast katki teha
        }
    }
}
