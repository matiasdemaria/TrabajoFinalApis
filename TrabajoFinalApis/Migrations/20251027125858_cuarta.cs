using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrabajoFinalApis.Migrations
{
    /// <inheritdoc />
    public partial class cuarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { 2, "Gaseosas y cervezas", "Bebidas", 1 },
                    { 3, "Helados y tortas", "Postres", 1 },
                    { 4, "Tacos clásicos", "Tacos", 2 },
                    { 5, "Burritos grandes", "Burritos", 2 },
                    { 6, "Gaseosas y aguas", "Bebidas", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "IsFavorite", "Name", "Price" },
                values: new object[] { "Pizza de mozzarella y aceitunas", true, "Pizza Mozzarella", 1200m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountPercentage", "IsFavorite", "IsHappyHour", "Name", "Price", "UserId" },
                values: new object[,]
                {
                    { 2, 1, "Mozzarella, tomate y ajo", 0m, false, false, "Pizza Napolitana", 1400m, 1 },
                    { 3, 2, "Gaseosa Coca-Cola", 25m, false, true, "Coca-Cola 1.5L", 500m, 1 },
                    { 4, 3, "Postre italiano", 0m, true, false, "Tiramisú", 700m, 1 },
                    { 5, 4, "Taco de carne molida y queso", 0m, true, false, "Taco de Carne", 600m, 2 },
                    { 6, 4, "Taco de pollo desmechado", 0m, false, false, "Taco de Pollo", 550m, 2 },
                    { 7, 5, "Burrito de frijoles, carne y arroz", 50m, true, true, "Burrito Clásico", 900m, 2 },
                    { 8, 6, "Botella de agua", 0m, false, false, "Agua sin gas 500ml", 300m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "IsFavorite", "Name", "Price" },
                values: new object[] { "Pizza de mozzarela", false, "Pizza", 12m });
        }
    }
}
