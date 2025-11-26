using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Model.Dto.User.Request;
using TrabajoFinalApis.Model.Dto.User.Response;

namespace TrabajoFinalApis.Service.Interface;

public interface IUserService
{
    User? ValidateUser(UserLoginDto loginDto);
    int RegisterUser(UserCreateDto UserRegister);
    void Update(int id,UserUpdateDto UserUpdate);
    void DeleteUser(int id);
    List<UserResponseDto> GetAllRestaurants();
    UserResponseDto? GetRestaurantById(int id);

}
