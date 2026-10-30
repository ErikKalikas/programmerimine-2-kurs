using Automaatne_andmebaasi_loomine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automaatne_andmebaasi_loomine
{
    public class ToodedContext : DbContext
    {
        public DbSet<Toode> Toodetabel { get; set; }
        public DbSet<Kategooria> Kategooriatabel { get; set; }
        public DbSet<Kasutaja> Kasutajad { get; set; }
        public DbSet<Tellimus> Tellimused { get; set; }
        public DbSet<TellimuseRida> TellimuseRead { get; set; }
        public DbSet<Lemmik> Lemmikud { get; set; }
        public DbSet<LogiKirje> Logid { get; set; }
        public DbSet<PoeSeaded> Seaded { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=Tooded_DB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategooria>().ToTable("Kategooriatabel");
            modelBuilder.Entity<Toode>().ToTable("Toodetabel");
        }
    }
}
