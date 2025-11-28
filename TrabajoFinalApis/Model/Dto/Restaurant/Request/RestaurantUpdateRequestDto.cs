using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.Restaurant.Request
{
    public class RestaurantUpdateRequestDto
    {
        [Required]
        [MaxLength(25)]
        public string RestaurantName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;
    }
}
