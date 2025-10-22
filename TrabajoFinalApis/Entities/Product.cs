using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalApis.Entities;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    [Required]
    public decimal Price { get; set; }

    public decimal? DiscountPercentage { get; set; }
    public bool IsHappyHour { get; set; } = false;
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set;}

    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category category { get; set; }
}
