namespace Automaatne_andmebaasi_loomine
{
    public class OstukorviRida
    {
        public Toode Toode { get; set; } = null!;
        public int Kogus { get; set; }

        // Rea summa, ümardatud sentideni. Soodushind arvestatakse.
        public decimal Summa => Math.Round(Toode.HetkeHind * Kogus, 2);

        public override string ToString()
        {
            string soodus = Toode.OnSoodus ? $"  (−{Toode.SoodusProtsent}%)" : "";
            return $"{Toode.Toodenimetus} – {Kogus} tk × {Toode.HetkeHind:0.00} € = {Summa:0.00} €{soodus}";
        }
    }
}
