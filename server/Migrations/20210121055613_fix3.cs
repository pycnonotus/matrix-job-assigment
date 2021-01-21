using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class fix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hero_AspNetUsers_TrainerId",
                table: "Hero");

            migrationBuilder.AlterColumn<string>(
                name: "TrainerId",
                table: "Hero",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_AspNetUsers_TrainerId",
                table: "Hero",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hero_AspNetUsers_TrainerId",
                table: "Hero");

            migrationBuilder.AlterColumn<string>(
                name: "TrainerId",
                table: "Hero",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_AspNetUsers_TrainerId",
                table: "Hero",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
