
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
        // 1. SEEDING DE USUARIOS
        // Nota: Agregué FirstName y LastName porque son requeridos en tu nueva entidad.
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
        // Aquí movemos la info del negocio que antes estaba en User.
        modelBuilder.Entity<Restaurant>().HasData(
            new Restaurant
            {
                Id = 1,
                RestaurantName = "PizzaLol",
                Address = "avenida 212",
                Phone = "3464552",
                IsActive = true,
                UserId = 1 // Pertenece a Matias
            },
            new Restaurant
            {
                Id = 2,
                RestaurantName = "TacoBell",
                Address = "Paraguay 1950",
                Phone = "34652255",
                IsActive = true,
                UserId = 2 // Pertenece a Gonzalo
            }
        );

        // 3. SEEDING DE CATEGORIAS
        // Ahora se vinculan al RestaurantId, no al UserId.
        modelBuilder.Entity<Category>().HasData(
            // Categorías para PizzaLol (RestaurantId = 1)
            new Category { Id = 1, Name = "Pizzas", Description = "Todo tipo de pizzas", IsActive = true, RestaurantId = 1 },
            new Category { Id = 2, Name = "Bebidas", Description = "Gaseosas y cervezas", IsActive = true, RestaurantId = 1 },
            new Category { Id = 3, Name = "Postres", Description = "Helados y tortas", IsActive = true, RestaurantId = 1 },

            // Categorías para TacoBell (RestaurantId = 2)
            new Category { Id = 4, Name = "Tacos", Description = "Tacos clásicos", IsActive = true, RestaurantId = 2 },
            new Category { Id = 5, Name = "Burritos", Description = "Burritos grandes", IsActive = true, RestaurantId = 2 },
            new Category { Id = 6, Name = "Bebidas", Description = "Gaseosas y aguas", IsActive = true, RestaurantId = 2 }
        );

        // 4. SEEDING DE PRODUCTOS
        // Se eliminó UserId y se agregaron valores por defecto para IsAvailable.
        modelBuilder.Entity<Product>().HasData(
            // Productos para PizzaLol -> Categoría 1, 2, 3
            new Product
            {
                Id = 1,
                Name = "Pizza Mozzarella",
                Description = "Pizza de mozzarella y aceitunas",
                Price = 1200,
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = true,
                DiscountPercentage = 0,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Pizza Napolitana",
                Description = "Mozzarella, tomate y ajo",
                Price = 1400,
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = false,
                DiscountPercentage = 0,
                CategoryId = 1
            },
            new Product
            {
                Id = 3,
                Name = "Coca-Cola 1.5L",
                Description = "Gaseosa Coca-Cola",
                Price = 500,
                IsAvailable = true,
                IsHappyHour = true,
                IsFavorite = false,
                DiscountPercentage = 25,
                CategoryId = 2
            },
            new Product
            {
                Id = 4,
                Name = "Tiramisú",
                Description = "Postre italiano",
                Price = 700,
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = true,
                DiscountPercentage = 0,
                CategoryId = 3
            },

            // Productos para TacoBell -> Categoría 4, 5, 6
            new Product
            {
                Id = 5,
                Name = "Taco de Carne",
                Description = "Taco de carne molida y queso",
                Price = 600,
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = true,
                DiscountPercentage = 0,
                CategoryId = 4
            },
            new Product
            {
                Id = 6,
                Name = "Taco de Pollo",
                Description = "Taco de pollo desmechado",
                Price = 550,
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = false,
                DiscountPercentage = 0,
                CategoryId = 4
            },
            new Product
            {
                Id = 7,
                Name = "Burrito Clásico",
                Description = "Burrito de frijoles, carne y arroz",
                Price = 900,
                IsAvailable = true,
                IsHappyHour = true,
                IsFavorite = true,
                DiscountPercentage = 50,
                CategoryId = 5
            },
            new Product
            {
                Id = 8,
                Name = "Agua sin gas 500ml",
                Description = "Botella de agua",
                Price = 300,
                IsAvailable = true,
                IsHappyHour = false,
                IsFavorite = false,
                DiscountPercentage = 0,
                CategoryId = 6
            }
        );
    

    }
}
