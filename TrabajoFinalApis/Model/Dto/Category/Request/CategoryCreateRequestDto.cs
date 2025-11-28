using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.Category.Request
{
    public class CategoryCreateRequestDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }

    }
}
