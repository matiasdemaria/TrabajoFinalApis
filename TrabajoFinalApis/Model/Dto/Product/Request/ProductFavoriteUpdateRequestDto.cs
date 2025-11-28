using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.Product.Request;

public class ProductFavoriteUpdateRequestDto
{
    public bool IsFavorite { get; set; }
}
