using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    public class Toode
    {
        public int Id { get; set; }
        public string Toodenimetus { get; set; } = string.Empty;
        public int Kogus { get; set; }
        [Precision(18, 2)]
        public decimal Hind { get; set; }            // raha jaoks decimal, float annaks ümardusvigu
        public string Pilt { get; set; } = string.Empty;
        public int KategooriaId { get; set; }
        public Kategooria Kategooria { get; set; } = null!;

        public string? Kirjeldus { get; set; }      // tootekaardil näidatav tekst
        [Precision(18, 2)]
        public decimal? SoodusHind { get; set; }    // kui on väiksem kui Hind, on toode soodushinnaga
        public DateTime? SoodusKuni { get; set; }   // soodushinna viimane päev (null = tähtajatu)

        // Hind, millega toodet praegu müüakse (soodushind, kui see kehtib)
        [NotMapped]
        public decimal HetkeHind => OnSoodus ? SoodusHind!.Value : Hind;

        [NotMapped]
        public bool OnSoodus => SoodusHind.HasValue && SoodusHind.Value > 0 && SoodusHind.Value < Hind
                                && (SoodusKuni == null || SoodusKuni.Value.Date >= DateTime.Today);

        [NotMapped]
        public int SoodusProtsent => OnSoodus ? (int)Math.Round((1 - SoodusHind!.Value / Hind) * 100) : 0;
    }
}
