using System.Net;
using System.Net.Mail;

namespace Automaatne_andmebaasi_loomine;

public class GmailSaatja : IEmailSaatja
{
    private const string Saatja = "sinu.konto@gmail.com";
    private const string RakenduseParool = "xxxx xxxx xxxx xxxx";

    public void Saada(string saaja, string teema, string sisu, string manusFail)
    {
        using var kiri = new MailMessage(Saatja, saaja, teema, sisu);
        kiri.Attachments.Add(new Attachment(manusFail));

        using var smtp = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(Saatja, RakenduseParool),
            EnableSsl = true
        };
        smtp.Send(kiri);
    }
}
