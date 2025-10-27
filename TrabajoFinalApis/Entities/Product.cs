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

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set;}

    public int CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}
