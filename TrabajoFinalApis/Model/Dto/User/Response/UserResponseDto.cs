namespace TrabajoFinalApis.Model.Dto.User.Response
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Si querés mostrar los restaurantes del usuario, después podés agregar:
        // public ICollection<RestaurantResponseDto> Restaurants { get; set; } = new List<RestaurantResponseDto>();
    }
}

