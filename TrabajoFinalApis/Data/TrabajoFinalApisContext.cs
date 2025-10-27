using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
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
        new User { Address = "avenida 212", 
                   IsActive = true, 
                   Email = "matiasdemaria9@gmail", 
                   Id = 1, 
                   Password = "lol", 
                   Phone = "3464552", 
                   RestaurantName = "PizzaLol", 
                   Username = "matiasldemaria" },
        new User { Id = 2}
            );


        modelBuilder.Entity<Category>().HasData(
            new Category { Description = "Todo tipo de pizzas", 
                           Id = 1, 
                           Name = "Pizzas", 
                           UserId = 1 }
            );

        modelBuilder.Entity<Product>().HasData(
            new Product { UserId = 1, 
                          CategoryId = 1, 
                          Description = "Pizza de mozzarela", 
                          DiscountPercentage = 0, 
                          Id = 1, 
                          Price = 12, 
                          Name = "Pizza", 
                          IsHappyHour = false }
            );
        base.OnModelCreating(modelBuilder);

    }
}
