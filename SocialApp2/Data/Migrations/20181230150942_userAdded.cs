using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp2.Data.Migrations
{
    public partial class userAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "Post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Post",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserIdId",
                table: "Post",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_UserIdId",
                table: "Post",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_UserIdId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_UserIdId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
