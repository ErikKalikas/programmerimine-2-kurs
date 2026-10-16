namespace Automaatne_andmebaasi_loomine
{
    public class OstukorviRida
    {
        public Toode Toode { get; set; } = null!;
        public int Kogus { get; set; }

        public float Summa => Toode.Hind * Kogus;

        public override string ToString()
        {
            return $"{Toode.Toodenimetus} – {Kogus} tk – {Summa} €";
        }
    }
}
