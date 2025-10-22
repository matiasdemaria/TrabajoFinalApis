using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace TrabajoFinalApis.Entities;
public class User //Restaurantes
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Password { get; set; } = string.Empty;

    
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(25)]
    public string RestaurantName { get; set; }

    public bool IsActive { get; set; } = true;

    public string Adress { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<Category> Categories { get; set; } = new List<Category>();


}
