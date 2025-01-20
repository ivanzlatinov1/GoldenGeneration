using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGeneration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedManagerClubManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManagersClubs",
                columns: table => new
                {
                    ManagerId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClubId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagersClubs", x => new { x.ManagerId, x.ClubId });
                    table.ForeignKey(
                        name: "FK_ManagersClubs_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagersClubs_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManagersClubs_ClubId",
                table: "ManagersClubs",
                column: "ClubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagersClubs");
        }
    }
}
