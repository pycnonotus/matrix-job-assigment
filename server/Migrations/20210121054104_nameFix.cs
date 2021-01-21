using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class nameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Hero",
                newName: "SuitColor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SuitColor",
                table: "Hero",
                newName: "Color");
        }
    }
}
