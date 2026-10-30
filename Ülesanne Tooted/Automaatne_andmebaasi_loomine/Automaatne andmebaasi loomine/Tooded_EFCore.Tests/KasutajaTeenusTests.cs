namespace Tooded_EFCore.Tests;

public class KasutajaTeenusTests : AndmebaasiTest
{
    private readonly KasutajaTeenus _teenus;

    public KasutajaTeenusTests()
    {
        Db.Kasutajad.Add(new Kasutaja
        {
            Nimi = "Test",
            Email = "test@pood.ee",
            ParoolHash = PasswordHelper.Hash("salajane"),
            Roll = "admin"
        });
        Db.SaveChanges();

        _teenus = new KasutajaTeenus(Db);
    }

    [Fact]
    public void LogiSisse_OigedAndmed_TagastabKasutaja()
    {
        var kasutaja = _teenus.LogiSisse("test@pood.ee", "salajane");

        Assert.NotNull(kasutaja);
        Assert.Equal("admin", kasutaja.Roll);
    }

    [Fact]
    public void LogiSisse_ValeParool_TagastabNull()
    {
        Assert.Null(_teenus.LogiSisse("test@pood.ee", "vale"));
    }

    [Fact]
    public void LogiSisse_TundmatuEmail_TagastabNull()
    {
        Assert.Null(_teenus.LogiSisse("keegi@pood.ee", "salajane"));
    }

    [Fact]
    public void LogiSisse_SuuredTahedJaTuhikud_TootabKa()
    {
        var kasutaja = _teenus.LogiSisse("  TEST@Pood.ee ", "salajane");

        Assert.NotNull(kasutaja);
    }
}
