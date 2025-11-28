using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.User.Request
{
    public class UserUpdateRequestDto
    {
        [Required]
        [MaxLength(25)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
    }
}
