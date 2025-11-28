using System;

namespace TrabajoFinalApis.Model.Dto.User.Response
{
    public class AuthResponseDto //DILEMA PARA MÁS ADELANTE
    {
        public string Token { get; set; } = string.Empty;

        public DateTime ExpiresAt { get; set; }

        public UserResponseDto User { get; set; } = null!;
    }
}
