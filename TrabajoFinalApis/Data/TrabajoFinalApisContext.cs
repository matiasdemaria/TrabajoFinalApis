
using Microsoft.EntityFrameworkCore;
using TrabajoFinalApis.Entities;

namespace TrabajoFinalApis.Data;

public class TrabajoFinalApisContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public TrabajoFinalApisContext(DbContextOptions<TrabajoFinalApisContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. SEEDING DE USUARIOS
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "matiasldemaria",
                FirstName = "Matias",
                LastName = "Demaria",
                Email = "matiasdemaria9@gmail",
                PasswordHash = "lol",
                IsActive = true
            },
            new User
            {
                Id = 2,
                Username = "gonzalovicente",
                FirstName = "Gonzalo",
                LastName = "Vicente",
                Email = "gonzalovicente@gmail.com",
                PasswordHash = "wow",
                IsActive = true
            }
        );

        // 2. SEEDING DE RESTAURANTES
        modelBuilder.Entity<Restaurant>().HasData(
            new Restaurant
            {
                Id = 1,
                Description = "lol",
                RestaurantName = "PizzaLol",
                Address = "avenida 212",
                Phone = "3464552",
                IsActive = true,
                UserId = 1
            },
            new Restaurant
            {
                Id = 2,
                Description = "lol",
                RestaurantName = "TacoBell",
                Address = "Paraguay 1950",
                Phone = "34652255",
                IsActive = true,
                UserId = 2
            }
        );

        // 3. SEEDING DE CATEGORIAS
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Pizzas", Description = "Todo tipo de pizzas", IsActive = true, RestaurantId = 1 },
            new Category { Id = 2, Name = "Bebidas", Description = "Gaseosas y cervezas", IsActive = true, RestaurantId = 1 },
            new Category { Id = 3, Name = "Postres", Description = "Helados y tortas", IsActive = true, RestaurantId = 1 },
            new Category { Id = 4, Name = "Tacos", Description = "Tacos clásicos", IsActive = true, RestaurantId = 2 },
            new Category { Id = 5, Name = "Burritos", Description = "Burritos grandes", IsActive = true, RestaurantId = 2 },
            new Category { Id = 6, Name = "Bebidas", Description = "Gaseosas y aguas", IsActive = true, RestaurantId = 2 }
        );

        // 4. SEEDING DE PRODUCTOS
        // NOTA: Agregué la 'm' al final de los números (1200m, 25m) para indicar que son decimales.
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Pizza Mozzarella",
                Description = "Pizza de mozzarella y aceitunas",
                Price = 1200m, // <--- Sufijo 'm'
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = true,
                DiscountPercentage = 0m,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Pizza Napolitana",
                Description = "Mozzarella, tomate y ajo",
                Price = 1400m,
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = false,
                DiscountPercentage = 0m,
                CategoryId = 1
            },
            new Product
            {
                Id = 3,
                Name = "Coca-Cola 1.5L",
                Description = "Gaseosa Coca-Cola",
                Price = 500m,
                IsAvailable = true,
                IsHappyHour = true,
                IsFavorite = false,
                DiscountPercentage = 25m,
                CategoryId = 2
            },
            new Product
            {
                Id = 4,
                Name = "Tiramisú",
                Description = "Postre italiano",
                Price = 700m,
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = true,
                DiscountPercentage = 0m,
                CategoryId = 3
            },
            new Product
            {
                Id = 5,
                Name = "Taco de Carne",
                Description = "Taco de carne molida y queso",
                Price = 600m,
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = true,
                DiscountPercentage = 0m,
                CategoryId = 4
            },
            new Product
            {
                Id = 6,
                Name = "Taco de Pollo",
                Description = "Taco de pollo desmechado",
                Price = 550m,
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = false,
                DiscountPercentage = 0m,
                CategoryId = 4
            },
            new Product
            {
                Id = 7,
                Name = "Burrito Clásico",
                Description = "Burrito de frijoles, carne y arroz",
                Price = 900m,
                IsAvailable = true,
                IsHappyHour = true,
                IsFavorite = true,
                DiscountPercentage = 50m,
                CategoryId = 5
            },
            new Product
            {
                Id = 8,
                Name = "Agua sin gas 500ml",
                Description = "Botella de agua",
                Price = 300m,
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = false,
                DiscountPercentage = 0m,
                CategoryId = 6
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
