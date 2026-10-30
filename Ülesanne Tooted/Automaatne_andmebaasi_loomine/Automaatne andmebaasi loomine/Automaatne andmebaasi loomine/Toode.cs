namespace Automaatne_andmebaasi_loomine
{
    public class Toode
    {
        public int Id { get; set; }
        public string Toodenimetus { get; set; } = string.Empty;
        public int Kogus { get; set; }
        public decimal Hind { get; set; }
        public string? Pilt { get; set; }   // pilt ei ole kohustuslik
        public int KategooriaId { get; set; }
        public Kategooria Kategooria { get; set; } = null!;
    }
}
