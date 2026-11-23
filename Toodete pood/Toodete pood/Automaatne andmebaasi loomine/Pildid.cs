namespace Automaatne_andmebaasi_loomine
{
    // Toodete pildid. Pilt loetakse mällu (fail ei jää lukku) ja hoitakse vahemälus,
    // et otsingu ajal ei peaks samu pilte iga kord uuesti kettalt lugema.
    //
    // Näidispildid tulevad programmiga kaasa (programmi kaust\Images).
    // Uued pildid (admin valib ise) salvestame kausta AppData\Local\ToodedApp\Images,
    // sest pärast installimist ei saa Program Files kausta kirjutada.
    public static class Pildid
    {
        private static readonly Dictionary<string, Image> Vahemalu = new();

        // Kaust, kuhu salvestatakse uued pildid ja logo
        public static string Kaust
        {
            get
            {
                string kaust = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ToodedApp", "Images");
                Directory.CreateDirectory(kaust);
                return kaust;
            }
        }

        // Leiab pildi faili: kõigepealt AppData kaustast, siis programmi kaustast. Kui pole, siis null.
        public static string? Tee(string? fail)
        {
            if (string.IsNullOrEmpty(fail)) return null;

            string tee = Path.Combine(Kaust, fail);
            if (File.Exists(tee)) return tee;

            tee = Path.Combine(AppContext.BaseDirectory, "Images", fail);
            if (File.Exists(tee)) return tee;

            return null;
        }

        // Kopeerib valitud pildi AppData kausta.
        // Kui valiti pilt, mis juba ongi selles kaustas, siis ei kopeeri (muidu File.Copy annab vea).
        public static void Salvesta(string valitudFail, string failinimi)
        {
            string uusTee = Path.Combine(Kaust, failinimi);

            if (Path.GetFullPath(valitudFail).ToLower() != Path.GetFullPath(uusTee).ToLower())
                File.Copy(valitudFail, uusTee, true);

            Vahemalu.Remove(failinimi);   // kui sama nimega pilt oli vahemälus, siis laeme uuesti
        }

        public static Image? Lae(string? fail)
        {
            if (string.IsNullOrEmpty(fail)) return null;
            if (Vahemalu.TryGetValue(fail, out var pilt)) return pilt;

            string? tee = Tee(fail);
            if (tee == null) return null;

            pilt = Image.FromStream(new MemoryStream(File.ReadAllBytes(tee)));
            Vahemalu[fail] = pilt;
            return pilt;
        }
    }
}
