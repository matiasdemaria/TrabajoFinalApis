using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.Restaurant.Response;
public class RestaurantResponseDto
{
    public int Id { get; set; }

    [MaxLength(25)]
    [Required]
    public string RestaurantName { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    [Required]
    public string Phone { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}
