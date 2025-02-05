using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGeneration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_ImageUrl_Property_To_Clubs_And_Footballers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Footballers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Footballers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Clubs");
        }
    }
}
