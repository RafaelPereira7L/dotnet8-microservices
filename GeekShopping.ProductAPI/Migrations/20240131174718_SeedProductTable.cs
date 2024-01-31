using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { new Guid("39ee4931-5f7e-40b6-a4f7-c4bdde650906"), null, "Description of Product 3", null, "Product 3", 180m },
                    { new Guid("5a31803e-d3d2-4cde-9f87-163f8081efcc"), null, "Description of Product 1", null, "Product 1", 100m },
                    { new Guid("c2d7bc22-7fca-4965-86c7-e797528d813a"), null, "Description of Product 2", null, "Product 2", 150m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("39ee4931-5f7e-40b6-a4f7-c4bdde650906"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("5a31803e-d3d2-4cde-9f87-163f8081efcc"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c2d7bc22-7fca-4965-86c7-e797528d813a"));
        }
    }
}
