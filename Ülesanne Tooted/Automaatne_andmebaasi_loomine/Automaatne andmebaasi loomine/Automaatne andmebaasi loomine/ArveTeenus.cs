using System.Net.Mail;

namespace Automaatne_andmebaasi_loomine;

public class ArveTeenus
{
    private readonly IEmailSaatja _saatja;

    // Teenus ei tea, kas saatja on Gmail või mock
    public ArveTeenus(IEmailSaatja saatja) => _saatja = saatja;

    // Tagastab veateate või null, kui saatmine õnnestus
    public string? SaadaArve(string saaja, string pdfFail)
    {
        string aadress = saaja.Trim();
        if (!MailAddress.TryCreate(aadress, out _)) return "Vale e-posti aadress.";
        if (!File.Exists(pdfFail)) return "PDF-faili ei leitud.";

        _saatja.Saada(aadress, "Arve", "Arve on manuses.", pdfFail);
        Ostukorv.Tyhjenda();   // korv tühjendatakse ainult eduka saatmise järel
        return null;
    }
}
