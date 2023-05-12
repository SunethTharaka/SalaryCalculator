using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaryCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTaxRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "IncomeTaxRates",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "IncomeTaxRates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rate",
                value: 10.5m);

            migrationBuilder.UpdateData(
                table: "IncomeTaxRates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rate",
                value: 17.5m);

            migrationBuilder.UpdateData(
                table: "IncomeTaxRates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rate",
                value: 30m);

            migrationBuilder.UpdateData(
                table: "IncomeTaxRates",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rate",
                value: 33m);

            migrationBuilder.UpdateData(
                table: "IncomeTaxRates",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rate",
                value: 39m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "IncomeTaxRates");
        }
    }
}
