using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class blop1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hero_AspNetUsers_TrainerId",
                table: "Hero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hero",
                table: "Hero");

            migrationBuilder.RenameTable(
                name: "Hero",
                newName: "UserHeros");

            migrationBuilder.RenameIndex(
                name: "IX_Hero_TrainerId",
                table: "UserHeros",
                newName: "IX_UserHeros_TrainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHeros",
                table: "UserHeros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHeros_AspNetUsers_TrainerId",
                table: "UserHeros",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHeros_AspNetUsers_TrainerId",
                table: "UserHeros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHeros",
                table: "UserHeros");

            migrationBuilder.RenameTable(
                name: "UserHeros",
                newName: "Hero");

            migrationBuilder.RenameIndex(
                name: "IX_UserHeros_TrainerId",
                table: "Hero",
                newName: "IX_Hero_TrainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hero",
                table: "Hero",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_AspNetUsers_TrainerId",
                table: "Hero",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
