using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication10.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "weight",
                table: "Products",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 1,
                column: "weight",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 2,
                column: "weight",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 3,
                column: "weight",
                value: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "weight",
                table: "Products");
        }
    }
}
