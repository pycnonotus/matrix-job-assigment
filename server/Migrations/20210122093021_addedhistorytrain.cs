using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class addedhistorytrain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_UserHeros_HeroId",
                        column: x => x.HeroId,
                        principalTable: "UserHeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Training_HeroId",
                table: "Training",
                column: "HeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Training");
        }
    }
}
