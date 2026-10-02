# Iseseisevtöö: Kolm rakendust (Windows Forms)

Kursuse „Programmeerimine 2“ iseseisev töö. Projektis on üks avavorm ja sealt saab avada kolm väikest rakendust:

1. **Pildivaataja** – vali pilt arvutist, pööra seda ja muuda tausta värvi.
2. **Matemaatiline äraarvamismäng** – neli tehet (+, –, ×, ÷), 30 sekundit aega, lõpus näed, mitu vastust oli õige.
3. **Sarnaste piltide leidmise mäng** – 4 × 4 väli, 8 pildipaari, leia kõik paarid.

## Eesmärk

Teha Microsofti kolme Windows Formsi juhendi põhjal rakendused **ilma Toolbox'ita**. Kõik nupud, sildid, tabelid ja taimerid on loodud koodiga. Iga rakendus on eraldi klass, mis pärib klassist `Form` (OOP).

## Kasutatud tehnoloogiad

- C#
- Windows Forms
- .NET Framework 4.7.2
- Visual Studio 2022
- Git ja GitHub

## Failid

| Fail | Mis seal on |
|---|---|
| `Program.cs` | Programmi algus, avab avavormi |
| `Avavorm.cs` | Avavorm kolme nupuga |
| `PictureViewerForm.cs` | Pildivaataja |
| `MathQuizForm.cs` | Matemaatikamäng |
| `MatchingGameForm.cs` | Paaride mäng |
| `Pildid/` | Taustapilt, näidispilt ja mängupildid `mang1.png` … `mang8.png` |

## Kuidas käivitada

1. Lae repositoorium alla (`git clone https://github.com/ErikKalikas/programmerimine-2-kurs.git` või „Download ZIP“).
2. Ava Visual Studios `Iseseisevtöö Kolm rakendust.slnx`.
3. Vajuta **F5**.

NB! Pildid loetakse suhtelise teega `..\..\Pildid\`, nii et käivita programm Visual Studiost. Kui kopeerid `.exe` faili mujale, pilte ei leita.

## Kuidas kasutada

**Avavorm.** Vajuta „picture viewer“, „math quiz“ või „matching game“. Avavorm kaob ära ja tuleb tagasi, kui rakenduse kinni paned.

**Pildivaataja.** „Vali pilt“ avab failiakna. „Pööra“ keerab pilti 90°. „Taustavärv“ laseb valida pildi ümbruse värvi.

**Matemaatikamäng.** Vajuta „Start the quiz“, kirjuta vastused kastidesse ja vajuta „Lõpeta“ (või oota, kuni aeg otsa saab). Tuleb aken, kus on õigete vastuste arv.

**Paaride mäng.** Klõpsa kahel ruudul. Kui pildid on samad, jäävad need lahti, kui ei ole, lähevad kinni. Kui kõik paarid on leitud, mäng lõpeb.

## Mis on juhenditega võrreldes juba lisatud

- Pildivaataja: pildi pööramine ja taustavärvi valik (`ColorDialog`).
- Matemaatikamäng: neli tehet, punktid 0–4 ja nupp „Lõpeta“.
- Paaride mäng: päris pildid sümbolite asemel.

## Arendusideed

### Pildivaataja
1. Slaidiseanss – vali kaust ja pildid vahetuvad ise (`Timer`), lisaks nupud „Eelmine“ / „Järgmine“.
2. Salvestamine teise formaati (`SaveFileDialog`, PNG / JPEG / BMP).
3. Suumimine hiire rattaga.
4. Filtrid: must-valge, heledus, kontrast.

### Matemaatikamäng
1. Raskusastme valik (`ComboBox`): lihtne / keskmine / raske.
2. Kohene tagasiside: õige vastus roheliseks, vale punaseks.
3. Parimate tulemuste tabel, mis salvestatakse faili.
4. „Start“ nupp keelatud mängu ajal.

### Paaride mäng
1. Tasemed 4 × 4 ja 6 × 6.
2. Taimer ja käikude loendur, nendest arvutatakse punktid.
3. Nupp „Uus mäng“.
4. Eri pilditeemad ja helid.

## Edasine areng

Kõige enne tahaksin panna pildid projekti ressurssidesse, et programm töötaks ükskõik kust käivitatuna, ja teha kõik tekstid eesti keelde. Hiljem tõstaksin mänguloogika vormidest välja eraldi klassidesse, et saaks kirjutada ühikteste, ja lisaksin ülal toodud arendusi alates raskusastmetest ja tasemetest.
