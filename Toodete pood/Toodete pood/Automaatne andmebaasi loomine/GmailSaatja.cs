using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;

namespace Automaatne_andmebaasi_loomine
{
    // Saadab kirja Gmaili kaudu Google'i sisselogimisega (OAuth2), parooli pole vaja.
    // Esimesel korral avaneb brauser, kus logid Google'i kontoga sisse ja annad loa.
    // Luba (token) salvestatakse kausta %AppData%\ToodedApp.Gmail ja järgmisel korral brauserit enam ei avata.
    public static class GmailSaatja
    {
        // Google Cloud Console'ist alla laaditud fail (Desktop app OAuth client). GitHubi seda ei panda!
        public static string VotmeFail => Path.Combine(AppContext.BaseDirectory, "client_secret.json");

        private const string TokeniKaust = "ToodedApp.Gmail";

        public static async Task SaadaAsync(string saaja, string teema, string sisu, string manusFail)
        {
            if (!File.Exists(VotmeFail))
                throw new FileNotFoundException(
                    "Faili client_secret.json ei leitud. Lae see alla Google Cloud Console'ist ja pane projekti kausta.");

            UserCredential luba;
            using (var fail = File.OpenRead(VotmeFail))
            using (var aeg = new CancellationTokenSource(TimeSpan.FromMinutes(3)))   // kui brauseris loa andmine jääb pooleli
            {
                luba = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(fail).Secrets,
                    new[] { GmailService.Scope.GmailSend },   // ainult kirjade saatmise õigus
                    "kasutaja",
                    aeg.Token,
                    new FileDataStore(TokeniKaust));
            }

            using var gmail = new GmailService(new BaseClientService.Initializer
            {
                HttpClientInitializer = luba,
                ApplicationName = "Tooded App"
            });

            // Kiri koos PDF-manusega. Saatja (From) paneb Gmail ise sisselogitud konto järgi.
            var kiri = new MimeMessage();
            kiri.To.Add(MailboxAddress.Parse(saaja));
            kiri.Subject = teema;
            var keha = new BodyBuilder { TextBody = sisu };
            keha.Attachments.Add(manusFail);
            kiri.Body = keha.ToMessageBody();

            using var puhver = new MemoryStream();
            await kiri.WriteToAsync(puhver);

            // Gmail API tahab kirja base64url kujul
            string raw = Convert.ToBase64String(puhver.ToArray())
                .Replace('+', '-').Replace('/', '_').TrimEnd('=');

            await gmail.Users.Messages.Send(new Google.Apis.Gmail.v1.Data.Message { Raw = raw }   // täisnimi, sest WinFormsis on ka oma Message, "me").ExecuteAsync();
        }

        // Unustab salvestatud loa, järgmisel saatmisel küsitakse Google'i kontot uuesti
        public static Task LogiValjaAsync() => new FileDataStore(TokeniKaust).ClearAsync();
    }
}
