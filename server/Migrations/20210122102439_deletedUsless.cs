using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class deletedUsless : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstTraining",
                table: "UserHeros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FirstTraining",
                table: "UserHeros",
                type: "datetime2",
                nullable: true);
        }
    }
}
