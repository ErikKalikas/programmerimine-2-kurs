using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Tooded_EFCore.Tests;

public abstract class AndmebaasiTest : IDisposable
{
    private readonly SqliteConnection _yhendus;
    protected readonly ToodedContext Db;

    protected AndmebaasiTest()
    {
        // Mälus olev andmebaas elab seni, kuni ühendus on avatud
        _yhendus = new SqliteConnection("DataSource=:memory:");
        _yhendus.Open();

        var options = new DbContextOptionsBuilder<ToodedContext>()
            .UseSqlite(_yhendus)
            .Options;

        Db = new ToodedContext(options);   // osa 2.1 konstruktor
        Db.Database.EnsureCreated();       // loob tabelid ja algandmed mudeli järgi
    }

    public void Dispose()
    {
        Db.Dispose();
        _yhendus.Dispose();
    }
}
