using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automaatne_andmebaasi_loomine.Migrations
{
    /// <inheritdoc />
    public partial class LisaTootja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tootja",
                table: "Toodetabel",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tootja",
                table: "Toodetabel");
        }
    }
}
