using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Model.Dto.User.Request;
using TrabajoFinalApis.Model.Dto.User.Response;

namespace TrabajoFinalApis.Service.Interface;

public interface IUserService
{
    UserResponseDto Register(UserCreateRequestDto dto);
    AuthResponseDto Login(UserLoginRequestDto dto);
    UserResponseDto GetById(int userId);
    UserResponseDto Update(int userId, UserUpdateRequestDto dto);

    // CAMBIAR CONTRASEÑA
    void ChangePassword(int userId, UserChangePasswordRequestDto dto);

    // ELIMINAR CUENTA → “REMOVE”
    void Remove(int userId);


}

