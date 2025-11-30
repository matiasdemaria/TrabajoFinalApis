using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrabajoFinalApis.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RestaurantName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    RestaurantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "TEXT", nullable: true),
                    IsHappyHour = table.Column<bool>(type: "INTEGER", nullable: false),
                    HappyHourStart = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    HappyHourEnd = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    IsFavorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RestaurantId",
                table: "Categories",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
