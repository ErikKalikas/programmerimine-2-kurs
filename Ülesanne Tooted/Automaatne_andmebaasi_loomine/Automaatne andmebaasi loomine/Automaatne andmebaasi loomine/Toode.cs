using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
