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
           products = new List<Product> { },
           RestaurantName = "WOWOWOW",
           Username = "OSTIA"
           
        };

        modelBuilder.Entity<User>().HasData(luis);

        base.OnModelCreating(modelBuilder);
    }
}
