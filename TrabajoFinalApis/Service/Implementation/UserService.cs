using System;
using BCrypt.Net;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Model.Dto.User.Request;
using TrabajoFinalApis.Model.Dto.User.Response;
using TrabajoFinalApis.Repository.Interfaces;
using TrabajoFinalApis.Service.Interface;

namespace TrabajoFinalApis.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }


        public UserResponseDto Register(UserCreateRequestDto dto)
        {
            if (dto == null)
                throw new BadHttpRequestException("No se enviaron los datos");

            var email = dto.Email.Trim().ToLower();

            // Verificar email duplicado
            if (_userRepository.GetByEmail(email) != null)
                throw new BadHttpRequestException("El email ya está registrado.");

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password) //Protege la contraseña del usuario
            };

            _userRepository.Add(user);
            var saved = _userRepository.SaveChanges();

            if (saved == 0)
                throw new Exception("No se pudo guardar el usuario.");

            return MapToUserResponseDto(user); //Facilita la transformación de la variable al dto.
        } 
        
        public AuthResponseDto Login(UserLoginRequestDto dto)
        {
            if (dto == null)
            throw new BadHttpRequestException("No se enviaron los datos correspondientes.");

            var email = dto.Email.Trim().ToLower();
            var user = _userRepository.GetByEmail(email);

            if (user == null || user.IsActive == false)
                throw new InvalidOperationException("Credenciales inválidas.");

            var passwordOk = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);//Compara la contraseña hasheada con la enviada.
            if (!passwordOk)
                throw new InvalidOperationException("Credenciales inválidas.");

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token, //Aca se guarda el token generado
                User = MapToUserResponseDto(user)
            };
        }


        public UserResponseDto GetById(int userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null || user.IsActive == false)
            {
                throw new KeyNotFoundException("Usuario no encontrado o inactivo.");
            }

            return MapToUserResponseDto(user);
        }


        public UserResponseDto Update(int userId, UserUpdateRequestDto dto)
        {
            if (dto == null)
                throw new Exception("Estan mal los datos");

            var user = _userRepository.GetById(userId);

            if (user == null || user.IsActive == false)
                throw new Exception("Usuario no encontrado o inactivo.");

            var newEmail = dto.Email.Trim().ToLower();

            var existing = _userRepository.GetByEmail(newEmail);
            if (existing != null && existing.Id != userId)
                throw new Exception("Ya existe un usuario con ese email.");

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = newEmail;

            _userRepository.Update(user);
            var saved = _userRepository.SaveChanges();

            if (saved == 0)
                throw new Exception("No se pudo guardar el usuario.");

            return MapToUserResponseDto(user);
        }


        public void ChangePassword(int userId, UserChangePasswordRequestDto dto)
        {
            if (dto == null)
                throw new Exception("Envia bien los datos");

            var user = _userRepository.GetById(userId);

            if (user == null || user.IsActive == false)
                throw new Exception("Usuario no encontrado.");

            // Validar contraseña actual
            var currentOk = BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, user.PasswordHash);
            if (!currentOk)
                throw new Exception("La contraseña actual no es correcta.");

            if (dto.NewPassword != dto.ConfirmNewPassword)
                throw new Exception("Las contraseñas nuevas no coinciden.");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);

            _userRepository.Update(user);
            var saved = _userRepository.SaveChanges();

            if (saved == 0)
                throw new Exception("No se pudo guardar el usuario.");
        }


        public void Remove(int userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            _userRepository.Remove(user);

            var saved = _userRepository.SaveChanges();

            if (saved <= 0)
                throw new Exception("No se pudo guardar los cambios.");
        }


        private UserResponseDto MapToUserResponseDto(User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}
