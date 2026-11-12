namespace Automaatne_andmebaasi_loomine
{
    // Põhiaken (kogu ekraanil): vasakul menüü, üleval pealkiri ja ostukorv, keskel avatud leht.
    // Lehed (pood, ostukorv, tellimused, tootehaldus jne) avanevad samas aknas, eraldi aknaid ei pea sulgema.
    public partial class FormMain : BaasVorm
    {
        // Praegu avatud põhiaken, et lehed saaksid teise lehe avada (nt poest ostukorvi)
        public static FormMain? Aktiivne { get; private set; }

        private Form? leht;
        private Func<Form>? lehtLooja;
        private UmarNupp? aktiivneNupp;

        public FormMain()
        {
            InitializeComponent();
            Aktiivne = this;

            // nuppude eestikeelsed tekstid jäävad meelde, et keele vahetamisel uuesti tõlkida
            foreach (var nupp in KoikNupud())
                nupp.Tag = nupp.Text;

            LooMenyy();
            UuendaTekstid();
            UuendaKorvi();

            Ostukorv.Muudetud += UuendaKorvi;
            Keel.Muutus += Keel_Muutus;
            FormClosed += (_, _) =>
            {
                Ostukorv.Muudetud -= UuendaKorvi;
                Keel.Muutus -= Keel_Muutus;
                if (Aktiivne == this) Aktiivne = null;
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // admin alustab tootehaldusest, ostja poest
            if (AktiivneKasutaja.Roll == "admin")
                btnTooted_Click(null, EventArgs.Empty);
            else
                btnPood_Click(null, EventArgs.Empty);
        }

        private IEnumerable<UmarNupp> KoikNupud() => new[]
        {
            btnPood, btnArve, btnTellimused, btnLemmikud, btnProfiil, btnTooted, btnKategooriad,
            btnKoikTellimused, btnAruanded, btnKasutajad, btnLogi, btnSeaded, btnLogiValja, btnKorv
        };

        // Menüüsse ainult need nupud, mida see kasutaja tohib kasutada
        private void LooMenyy()
        {
            flpMenyy.Controls.Clear();

            if (AktiivneKasutaja.Roll == "admin")
            {
                LisaPealkiri("HALDUS");
                LisaNupud(btnTooted, btnKategooriad, btnKoikTellimused, btnAruanded, btnKasutajad, btnLogi, btnSeaded);
                LisaPealkiri("POOD");
                LisaNupud(btnPood, btnArve, btnProfiil);
            }
            else if (AktiivneKasutaja.OnKonto)
            {
                LisaPealkiri("POOD");
                LisaNupud(btnPood, btnArve, btnTellimused, btnLemmikud, btnProfiil);
            }
            else
            {
                // külaline näeb ainult poodi ja ostukorvi
                LisaPealkiri("POOD");
                LisaNupud(btnPood, btnArve);
                btnLogiValja.Tag = "Tagasi algusesse";
            }
        }

        private void LisaPealkiri(string tekst)
        {
            flpMenyy.Controls.Add(new Label
            {
                Text = Keel.T(tekst),
                Tag = tekst,
                AutoSize = false,
                Size = new Size(220, 30),
                Margin = new Padding(4, 12, 0, 2),
                TextAlign = ContentAlignment.BottomLeft,
                Font = Teema.Vaike,
                ForeColor = Color.FromArgb(130, 130, 138)
            });
        }

        private void LisaNupud(params UmarNupp[] nupud)
        {
            foreach (var n in nupud)
            {
                n.Size = new Size(228, 44);
                n.Margin = new Padding(0, 0, 0, 4);
                flpMenyy.Controls.Add(n);
            }
        }

        private void UuendaTekstid()
        {
            foreach (var nupp in KoikNupud())
                if (nupp.Tag is string eesti) nupp.Text = Keel.T(eesti);
            foreach (Control c in flpMenyy.Controls)
                if (c is Label l && l.Tag is string eesti) l.Text = Keel.T(eesti);

            var pood = PoeSeaded.Lae();
            lblPoeNimi.Text = pood.PoeNimi;
            lblLogoTaht.Text = pood.PoeNimi.Length > 0 ? pood.PoeNimi[..1].ToUpper() : "T";
            UuendaTervitus();
            UuendaKorvi();
        }

        public void UuendaTervitus()
        {
            lblTere.Text = AktiivneKasutaja.Roll == "admin" ? Keel.T("Administraator: {0}", AktiivneKasutaja.Nimi)
                         : AktiivneKasutaja.OnKonto ? Keel.T("Tere, {0}!", AktiivneKasutaja.Nimi)
                         : Keel.T("Tere, külaline!");
            Text = $"{lblPoeNimi.Text} – {lblTere.Text}";
        }

        private void UuendaKorvi()
        {
            btnKorv.Text = Keel.T("Ostukorv") + $"  ·  {Ostukorv.TooteidKokku} {Keel.T("tk")}  ·  {Ostukorv.Kokku:0.00} €";
        }

        // Keel vahetati: tõlgime menüü ja avame praeguse lehe uuesti juba uues keeles
        private void Keel_Muutus()
        {
            UuendaTekstid();
            if (lehtLooja != null) Ava(lehtLooja, aktiivneNupp);
        }

        // Avab lehe põhiakna sees (vana leht suletakse)
        private void Ava(Func<Form> looja, UmarNupp? nupp)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var uus = looja();
                uus.TopLevel = false;
                uus.FormBorderStyle = FormBorderStyle.None;
                uus.Dock = DockStyle.Fill;

                pnlSisu.SuspendLayout();
                pnlSisu.Controls.Add(uus);
                uus.Show();   // siin rakendub kujundus ja tõlge (BaasVorm.OnLoad)

                if (leht != null)
                {
                    pnlSisu.Controls.Remove(leht);
                    leht.Dispose();
                }
                pnlSisu.ResumeLayout();

                leht = uus;
                lehtLooja = looja;
                lblPealkiri.Text = uus.Text;
                uus.TextChanged += (_, _) => lblPealkiri.Text = uus.Text;

                if (aktiivneNupp != null) aktiivneNupp.Aktiivne = false;
                aktiivneNupp = nupp;
                if (nupp != null && nupp.Stiil == NupuStiil.Menyy) nupp.Aktiivne = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Teistelt lehtedelt kasutamiseks. BeginInvoke: vana leht suletakse alles pärast seda,
        // kui tema nupuvajutuse käsitlemine on lõppenud.
        public void AvaPood() => BeginInvoke(() => Ava(() => new Form3(), btnPood));

        public void AvaOstukorv(Toode? toode = null) =>
            BeginInvoke(() => Ava(() => new ArveForm { SelectedToode = toode }, btnArve));

        private void btnLogiValja_Click(object? sender, EventArgs e)
        {
            AktiivneKasutaja.LogiValja();   // LoginForm näeb tühja rolli ja avab end uuesti
            Ostukorv.Unusta();              // korv jääb faili alles järgmiseks korraks
            Close();
        }

        private void btnPood_Click(object? sender, EventArgs e) => Ava(() => new Form3(), btnPood);
        private void btnArve_Click(object? sender, EventArgs e) => Ava(() => new ArveForm(), btnArve);
        private void btnTellimused_Click(object? sender, EventArgs e) => Ava(() => new TellimusedForm(), btnTellimused);
        private void btnLemmikud_Click(object? sender, EventArgs e) => Ava(() => new LemmikudForm(), btnLemmikud);
        private void btnProfiil_Click(object? sender, EventArgs e) => Ava(() => new ProfiilForm(), btnProfiil);
        private void btnTooted_Click(object? sender, EventArgs e) => Ava(() => new Form2(), btnTooted);
        private void btnKategooriad_Click(object? sender, EventArgs e) => Ava(() => new KategooriadForm(), btnKategooriad);
        private void btnKoikTellimused_Click(object? sender, EventArgs e) => Ava(() => new KoikTellimusedForm(), btnKoikTellimused);
        private void btnAruanded_Click(object? sender, EventArgs e) => Ava(() => new AruandedForm(), btnAruanded);
        private void btnKasutajad_Click(object? sender, EventArgs e) => Ava(() => new KasutajadForm(), btnKasutajad);
        private void btnLogi_Click(object? sender, EventArgs e) => Ava(() => new LogiForm(), btnLogi);
        private void btnSeaded_Click(object? sender, EventArgs e) => Ava(() => new SeadedForm(), btnSeaded);

        // Poe nimi võis seadetes muutuda
        public void UuendaPoeNime() => UuendaTekstid();
    }
}
