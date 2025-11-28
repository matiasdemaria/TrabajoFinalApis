using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Service.Interface;
using TrabajoFinalApis.Repository.Implementation;
using TrabajoFinalApis.Repository.Interfaces;
using TrabajoFinalApis.Model.Dto.User.Response;
using TrabajoFinalApis.Model.Dto.User.Request;
using System.Security.Cryptography.Xml;

namespace TrabajoFinalApis.Service.Implementation;

//public class UserService : IUserService
//{
//    private UserRepository userRepository = new UserRepository();

//    public void DeleteUser(int id)
//    {
//        if (userRepository.GetById(id) != null)
//        {
//            userRepository.RemoveUser(id);
//        }
//        else
//        {
//            throw new Exception("El usuario que desea borrar no existe");
//        }
        
//    }

//    public List<UserResponseDto> GetAllRestaurants()
//    {
//        var restaurantes = userRepository.GetAll();
//        if(restaurantes != null)
//        {
//            return restaurantes.Select(x => new UserResponseDto
//            {
//                Email = x.Email,
//                Adress = x.Address,
//                id = x.Id,
//                Phone = x.Phone,
//                RestaurantName = x.RestaurantName
//            }).ToList();
//        }
//        else
//        {
//            throw new Exception("No existen restaurantes");
//        }  
//    }

//    public UserResponseDto? GetRestaurantById(int id)
//    {
//        var restaurante = userRepository.GetById(id);
//        if(restaurante != null)
//        {
//            var restauranteResponse = new UserResponseDto
//            {
//                Adress = restaurante.Address,
//                Email = restaurante.Email,
//                id = restaurante.Id,
//                Phone = restaurante.Phone,
//                RestaurantName = restaurante.RestaurantName
//            };
//            return restauranteResponse;
//        }
//        else
//        {
//            throw new Exception("No existe restaurante con ese id");
//        }
//    }

//    public int RegisterUser(UserCreateDto UserRegister) //Hay que realizar una autenthicacion con JWT
//    {   
//        throw new NotImplementedException();
//    }

//    public void Update(int id, UserUpdateDto UserUpdate)
//    {
//        var usuario = userRepository.GetById(id);
//        if(usuario != null)
//        {
//            usuario.RestaurantName = UserUpdate.RestaurantName;
//            usuario.Email = UserUpdate.Email;
//            usuario.Address = UserUpdate.Adress;
//            usuario.Phone = UserUpdate.Phone;

//        }
//        else
//        {
//            throw new Exception("El usuario que desea actualizar no existe");
//        }
//    }

//    public User? ValidateUser(UserLoginDto loginDto)
//    {

//        throw new NotImplementedException();
//    }//Tambien hay que realiizar algo con JWT

