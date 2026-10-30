namespace Automaatne_andmebaasi_loomine;

public interface IEmailSaatja
{
    void Saada(string saaja, string teema, string sisu, string manusFail);
}
