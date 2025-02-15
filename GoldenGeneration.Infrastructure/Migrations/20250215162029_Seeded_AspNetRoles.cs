using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGeneration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeded_AspNetRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fad1b19d-5333-4633-bd84-d67c64649f65", "42174679-32f1-48b0-9524-0f00791ec760", "admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fad1b19d-5333-4633-bd84-d67c64649f65");
        }
    }
}
