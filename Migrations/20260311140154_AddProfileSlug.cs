using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace event_web_dev_project.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileSlug",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileSlug",
                table: "AspNetUsers",
                column: "ProfileSlug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileSlug",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileSlug",
                table: "AspNetUsers");
        }
    }
}
