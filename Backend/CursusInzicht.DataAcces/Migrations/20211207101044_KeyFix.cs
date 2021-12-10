using Microsoft.EntityFrameworkCore.Migrations;

namespace CursusInzicht.DataAcces.Migrations
{
    public partial class KeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cursussen",
                newName: "CursusId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CursusInstanties",
                newName: "CursusInstantieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CursusId",
                table: "Cursussen",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CursusInstantieId",
                table: "CursusInstanties",
                newName: "Id");
        }
    }
}
