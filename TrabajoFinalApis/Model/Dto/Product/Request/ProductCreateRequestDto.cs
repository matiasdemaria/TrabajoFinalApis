using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.Product.Request;
public class ProductCreateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;
}
