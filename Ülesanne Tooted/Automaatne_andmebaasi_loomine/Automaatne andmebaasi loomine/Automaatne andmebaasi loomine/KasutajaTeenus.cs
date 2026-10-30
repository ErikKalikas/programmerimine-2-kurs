namespace Automaatne_andmebaasi_loomine;

public class KasutajaTeenus
{
    private readonly ToodedContext _db;

    public KasutajaTeenus(ToodedContext db) => _db = db;

    // Tagastab kasutaja või null, kui e-post või parool on vale
    public Kasutaja? LogiSisse(string email, string parool)
    {
        string puhas = email.Trim().ToLower();
        var kasutaja = _db.Kasutajad.FirstOrDefault(k => k.Email == puhas);

        if (kasutaja == null || !PasswordHelper.Verify(parool, kasutaja.ParoolHash))
            return null;

        return kasutaja;
    }
}
