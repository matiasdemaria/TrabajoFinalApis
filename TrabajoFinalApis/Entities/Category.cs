using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalApis.Entities;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public User user { get; set; }

    public ICollection<Product> products { get; set; } = new List<Product>();


}
