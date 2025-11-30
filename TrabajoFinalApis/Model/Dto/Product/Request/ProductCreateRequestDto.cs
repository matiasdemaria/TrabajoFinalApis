using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.Product.Request;
public class ProductCreateRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [Required]
    [Range(0.1,double.MaxValue,ErrorMessage ="El precio del producto no puede ser 0")]
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;

}
