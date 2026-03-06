using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace event_web_dev_project.Migrations
{
    /// <inheritdoc />
    public partial class SeedActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActivityPosts",
                columns: new[] { "Id", "ApplicationMode", "Category", "CurrentMembers", "DeletedAt", "Description", "ExpiresAt", "IsDeleted", "Location", "MaxMembers", "OwnerId", "PostedAt", "PostedBy", "Status", "Title" },
                values: new object[] { 1, "Overflow allowed - Owner selects", "Sports", 2, null, "We need 3 more players for a friendly football match this Sunday at Central Park. All skill levels welcome! We play 7v7 format.", new DateTime(2026, 2, 15, 12, 0, 0, 0, DateTimeKind.Utc), false, "Central Park, Field 3", 3, null, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sarah Chen", "Open", "Looking for Football Teammates - Sunday Match" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActivityPosts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
