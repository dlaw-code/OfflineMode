using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfflineMode.DATA.Migrations
{
    /// <inheritdoc />
    public partial class CourseMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Courses");
        }
    }
}
