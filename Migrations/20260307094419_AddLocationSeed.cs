using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace event_web_dev_project.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivityPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Looking for basketball Teammates - Sunday Match");

            migrationBuilder.UpdateData(
                table: "ActivityPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Looking for valleyball Teammates - Sunday Match");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivityPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Looking for Football Teammates - Sunday Match");

            migrationBuilder.UpdateData(
                table: "ActivityPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Looking for Football Teammates - Sunday Match");
        }
    }
}
