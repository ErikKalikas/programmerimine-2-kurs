namespace Automaatne_andmebaasi_loomine
{
    public class OstukorviRida
    {
        public Toode Toode { get; set; } = null!;
        public int Kogus { get; set; }

        // Arvutus decimal'iga ja ümardus sentideni, et ei tekiks nt 30,000002
        public float Summa => (float)Math.Round((decimal)Toode.Hind * Kogus, 2);

        public override string ToString()
        {
            return $"{Toode.Toodenimetus} – {Kogus} tk – {Summa:0.00} €";
        }
    }
}
