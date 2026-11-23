using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Automaatne_andmebaasi_loomine.Migrations
{
    /// <inheritdoc />
    public partial class KategooriadHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seda osa muutsin käsitsi: vanemas andmebaasis lisas kategooriad varem kood (LoginForm),
            // siis on need juba olemas ja tavaline InsertData annaks vea "duplicate key".
            // Sellepärast lisame ainult need kategooriad, mida veel pole.
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT Kategooriatabel ON;

IF NOT EXISTS (SELECT 1 FROM Kategooriatabel WHERE Id = 1 OR Kategooria_nimetus = N'Joogid')
    INSERT INTO Kategooriatabel (Id, Kategooria_nimetus, Kirjeldus) VALUES (1, N'Joogid', N'Erinevad joogid');

IF NOT EXISTS (SELECT 1 FROM Kategooriatabel WHERE Id = 2 OR Kategooria_nimetus = N'Toit')
    INSERT INTO Kategooriatabel (Id, Kategooria_nimetus, Kirjeldus) VALUES (2, N'Toit', N'Toiduained');

IF NOT EXISTS (SELECT 1 FROM Kategooriatabel WHERE Id = 3 OR Kategooria_nimetus = N'Muu')
    INSERT INTO Kategooriatabel (Id, Kategooria_nimetus, Kirjeldus) VALUES (3, N'Muu', N'Muud tooted');

SET IDENTITY_INSERT Kategooriatabel OFF;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kategooriatabel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategooriatabel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kategooriatabel",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
