using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automaatne_andmebaasi_loomine.Migrations
{
    /// <inheritdoc />
    public partial class TestideJaoksMuudatused : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Hind",
                table: "Toodetabel",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Pilt",
                table: "Toodetabel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Kasutajad",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Kasutajad_Email",
                table: "Kasutajad",
                column: "Email",
                unique: true);

            // Algandmed: lisatakse ainult siis, kui sellise Id-ga kategooriat veel pole
            // (vanas andmebaasis lõi programm kategooriad juba ise)
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT Kategooriatabel ON;
IF NOT EXISTS (SELECT 1 FROM Kategooriatabel WHERE Id = 1)
    INSERT INTO Kategooriatabel (Id, Kategooria_nimetus, Kirjeldus) VALUES (1, N'Joogid', N'Erinevad joogid');
IF NOT EXISTS (SELECT 1 FROM Kategooriatabel WHERE Id = 2)
    INSERT INTO Kategooriatabel (Id, Kategooria_nimetus, Kirjeldus) VALUES (2, N'Toit', N'Toiduained');
IF NOT EXISTS (SELECT 1 FROM Kategooriatabel WHERE Id = 3)
    INSERT INTO Kategooriatabel (Id, Kategooria_nimetus, Kirjeldus) VALUES (3, N'Muu', N'Muud tooted');
SET IDENTITY_INSERT Kategooriatabel OFF;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kasutajad_Email",
                table: "Kasutajad");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Kasutajad",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Pilt",
                table: "Toodetabel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Hind",
                table: "Toodetabel",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
