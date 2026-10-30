using System.ComponentModel.DataAnnotations.Schema;

namespace Automaatne_andmebaasi_loomine
{
    public class Toode
    {
        public int Id { get; set; }
        public string Toodenimetus { get; set; } = string.Empty;
        public int Kogus { get; set; }
        public float Hind { get; set; }
        public string Pilt { get; set; } = string.Empty;
        public int KategooriaId { get; set; }
        public Kategooria Kategooria { get; set; } = null!;

        public string? Kirjeldus { get; set; }      // tootekaardil näidatav tekst
        public float? SoodusHind { get; set; }      // kui on väiksem kui Hind, on toode soodushinnaga

        // Hind, millega toodet praegu müüakse (soodushind, kui see kehtib)
        [NotMapped]
        public float HetkeHind => OnSoodus ? SoodusHind!.Value : Hind;

        [NotMapped]
        public bool OnSoodus => SoodusHind.HasValue && SoodusHind.Value > 0 && SoodusHind.Value < Hind;

        [NotMapped]
        public int SoodusProtsent => OnSoodus ? (int)Math.Round((1 - SoodusHind!.Value / Hind) * 100) : 0;
    }
}
