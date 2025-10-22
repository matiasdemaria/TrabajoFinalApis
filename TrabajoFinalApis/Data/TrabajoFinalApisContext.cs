using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using TrabajoFinalApis.Entities;

namespace TrabajoFinalApis.Data;

public class TrabajoFinalApisContext : DbContext
{
    public DbSet<User> users { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Category> categories { get; set; }
    public TrabajoFinalApisContext(DbContextOptions<TrabajoFinalApisContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        User luis = new User()
        {
            Id = 1,
            Email = "matiasdenamaria9@gmail.com",
            Password = "Lol",
            RestaurantName = "WOWOWOW",
            Username = "OSTIA",
            Adress = "paraguay  1950",
            IsActive = true,
            Categories = new List<Category>{
                 new Category
                {
                     id = 1,
                     Description = "Hamburguesas de nuestra cocina",
                     Name= "Hamburguesas",
                     UserId = 1,
                     products = new List<Product>
                     {

                     }

                     


                }

            },
            Phone = "343232",
            Products = new List<Product>()

        };

        modelBuilder.Entity<User>().HasData(luis);

        base.OnModelCreating(modelBuilder);
    }
}
