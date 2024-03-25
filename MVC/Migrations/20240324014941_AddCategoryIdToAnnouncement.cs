using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryIdToAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "announcements");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_announcements_CategoryId",
                table: "announcements",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_announcements_categories_CategoryId",
                table: "announcements",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_announcements_categories_CategoryId",
                table: "announcements");

            migrationBuilder.DropIndex(
                name: "IX_announcements_CategoryId",
                table: "announcements");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "announcements");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "announcements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
