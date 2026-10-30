namespace Automaatne_andmebaasi_loomine
{
    // Toodete pildid kaustast Images. Pilt loetakse mällu (fail ei jää lukku) ja hoitakse vahemälus,
    // et otsingu ajal ei peaks samu pilte iga kord uuesti kettalt lugema.
    public static class Pildid
    {
        private static readonly Dictionary<string, Image> Vahemalu = new();

        public static Image? Lae(string? fail)
        {
            if (string.IsNullOrEmpty(fail)) return null;
            if (Vahemalu.TryGetValue(fail, out var pilt)) return pilt;

            string tee = Path.Combine("Images", fail);
            if (!File.Exists(tee)) return null;

            pilt = Image.FromStream(new MemoryStream(File.ReadAllBytes(tee)));
            Vahemalu[fail] = pilt;
            return pilt;
        }
    }
}
