
using Microsoft.EntityFrameworkCore;
using TrabajoFinalApis.Entities;

namespace TrabajoFinalApis.Data;

public class TrabajoFinalApisContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public TrabajoFinalApisContext(DbContextOptions<TrabajoFinalApisContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
        new User
        {
            Address = "avenida 212",
            IsActive = true,
            Email = "matiasdemaria9@gmail",
            Id = 1,
            PasswordHash = "lol",
            Phone = "3464552",
            RestaurantName = "PizzaLol",
            Username = "matiasldemaria"
        },
        new User
        {
            Id = 2,
            Address = "Paraguay 1950",
            IsActive = true,
            Email = "gonzalovicente@gmail.com",
            PasswordHash = "wow",
            Phone = "34652255",
            RestaurantName = "TacoBell",
            Username = "gonzalovicente"           
        }
            );


        modelBuilder.Entity<Category>().HasData(
             // Categorías para PizzaLol (UserId = 1)
             new Category { Id = 1, Name = "Pizzas", Description = "Todo tipo de pizzas", UserId = 1 },
             new Category { Id = 2, Name = "Bebidas", Description = "Gaseosas y cervezas", UserId = 1 },
             new Category { Id = 3, Name = "Postres", Description = "Helados y tortas", UserId = 1 },

             // Categorías para TacoBell (UserId = 2)
             new Category { Id = 4, Name = "Tacos", Description = "Tacos clásicos", UserId = 2 },
             new Category { Id = 5, Name = "Burritos", Description = "Burritos grandes", UserId = 2 },
             new Category { Id = 6, Name = "Bebidas", Description = "Gaseosas y aguas", UserId = 2 }
         );

        modelBuilder.Entity<Product>().HasData(
            // Productos para PizzaLol (UserId = 1)
            new Product
            {
                Id = 1,
                UserId = 1,
                CategoryId = 1,
                Name = "Pizza Mozzarella",
                Description = "Pizza de mozzarella y aceitunas",
                Price = 1200,
                IsHappyHour = false,
                IsFavorite = true,
                DiscountPercentage = 0
            },
            new Product
            {
                Id = 2,
                UserId = 1,
                CategoryId = 1,
                Name = "Pizza Napolitana",
                Description = "Mozzarella, tomate y ajo",
                Price = 1400,
                IsHappyHour = false,
                IsFavorite = false,
                DiscountPercentage = 0
            },
            new Product
            {
                Id = 3,
                UserId = 1,
                CategoryId = 2,
                Name = "Coca-Cola 1.5L",
                Description = "Gaseosa Coca-Cola",
                Price = 500,
                IsHappyHour = true,
                IsFavorite = false,
                DiscountPercentage = 25 // 25% OFF en Happy Hour
            },
            new Product
            {
                Id = 4,
                UserId = 1,
                CategoryId = 3,
                Name = "Tiramisú",
                Description = "Postre italiano",
                Price = 700,
                IsHappyHour = false,
                IsFavorite = true,
                DiscountPercentage = 0
            },

            // Productos para TacoBell (UserId = 2)
            new Product
            {
                Id = 5,
                UserId = 2,
                CategoryId = 4,
                Name = "Taco de Carne",
                Description = "Taco de carne molida y queso",
                Price = 600,
                IsHappyHour = false,
                IsFavorite = true,
                DiscountPercentage = 0
            },
            new Product
            {
                Id = 6,
                UserId = 2,
                CategoryId = 4,
                Name = "Taco de Pollo",
                Description = "Taco de pollo desmechado",
                Price = 550,
                IsHappyHour = false,
                IsFavorite = false,
                DiscountPercentage = 0
            },
            new Product
            {
                Id = 7,
                UserId = 2,
                CategoryId = 5,
                Name = "Burrito Clásico",
                Description = "Burrito de frijoles, carne y arroz",
                Price = 900,
                IsHappyHour = true,
                IsFavorite = true,
                DiscountPercentage = 50 // 50% OFF!
            },
            new Product
            {
                Id = 8,
                UserId = 2,
                CategoryId = 6,
                Name = "Agua sin gas 500ml",
                Description = "Botella de agua",
                Price = 300,
                IsHappyHour = false,
                IsFavorite = false,
                DiscountPercentage = 0
            }
        );
        base.OnModelCreating(modelBuilder);

    }
}
