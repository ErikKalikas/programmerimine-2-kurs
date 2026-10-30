using Microsoft.EntityFrameworkCore;

namespace Automaatne_andmebaasi_loomine
{
    public class ToodedContext : DbContext
    {
        public DbSet<Toode> Toodetabel { get; set; }
        public DbSet<Kategooria> Kategooriatabel { get; set; }
        public DbSet<Kasutaja> Kasutajad { get; set; }

        public ToodedContext() { }

        // Testid annavad siia oma andmebaasi seadistuse
        public ToodedContext(DbContextOptions<ToodedContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;   // test on andmebaasi juba määranud

            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=Tooded_DB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategooria>().ToTable("Kategooriatabel");
            modelBuilder.Entity<Toode>().ToTable("Toodetabel");

            // Algandmed: kolm kategooriat on igas uues andmebaasis olemas
            modelBuilder.Entity<Kategooria>().HasData(
                new Kategooria { Id = 1, Kategooria_nimetus = "Joogid", Kirjeldus = "Erinevad joogid" },
                new Kategooria { Id = 2, Kategooria_nimetus = "Toit", Kirjeldus = "Toiduained" },
                new Kategooria { Id = 3, Kategooria_nimetus = "Muu", Kirjeldus = "Muud tooted" });
        }
    }
}
