using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalApis.Entities;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get;set;}

    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    public bool IsAvailable { get; set; } = true;
    public decimal? DiscountPercentage { get; set; }

    public bool IsHappyHour { get; set; } = false;
    public TimeSpan? HappyHourStart { get; set; }
    public TimeSpan? HappyHourEnd { get; set; }

    public bool IsFavorite { get; set; } = false;

    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}