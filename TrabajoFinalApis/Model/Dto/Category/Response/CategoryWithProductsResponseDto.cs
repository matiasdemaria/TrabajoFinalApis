using System.Collections.Generic;
using TrabajoFinalApis.Model.Dto.Product.Response;

namespace TrabajoFinalApis.Model.Dto.Category
{
    public class CategoryWithProductsResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public List<ProductResponseDto> Products { get; set; }
            = new List<ProductResponseDto>();
    }
}
