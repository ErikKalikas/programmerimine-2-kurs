# Toodete pood

WinForms rakendus (.NET 10) + Entity Framework Core 8 + SQL Server LocalDB.
Pood, ostukorv, PDF-arve e-postiga, ostja konto ja administraatori osa.

## Käivitamine

1. Paigalda Visual Studio (.NET 10) ja **SQL Server LocalDB** (Visual Studio Installeris komponent "Data storage and processing").
2. Ava `Toodete pood/Automaatne andmebaasi loomine.slnx` ja vajuta F5.
3. Andmebaas `Tooded_DB` luuakse esimesel käivitamisel automaatselt (`Program.cs` → `AlgAndmed.Loo()` → `Database.Migrate()`).
   Samas lisatakse admin ja näidistooted, kui tooteid veel pole.
   Kategooriad Joogid, Toit ja Muu lisatakse `HasData` kaudu (`ToodedContext.OnModelCreating`).

Admin: `admin@admin.ee` / `admin123`. Sooduskoodid: `TERE10` (10%), `SOODUS20` (20%).

### Viga "Database 'Tooded_DB' already exists"

Andmebaas on LocalDB-s kirjas, aga seda ei saa avada (nt `.mdf` fail on kustutatud).
Programm küsib siis, kas teha uus andmebaas (vanad andmed kaovad). Käsitsi parandamine (cmd):

```
sqllocaldb stop MSSQLLocalDB
sqllocaldb delete MSSQLLocalDB
sqllocaldb create MSSQLLocalDB -s
```

Kui pärast seda tuleb viga "Cannot create file ... Tooded_DB.mdf", kustuta kaustast `C:\Users\<kasutaja>` failid `Tooded_DB.mdf` ja `Tooded_DB_log.ldf`.

## Uus migratsioon

Package Manager Console:

```
Add-Migration MigratsiooniNimi
Update-Database
```

`Update-Database` pole kohustuslik: programm rakendab uued migratsioonid käivitamisel ise.

## Arve saatmine Gmailiga (client_secret.json)

Arve saadetakse Gmail API kaudu, sisselogimine käib Google'i kontoga (OAuth 2.0).

1. Google Cloud Console'is: lülita sisse **Gmail API**, seadista **OAuth consent screen** (Audience: External, oma Gmail lisa Test users alla).
2. Loo **OAuth client ID**, tüüp **Desktop app**, ja vajuta **Download JSON**.
3. Nimeta fail ümber `client_secret.json` ja pane see projekti kausta (`.csproj` kõrvale). Build kopeerib selle programmi kausta.
4. Esimesel saatmisel avaneb brauser, kus tuleb Google'iga sisse logida ja anda luba kirjade saatmiseks.

`client_secret.json` on `.gitignore`-is ja seda GitHubi ei panda.
Token hoitakse kaustas `%AppData%\ToodedApp.Gmail`. Gmaili konto vahetamine: **Poe seaded → Vaheta Gmaili kontot**.

## Kuhu programm faile salvestab

Programmi kausta (nt Program Files) pärast installimist kirjutada ei saa, sellepärast:

| Mis | Kus |
|---|---|
| Näidispildid (tulevad programmiga) | programmi kaust `\Images` (ainult lugemiseks) |
| Uued tootepildid ja logo | `%LocalAppData%\ToodedApp\Images` |
| PDF-arved | `%LocalAppData%\ToodedApp\Arved` |
| Ostukorv ja valitud keel | `%AppData%\ToodedApp` |

## Poe kategooriad nuppudena (TabControl asemel)

Kategooriad on poes nuppudena (`FlowLayoutPanel`), mitte `TabControl`-i vahelehtedel:

- `TabControl`-i välimust (värvid, ümarad nurgad) WinFormsis peaaegu muuta ei saa;
- vahelehtedega tuli iga lehe tootekaardid uuesti teha ja otsingu ajal kadus valitud vaheleht;
- nupud lähevad ise uuele reale, kui kategooriaid on palju või aken on kitsas;
- täisekraanil mahub tooteid rohkem, nagu tavalises internetipoes.

Kategooria nupule vajutades näidatakse ainult selle kategooria tooteid, nupul on toodete arv.

## Installer (ToodedInstaller)

1. Paigalda Visual Studiosse laiendus **Microsoft Visual Studio Installer Projects 2022**.
2. Vali ülevalt **Release**, siis Solution Exploreris parem klõps **ToodedInstaller** → **Build**.
3. Valmis fail: `Toodete pood/ToodedInstaller/Release/ToodedInstaller.msi`.
4. Installitakse kausta `%LocalAppData%\ErikKalikas\Tooded App`, otsetee tuleb töölauale ja Start menüüsse.

Arvutis, kuhu programm installitakse, peab olema **.NET 10 Desktop Runtime** ja **SQL Server Express LocalDB**.
`client_secret.json` installerisse ei lähe, arve saatmiseks tuleb see panna programmi kausta.

## Commitide ajalugu

Projekt oli alguses kaustas `Ülesanne Tooted`, 30.10 nimetati see ümber `Toodete pood`.
Kogu loend: `git log -- "Ülesanne Tooted" "Toodete pood"`.

| Kuupäev | Commit | Sõnum |
|---|---|---|
| 09.10.2026 | 4937e25 | upd 1.0 |
| 09.10.2026 | cd3194c | g |
| 16.10.2026 | d3c0ebe | OSA 3: Form3 Pood vaade TabControliga, kategooriad TabPage-del koos piltidega |
| 16.10.2026 | 7ade4c2 | 2 |
| 16.10.2026 | d2a8b74 | OSA 4: ArveForm (ostukorv, PDF, e-mail) + Form2 nupp Lisa arvele; OSA 5: FormMain peamenüü |
| 16.10.2026 | a13107c | caches |
| 16.10.2026 | d0315df | OSA 6.3 ostukorv koguste ja summaga, OSA 6.4 rollid + LoginForm, OSA 7 parooli krüpteerimine (BCrypt) |
| 16.10.2026 | b10c2f6 | 2 |
| 16.10.2026 | a718afa | Helesinine taust kõigil vormidel, 25 näidistoodet koos piltidega |
| 16.10.2026 | d587fdb | 2 |
| 16.10.2026 | 363b69c | Arve: korvi saab lisada mitu toodet (ComboBox), sama toote kogus liidetakse, rea eemaldamine |
| 16.10.2026 | a0206bb | 2 |
| 16.10.2026 | cb46959 | ы |
| 30.10.2026 | 94ef71e | Kategooriate haldus adminile, e-maili saatja küsitakse töö ajal, programm sulgub koos peamenüüga |
| 30.10.2026 | 95737ef | OSA 8: ToodedInstaller Setup projekt (Images, Arved, otseteed töölauale ja Start menüüsse) |
| 30.10.2026 | 0505049 | Ühiktestid: Tooded_EFCore.Tests (xUnit + Moq + SQLite), loogika vormidest teenusklassidesse, Hind decimal |
| 30.10.2026 | 5b2b32f | bin, obj ja .vs gitist välja (.gitignore) |
| 30.10.2026 | 59eac6a | Tagasi: ühiktestide muudatused (vale ülesanne) |
| 30.10.2026 | d78ed1b | rename folder |
| 30.10.2026 | 2edafa4 | Merge branch 'main' of https://github.com/ErikKalikas/programmerimine-2-kurs |
| 30.10.2026 | d424b95 | rename folder 2 |
| 30.10.2026 | ecd5512 | Vana kausta Ülesanne Tooted jääk eemaldatud (projekt on nüüd Toodete pood) |
| 30.10.2026 | 093512b | E-mail Google'i sisselogimisega (OAuth2, Gmail API), parooli pole vaja |
| 30.10.2026 | b0ddbb7 | GmailSaatja: parandatud rida 58 |
| 30.10.2026 | dcc1026 | ArveForm: SelectedToode [DesignerSerializationVisibility(Hidden)] (WFO1000) |
| 30.10.2026 | 8b67a89 | Arve saatmisel tehakse PDF praeguse ostukorvi järgi; summad kahe komakohaga |
| 30.10.2026 | fc01715 | Ülesande põhiosa on tehtud, edasi on minu ülesanded |
| 30.10.2026 | e3ebc72 | Kaks sisselogimise režiimi: admin (kõik) ja ostja (ainult pood ja ostukorv), ühine ostukorv, ost vähendab laoseisu |
| 30.10.2026 | 9de8469 | Hinnad ja summad ümardatud sentideni (0.00) |
| 30.10.2026 | 5ca22ad | Uus sisselogimise aken, paremad pildid, joogid |
| 30.10.2026 | 8d17308 | Ilusam PDF-arve |
| 30.10.2026 | 859db3d | Ostja konto, tellimused, lemmikud, otsing ja sooduskoodid |
| 30.10.2026 | 7b93272 | Andmebaas admini funktsioonide jaoks |
| 30.10.2026 | 3c0a258 | Tootehaldus: otsing, filter ja otsakorral tooted |
| 30.10.2026 | 52fc16f | Tootehaldus: laoseisu täiendamine |
| 30.10.2026 | b126327 | Tootehaldus: kirjeldus ja soodushind tähtajaga |
| 30.10.2026 | 0f4c970 | Kõik tellimused adminile |
| 30.10.2026 | a54548a | Müügiaruanne: tulu, käibemaks, top-10 ja kategooriad |
| 30.10.2026 | 9b375d5 | Müügigraafik |
| 30.10.2026 | 32cc05f | Kasutajate haldus |
| 30.10.2026 | c93c0a3 | Admin saab oma parooli muuta |
| 30.10.2026 | 1ea4d71 | Tegevuste logi |
| 30.10.2026 | 76687af | Poe seaded: rekvisiidid, logo, käibemaks ja kirja mall |
| 16.11.2026 | b8b9800 | Uus kujundus (must/punane/hall) ja keele valik (ET/RU/EN) |
| 23.11.2026 | 3e5abdb | Andmebaasi loomine ja algandmed Program.cs-i |
| 23.11.2026 | 554e72f | Pildid ja arved AppData kausta |
| 23.11.2026 | 9be0645 | Hind float asemel decimal |
| 23.11.2026 | 0231240 | Kategooriad HasData kaudu |
| 23.11.2026 | 508e38e | Tootele uus väli Tootja |
| 23.11.2026 | 05e0357 | Installer lahendusse |
| 23.11.2026 | a8b886d | README: käivitamine, installer, kategooriad ja commitid |
