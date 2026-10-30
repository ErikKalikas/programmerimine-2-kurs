using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    [Index(nameof(Email), IsUnique = true)]   // sama e-postiga kahte kasutajat ei saa olla
    public class Kasutaja
    {
        public int Id { get; set; }
        public string Nimi { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ParoolHash { get; set; } = string.Empty;
        public string Roll { get; set; } = string.Empty; // "admin" või "kasutaja"
    }
}
