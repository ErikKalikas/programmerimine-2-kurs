using Microsoft.EntityFrameworkCore;

namespace Tooded_EFCore.Tests;

public class AndmebaasiTests : AndmebaasiTest
{
    [Fact]
    public void Algandmed_UusAndmebaas_OnKolmKategooriat()
    {
        int arv = Db.Kategooriatabel.Count();

        Assert.Equal(3, arv);
    }

    [Fact]
    public void Toode_IlmaPildita_Salvestub()
    {
        var vesi = new Toode { Toodenimetus = "Vesi", Kogus = 10, Hind = 0.99m, KategooriaId = 1 };

        Db.Toodetabel.Add(vesi);
        Db.SaveChanges();

        Assert.Equal(1, Db.Toodetabel.Count());
        Assert.Null(Db.Toodetabel.Single().Pilt);
    }

    [Fact]
    public void Toode_OlematuKategooria_AnnabVea()
    {
        var toode = new Toode { Toodenimetus = "Viga", Kogus = 1, Hind = 1m, KategooriaId = 99 };
        Db.Toodetabel.Add(toode);

        // Välisvõti: kategooriat 99 ei ole
        Assert.Throws<DbUpdateException>(() => Db.SaveChanges());
    }

    [Fact]
    public void Kasutaja_SamaEmailKahesti_AnnabVea()
    {
        Db.Kasutajad.Add(new Kasutaja { Nimi = "A", Email = "sama@pood.ee", ParoolHash = "x" });
        Db.Kasutajad.Add(new Kasutaja { Nimi = "B", Email = "sama@pood.ee", ParoolHash = "y" });

        // Unikaalne indeks [Index(nameof(Email), IsUnique = true)]
        Assert.Throws<DbUpdateException>(() => Db.SaveChanges());
    }

    [Fact]
    public void Kategooria_Include_LaebKaTooted()
    {
        Db.Toodetabel.Add(new Toode { Toodenimetus = "Mahl", Kogus = 5, Hind = 1.50m, KategooriaId = 1 });
        Db.SaveChanges();
        Db.ChangeTracker.Clear();   // unustab mälus olevad objektid, et lugeda päriselt andmebaasist

        var joogid = Db.Kategooriatabel.Include(k => k.Tooded).Single(k => k.Id == 1);

        Assert.Single(joogid.Tooded);
        Assert.Equal("Mahl", joogid.Tooded.First().Toodenimetus);
    }
}
