using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    // Tehtud ost. Read hoiavad toote nime ja hinda ostu hetkel (hilisem hinnamuutus neid ei mõjuta).
    public class Tellimus
    {
        public int Id { get; set; }
        public string Nr { get; set; } = string.Empty;          // sama number on ka PDF-arvel
        public int? KasutajaId { get; set; }                     // null = külaline
        public DateTime Kuupaev { get; set; }
        public string Email { get; set; } = string.Empty;        // kuhu arve saadeti
        [Precision(18, 2)]
        public decimal Summa { get; set; }                       // tasutud summa (pärast soodustust)
        [Precision(18, 2)]
        public decimal Soodustus { get; set; }
        public string? Sooduskood { get; set; }
        public string? PdfFail { get; set; }

        public ICollection<TellimuseRida> Read { get; set; } = new List<TellimuseRida>();
    }

    public class TellimuseRida
    {
        public int Id { get; set; }
        public int TellimusId { get; set; }
        public Tellimus Tellimus { get; set; } = null!;
        public int ToodeId { get; set; }
        public string Toodenimetus { get; set; } = string.Empty;
        [Precision(18, 2)]
        public decimal Hind { get; set; }
        public int Kogus { get; set; }
    }

    // Ostja lemmiktoode
    public class Lemmik
    {
        public int Id { get; set; }
        public int KasutajaId { get; set; }
        public Kasutaja Kasutaja { get; set; } = null!;
        public int ToodeId { get; set; }
        public Toode Toode { get; set; } = null!;
    }
}
