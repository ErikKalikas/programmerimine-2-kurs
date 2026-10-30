using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automaatne_andmebaasi_loomine.Migrations
{
    /// <inheritdoc />
    public partial class AdminiFunktsioonid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SoodusKuni",
                table: "Toodetabel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Blokeeritud",
                table: "Kasutajad",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Logid",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kasutaja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tegevus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seaded",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoeNimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hyydlause = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aadress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registrikood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KmkrNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KmProtsent = table.Column<float>(type: "real", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KirjaTeema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KirjaSisu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seaded", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Logid");
            migrationBuilder.DropTable(name: "Seaded");
            migrationBuilder.DropColumn(name: "SoodusKuni", table: "Toodetabel");
            migrationBuilder.DropColumn(name: "Blokeeritud", table: "Kasutajad");
        }
    }
}
