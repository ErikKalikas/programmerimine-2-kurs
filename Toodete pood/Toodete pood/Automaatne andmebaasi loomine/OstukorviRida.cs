namespace Automaatne_andmebaasi_loomine
{
    public class OstukorviRida
    {
        public Toode Toode { get; set; } = null!;
        public int Kogus { get; set; }

        // Arvutus decimal'iga ja ümardus sentideni, et ei tekiks nt 30,000002. Soodushind arvestatakse.
        public float Summa => (float)Math.Round((decimal)Toode.HetkeHind * Kogus, 2);

        public override string ToString()
        {
            string soodus = Toode.OnSoodus ? $"  (−{Toode.SoodusProtsent}%)" : "";
            return $"{Toode.Toodenimetus} – {Kogus} tk × {Toode.HetkeHind:0.00} € = {Summa:0.00} €{soodus}";
        }
    }
}
