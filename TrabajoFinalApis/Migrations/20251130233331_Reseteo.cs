using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrabajoFinalApis.Migrations
{
    /// <inheritdoc />
    public partial class Reseteo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

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
                keyValue: 1);

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

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsActive", "LastName", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, "matiasdemaria9@gmail", "Matias", true, "Demaria", "lol", "matiasldemaria" },
                    { 2, "gonzalovicente@gmail.com", "Gonzalo", true, "Vicente", "wow", "gonzalovicente" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Phone", "RestaurantName", "UserId" },
                values: new object[,]
                {
                    { 1, "avenida 212", "lol", true, "3464552", "PizzaLol", 1 },
                    { 2, "Paraguay 1950", "lol", true, "34652255", "TacoBell", 2 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsActive", "Name", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Todo tipo de pizzas", true, "Pizzas", 1 },
                    { 2, "Gaseosas y cervezas", true, "Bebidas", 1 },
                    { 3, "Helados y tortas", true, "Postres", 1 },
                    { 4, "Tacos clásicos", true, "Tacos", 2 },
                    { 5, "Burritos grandes", true, "Burritos", 2 },
                    { 6, "Gaseosas y aguas", true, "Bebidas", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountPercentage", "HappyHourEnd", "HappyHourStart", "IsAvailable", "IsFavorite", "IsHappyHour", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Pizza de mozzarella y aceitunas", 0m, null, null, true, true, false, "Pizza Mozzarella", 1200m },
                    { 2, 1, "Mozzarella, tomate y ajo", 0m, null, null, true, false, false, "Pizza Napolitana", 1400m },
                    { 3, 2, "Gaseosa Coca-Cola", 25m, null, null, true, false, true, "Coca-Cola 1.5L", 500m },
                    { 4, 3, "Postre italiano", 0m, null, null, true, true, false, "Tiramisú", 700m },
                    { 5, 4, "Taco de carne molida y queso", 0m, null, null, true, true, false, "Taco de Carne", 600m },
                    { 6, 4, "Taco de pollo desmechado", 0m, null, null, true, false, false, "Taco de Pollo", 550m },
                    { 7, 5, "Burrito de frijoles, carne y arroz", 50m, null, null, true, true, true, "Burrito Clásico", 900m },
                    { 8, 6, "Botella de agua", 0m, null, null, true, false, false, "Agua sin gas 500ml", 300m }
                });
        }
    }
}
