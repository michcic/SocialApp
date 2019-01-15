using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp2.Migrations
{
    public partial class friends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_AspNetUsers_UserId1",
                table: "Friend");

            migrationBuilder.DropIndex(
                name: "IX_Friend_UserId1",
                table: "Friend");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Friend",
                newName: "UserSenderId");

            migrationBuilder.AlterColumn<string>(
                name: "UserSenderId",
                table: "Friend",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserReceiverId",
                table: "Friend",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserReceiverId",
                table: "Friend");

            migrationBuilder.RenameColumn(
                name: "UserSenderId",
                table: "Friend",
                newName: "UserId1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "Friend",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friend_UserId1",
                table: "Friend",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_AspNetUsers_UserId1",
                table: "Friend",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
