using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace event_web_dev_project.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileFieldsBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostApplications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostApplications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostApplications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PostApplications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActivityPosts",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActivityPosts",
                columns: new[] { "Id", "ApplicationMode", "Category", "CurrentMembers", "DeletedAt", "Description", "ExpiresAt", "IsDeleted", "Location", "MaxMembers", "OwnerId", "PostedAt", "PostedBy", "Status", "Title" },
                values: new object[] { 1, "Overflow allowed - Owner selects", "Sports", 2, null, "We need 3 more players for a friendly football match this Sunday at Central Park. All skill levels welcome! We play 7v7 format.", new DateTime(2026, 2, 15, 12, 0, 0, 0, DateTimeKind.Utc), false, "Central Park, Field 3", 3, null, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Alex Johnson", "Open", "Looking for Football Teammates - Sunday Match" });

            migrationBuilder.InsertData(
                table: "PostApplications",
                columns: new[] { "Id", "ApplicantId", "ApplicantName", "AppliedAt", "Message", "PostId", "Status" },
                values: new object[,]
                {
                    { 1, null, "Sarah Chen", new DateTime(2026, 2, 11, 14, 30, 0, 0, DateTimeKind.Utc), "I'd love to join! I play midfielder and have experience.", 1, "Accepted" },
                    { 2, null, "Mike Rodriguez", new DateTime(2026, 2, 11, 15, 0, 0, 0, DateTimeKind.Utc), "Count me in! I'm available on Sunday.", 1, "Accepted" },
                    { 3, null, "Emily Park", new DateTime(2026, 2, 11, 16, 0, 0, 0, DateTimeKind.Utc), "I'm interested! Can I bring a friend?", 1, "Pending" },
                    { 4, null, "Jessica Liu", new DateTime(2026, 2, 11, 17, 0, 0, 0, DateTimeKind.Utc), "Would love to join but I'm a beginner. Is that okay?", 1, "Rejected" }
                });
        }
    }
}
