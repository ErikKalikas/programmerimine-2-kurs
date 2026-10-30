using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automaatne_andmebaasi_loomine.Migrations
{
    /// <inheritdoc />
    public partial class OstjaFunktsioonid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kirjeldus",
                table: "Toodetabel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SoodusHind",
                table: "Toodetabel",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aadress",
                table: "Kasutajad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Kasutajad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Tellimused",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KasutajaId = table.Column<int>(type: "int", nullable: true),
                    Kuupaev = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summa = table.Column<float>(type: "real", nullable: false),
                    Soodustus = table.Column<float>(type: "real", nullable: false),
                    Sooduskood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdfFail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tellimused", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TellimuseRead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TellimusId = table.Column<int>(type: "int", nullable: false),
                    ToodeId = table.Column<int>(type: "int", nullable: false),
                    Toodenimetus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hind = table.Column<float>(type: "real", nullable: false),
                    Kogus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TellimuseRead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TellimuseRead_Tellimused_TellimusId",
                        column: x => x.TellimusId,
                        principalTable: "Tellimused",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lemmikud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KasutajaId = table.Column<int>(type: "int", nullable: false),
                    ToodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lemmikud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lemmikud_Kasutajad_KasutajaId",
                        column: x => x.KasutajaId,
                        principalTable: "Kasutajad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lemmikud_Toodetabel_ToodeId",
                        column: x => x.ToodeId,
                        principalTable: "Toodetabel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TellimuseRead_TellimusId",
                table: "TellimuseRead",
                column: "TellimusId");

            migrationBuilder.CreateIndex(
                name: "IX_Lemmikud_KasutajaId",
                table: "Lemmikud",
                column: "KasutajaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lemmikud_ToodeId",
                table: "Lemmikud",
                column: "ToodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Lemmikud");
            migrationBuilder.DropTable(name: "TellimuseRead");
            migrationBuilder.DropTable(name: "Tellimused");

            migrationBuilder.DropColumn(name: "Kirjeldus", table: "Toodetabel");
            migrationBuilder.DropColumn(name: "SoodusHind", table: "Toodetabel");
            migrationBuilder.DropColumn(name: "Aadress", table: "Kasutajad");
            migrationBuilder.DropColumn(name: "Telefon", table: "Kasutajad");
        }
    }
}
