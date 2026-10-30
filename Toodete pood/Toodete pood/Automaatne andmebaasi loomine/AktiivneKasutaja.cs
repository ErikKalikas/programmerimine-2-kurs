namespace Automaatne_andmebaasi_loomine
{
    public static class AktiivneKasutaja
    {
        public static string Roll { get; set; } = string.Empty;   // "admin", "kasutaja" või "" (pole sisse logitud)
        public static int? Id { get; set; }                        // null = külaline (ilma kontota ostja)
        public static string Nimi { get; set; } = string.Empty;
        public static string Email { get; set; } = string.Empty;

        public static bool OnKonto => Id.HasValue;

        public static void LogiSisse(Kasutaja k)
        {
            Roll = k.Roll;
            Id = k.Id;
            Nimi = k.Nimi;
            Email = k.Email;
        }

        public static void Kulaline()
        {
            Roll = "kasutaja";
            Id = null;
            Nimi = string.Empty;
            Email = string.Empty;
        }

        public static void LogiValja()
        {
            Roll = string.Empty;
            Id = null;
            Nimi = string.Empty;
            Email = string.Empty;
        }
    }
}
