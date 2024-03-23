using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    /// <inheritdoc />
    public partial class CreateAnnouncementTableV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_announcements_AspNetUsers_Id",
                table: "announcements");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "announcements",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_announcements_Id",
                table: "announcements",
                newName: "IX_announcements_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_announcements_AspNetUsers_UserId",
                table: "announcements",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_announcements_AspNetUsers_UserId",
                table: "announcements");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "announcements",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_announcements_UserId",
                table: "announcements",
                newName: "IX_announcements_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_announcements_AspNetUsers_Id",
                table: "announcements",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
