using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace event_web_dev_project.Migrations
{
    /// <inheritdoc />
    public partial class AddMorePosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivityPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "We need 3 more players for a friendly basketball match this Sunday at Central Park. All skill levels welcome! We play 7v7 format.");

            migrationBuilder.UpdateData(
                table: "ActivityPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "We need 3 more players for a friendly valleyball match this Sunday at Central Park. All skill levels welcome! We play 7v7 format.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivityPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "We need 3 more players for a friendly football match this Sunday at Central Park. All skill levels welcome! We play 7v7 format.");

            migrationBuilder.UpdateData(
                table: "ActivityPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "We need 3 more players for a friendly football match this Sunday at Central Park. All skill levels welcome! We play 7v7 format.");
        }
    }
}
