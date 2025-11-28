
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace TrabajoFinalApis.Entities;
public class User 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(25)]
    public string Username { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }

    [EmailAddress]
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = true;

    public ICollection<Restaurant> Restaurants{ get; set; } = new List<Restaurant>();
}
