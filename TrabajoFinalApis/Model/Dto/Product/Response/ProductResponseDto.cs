using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.Product.Response;

public class ProductResponseDto
{
    public int Id { get; set; }

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
}
