using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoFinalApis.Migrations
{
    /// <inheritdoc />
    public partial class nuev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "products",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantName",
                table: "users",
                type: "TEXT",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHappyHour",
                table: "products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "products",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "categories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "categories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Adress", "Email", "IsActive", "Password", "Phone", "RestaurantName", "Username" },
                values: new object[] { "paraguay  1950", "matiasdenamaria9@gmail.com", true, "Lol", "343232", "WOWOWOW", "OSTIA" });

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_UserId",
                table: "products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_UserId",
                table: "categories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_users_UserId",
                table: "categories",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_users_UserId",
                table: "products",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_users_UserId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_users_UserId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_CategoryId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_UserId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_categories_UserId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RestaurantName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "products");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "products");

            migrationBuilder.DropColumn(
                name: "IsHappyHour",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "categories");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "matias");
        }
    }
}
