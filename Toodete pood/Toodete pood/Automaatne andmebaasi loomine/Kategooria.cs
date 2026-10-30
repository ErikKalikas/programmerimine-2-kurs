using System;
using System.Collections.Generic;
using System.Text;

namespace Automaatne_andmebaasi_loomine
{
    public class Kategooria
    {
        public int Id { get; set; }
        public string Kategooria_nimetus { get; set; } = string.Empty;
        public string Kirjeldus { get; set; } = string.Empty;
        public ICollection<Toode> Tooded { get; set; } = new List<Toode>();
    }
}
