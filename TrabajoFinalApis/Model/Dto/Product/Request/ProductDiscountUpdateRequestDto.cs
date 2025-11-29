using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.Product.Request;

public class ProductDiscountUpdateRequestDto
{
    [Range(0, 100)]
    public decimal? DiscountPercentage { get; set; }
}

