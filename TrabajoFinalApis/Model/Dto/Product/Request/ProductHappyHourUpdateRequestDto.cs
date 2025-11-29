using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.Product.Request
{
    public class ProductHappyHourUpdateRequestDto
    {
        public bool IsHappyHour { get; set; }
        public TimeSpan? HappyHourStart { get; set; }
        public TimeSpan? HappyHourEnd { get; set; }
    }

}
