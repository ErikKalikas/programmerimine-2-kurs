using System.Net.Mail;
using Moq;

namespace Tooded_EFCore.Tests;

[Collection("Ostukorv")]   // kasutab sama staatilist ostukorvi kui OstukorvTests
public class ArveTeenusTests : IDisposable
{
    private readonly Mock<IEmailSaatja> _saatja = new();
    private readonly ArveTeenus _teenus;
    private readonly string _pdf = Path.GetTempFileName();   // päris ajutine fail

    public ArveTeenusTests()
    {
        _teenus = new ArveTeenus(_saatja.Object);   // .Object = mocki "päris" objekt

        Ostukorv.Tyhjenda();
        Ostukorv.Lisa(new Toode { Id = 1, Toodenimetus = "Piim", Hind = 1.20m }, 2);
    }

    public void Dispose()
    {
        File.Delete(_pdf);
        Ostukorv.Tyhjenda();
    }

    [Fact]
    public void SaadaArve_KorrektneAadress_SaadabKirjaUheKorra()
    {
        string? viga = _teenus.SaadaArve("ostja@pood.ee", _pdf);

        Assert.Null(viga);
        _saatja.Verify(s => s.Saada("ostja@pood.ee", "Arve", It.IsAny<string>(), _pdf),
                       Times.Once);
    }

    [Fact]
    public void SaadaArve_KorrektneAadress_TyhjendabKorvi()
    {
        _teenus.SaadaArve("ostja@pood.ee", _pdf);

        Assert.Empty(Ostukorv.Ridad);
    }

    [Theory]
    [InlineData("")]
    [InlineData("pole-aadress")]
    [InlineData("ostja@")]
    public void SaadaArve_ValeAadress_EiSaadaKirja(string aadress)
    {
        string? viga = _teenus.SaadaArve(aadress, _pdf);

        Assert.Equal("Vale e-posti aadress.", viga);
        _saatja.Verify(s => s.Saada(It.IsAny<string>(), It.IsAny<string>(),
                                    It.IsAny<string>(), It.IsAny<string>()),
                       Times.Never);
        Assert.Single(Ostukorv.Ridad);   // korv jäi alles
    }

    [Fact]
    public void SaadaArve_PdfPuudub_EiSaadaKirja()
    {
        string? viga = _teenus.SaadaArve("ostja@pood.ee", "C:\\pole\\olemas.pdf");

        Assert.Equal("PDF-faili ei leitud.", viga);
        _saatja.VerifyNoOtherCalls();   // mocki ei kutsutud kordagi
    }

    [Fact]
    public void SaadaArve_ServeriViga_KorvJaabAlles()
    {
        // Setup: mock viskab vea nagu maas olev e-posti server
        _saatja.Setup(s => s.Saada(It.IsAny<string>(), It.IsAny<string>(),
                                   It.IsAny<string>(), It.IsAny<string>()))
               .Throws(new SmtpException("Server ei vasta"));

        Assert.Throws<SmtpException>(() => _teenus.SaadaArve("ostja@pood.ee", _pdf));
        Assert.Single(Ostukorv.Ridad);   // ostja ei kaota korvi, kui saatmine ebaõnnestub
    }
}
