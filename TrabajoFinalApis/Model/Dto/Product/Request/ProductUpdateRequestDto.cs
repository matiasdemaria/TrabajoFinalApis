using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.Product.Request
{
    public class ProductUpdateRequestDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        [Range(0.01, 999999.99)]
        public decimal Price { get; set; }
    }
}
