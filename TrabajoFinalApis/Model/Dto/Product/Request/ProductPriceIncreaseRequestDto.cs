using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace TrabajoFinalApis.Model.Dto.Product.Request;

public class ProductPriceIncreaseRequestDto
{
    [Required]
    [Range(0.1,500,ErrorMessage = "El porcentaje debe estar dentro de 0,1% y 500%")]
    public decimal percentage { get; set; }
}
