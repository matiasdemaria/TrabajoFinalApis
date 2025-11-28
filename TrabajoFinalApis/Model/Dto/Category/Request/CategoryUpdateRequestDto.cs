namespace TrabajoFinalApis.Model.Dto.Category
{
    public class CategoryUpdateDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }

    }
}
