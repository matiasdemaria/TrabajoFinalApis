using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalApis.Model.Dto.User.Request
{
    public class UserChangePasswordRequestDto
    {
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "La nueva contraseña debe tener al menos 6 caracteres.")]
        public string NewPassword { get; set; } = string.Empty;

        [Required]
        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}
