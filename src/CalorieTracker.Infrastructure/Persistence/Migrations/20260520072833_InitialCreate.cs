using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    KcalPer100g = table.Column<decimal>(type: "TEXT", precision: 8, scale: 2, nullable: false),
                    CarbsPer100g = table.Column<decimal>(type: "TEXT", precision: 8, scale: 2, nullable: false),
                    FatPer100g = table.Column<decimal>(type: "TEXT", precision: 8, scale: 2, nullable: false),
                    ProteinPer100g = table.Column<decimal>(type: "TEXT", precision: 8, scale: 2, nullable: false),
                    DefaultUnit = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    UnitLabel = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    GramsPerUnit = table.Column<decimal>(type: "TEXT", precision: 8, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumptionEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<decimal>(type: "TEXT", precision: 10, scale: 3, nullable: false),
                    MealMoment = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    ConsumedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumptionEntries_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionEntries_ProductId",
                table: "ConsumptionEntries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumptionEntries");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
