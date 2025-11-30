namespace TrabajoFinalApis.Model.Dto.Product.Response
{
    public class ProductImportResultDto
    {
        public int TotalRows { get; set; }
        public int ImportedProducts { get; set; }
        public int CreatedCategories { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
