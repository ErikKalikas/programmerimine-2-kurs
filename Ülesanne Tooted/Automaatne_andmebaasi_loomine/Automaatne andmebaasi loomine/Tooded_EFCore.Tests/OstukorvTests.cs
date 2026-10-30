namespace Tooded_EFCore.Tests;

[Collection("Ostukorv")]   // vt selgitust allpool
public class OstukorvTests : IDisposable
{
    private readonly Toode piim = new() { Id = 1, Toodenimetus = "Piim", Hind = 1.20m };
    private readonly Toode leib = new() { Id = 2, Toodenimetus = "Leib", Hind = 2.35m };

    // Konstruktor käivitub enne IGAT testi
    public OstukorvTests() => Ostukorv.Tyhjenda();

    // Dispose käivitub pärast IGAT testi
    public void Dispose() => Ostukorv.Tyhjenda();

    [Fact]
    public void Lisa_UusToode_LisabUheRea()
    {
        // Arrange: tühi korv ja toode on konstruktoris valmis

        // Act
        Ostukorv.Lisa(piim, 2);

        // Assert
        Assert.Single(Ostukorv.Ridad);
        Assert.Equal(2, Ostukorv.Ridad[0].Kogus);
    }

    [Fact]
    public void Lisa_SamaToodeKahesti_SuurendabKogust()
    {
        Ostukorv.Lisa(piim, 2);
        Ostukorv.Lisa(piim, 3);

        Assert.Single(Ostukorv.Ridad);
        Assert.Equal(5, Ostukorv.Ridad[0].Kogus);
    }

    [Fact]
    public void Kokku_KaksToodet_LiidabRidadeSummad()
    {
        Ostukorv.Lisa(piim, 2);   // 2 × 1,20 = 2,40
        Ostukorv.Lisa(leib, 1);   // 1 × 2,35 = 2,35

        decimal kokku = Ostukorv.Kokku;

        Assert.Equal(4.75m, kokku);
    }

    [Fact]
    public void Tyhjenda_TaisKorv_EemaldabKoikRead()
    {
        Ostukorv.Lisa(piim, 1);
        Ostukorv.Lisa(leib, 1);

        Ostukorv.Tyhjenda();

        Assert.Empty(Ostukorv.Ridad);
        Assert.Equal(0m, Ostukorv.Kokku);
    }

    [Fact]
    public void Summa_Rida_KorrutabHinnaKogusega()
    {
        var rida = new OstukorviRida { Toode = leib, Kogus = 3 };

        Assert.Equal(7.05m, rida.Summa);
    }
}
