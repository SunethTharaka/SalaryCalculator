using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalaryCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IncomeTaxRates",
                columns: new[] { "Id", "Description", "IsActive", "MaxValue", "MinValue", "Name" },
                values: new object[,]
                {
                    { 1, "Up to $14,000", true, 14000m, 0m, "L1" },
                    { 2, "Over $14,000 and up to $48,000", true, 48000m, 14000m, "L2" },
                    { 3, "Over $48,000 and up to $70,000 ", true, 70000m, 48000m, "L3" },
                    { 4, "Over $70,000 and up to $180,000 ", true, 180000m, 70000m, "L4" },
                    { 5, "Income over $180,000", true, 180000m, 180000m, "L5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IncomeTaxRates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IncomeTaxRates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IncomeTaxRates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IncomeTaxRates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IncomeTaxRates",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
