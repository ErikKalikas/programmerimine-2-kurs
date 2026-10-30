namespace Tooded_EFCore.Tests;

public class ToodeValidaatorTests
{
    // ---------- Hind ----------
    [Theory]
    [InlineData("2,50", 2.50)]
    [InlineData("2.50", 2.50)]
    [InlineData("0", 0)]
    [InlineData(" 10 ", 10)]
    public void LoeHind_KorrektneArv_Onnestub(string tekst, double oodatud)
    {
        bool onnestus = ToodeValidaator.LoeHind(tekst, out decimal hind);

        Assert.True(onnestus);
        Assert.Equal((decimal)oodatud, hind);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("")]
    [InlineData("-1")]
    [InlineData(null)]
    public void LoeHind_ValeSisend_Ebaonnestub(string? tekst)
    {
        bool onnestus = ToodeValidaator.LoeHind(tekst, out _);

        Assert.False(onnestus);
    }

    // ---------- Kogus ----------
    [Theory]
    [InlineData("0", 0)]
    [InlineData("5", 5)]
    [InlineData("1000", 1000)]
    public void LoeKogus_Taisarv_Onnestub(string tekst, int oodatud)
    {
        Assert.True(ToodeValidaator.LoeKogus(tekst, out int kogus));
        Assert.Equal(oodatud, kogus);
    }

    [Theory]
    [InlineData("-3")]
    [InlineData("2,5")]
    [InlineData("kolm")]
    [InlineData("")]
    public void LoeKogus_ValeSisend_Ebaonnestub(string tekst)
    {
        Assert.False(ToodeValidaator.LoeKogus(tekst, out _));
    }

    // ---------- Nimi ----------
    [Theory]
    [InlineData("Piim", true)]
    [InlineData("", false)]
    [InlineData("   ", false)]
    [InlineData(null, false)]
    public void OnKorrektneNimi_EriSisendid_AnnabOigeVastuse(string? nimi, bool oodatud)
    {
        Assert.Equal(oodatud, ToodeValidaator.OnKorrektneNimi(nimi));
    }
}
