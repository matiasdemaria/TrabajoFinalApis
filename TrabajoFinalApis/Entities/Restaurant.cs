using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalApis.Entities;

public class Restaurant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(25)]
    [Required]
    public string RestaurantName { get; set; } = string.Empty;
    
    public string? Description { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    [Required]
    public string Phone { get; set; } = string.Empty;
  
    public bool IsActive { get; set; }

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; } = null!; //No puede haber un restaurante sin usuario.

    public ICollection<Category> Categories { get; set; } = new List<Category>();
}
