namespace Automaatne_andmebaasi_loomine
{
    public class Kasutaja
    {
        public int Id { get; set; }
        public string Nimi { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ParoolHash { get; set; } = string.Empty;
        public string Roll { get; set; } = string.Empty; // "admin" või "kasutaja"
        public string Telefon { get; set; } = string.Empty;
        public string Aadress { get; set; } = string.Empty;
    }
}
