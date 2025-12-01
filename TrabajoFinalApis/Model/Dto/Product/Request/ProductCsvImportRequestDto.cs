using Microsoft.AspNetCore.Http;

namespace TrabajoFinalApis.Model.Dto.Product.Request
{
    public class ProductCsvImportRequestDto
    {
        public int RestaurantId { get; set; }   // viene también desde el form
        public IFormFile File { get; set; }     // el CSV
    }
}