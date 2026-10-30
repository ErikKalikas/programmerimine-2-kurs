namespace Automaatne_andmebaasi_loomine
{
    // Kehtivad sooduskoodid: kood -> allahindluse protsent
    public static class Sooduskoodid
    {
        private static readonly Dictionary<string, int> Koodid = new(StringComparer.OrdinalIgnoreCase)
        {
            ["TERE10"] = 10,     // 10% kogu ostult
            ["SOODUS20"] = 20,   // 20% kogu ostult
        };

        public static int? Protsent(string kood) =>
            Koodid.TryGetValue(kood.Trim(), out int p) ? p : null;
    }
}
