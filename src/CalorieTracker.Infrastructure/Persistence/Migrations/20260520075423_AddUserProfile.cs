using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeightKg = table.Column<decimal>(type: "TEXT", precision: 5, scale: 1, nullable: false),
                    HeightCm = table.Column<int>(type: "INTEGER", nullable: false),
                    AgeYears = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    ActivityLevel = table.Column<string>(type: "TEXT", nullable: false),
                    GoalType = table.Column<string>(type: "TEXT", nullable: false),
                    MacroProfile = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
