using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Service.Interface;
using TrabajoFinalApis.Repository.Implementation;
using TrabajoFinalApis.Repository.Interfaces;
using TrabajoFinalApis.Model.Dto.User.Response;
using TrabajoFinalApis.Model.Dto.User.Request;
using System.Security.Cryptography.Xml;

namespace TrabajoFinalApis.Service.Implementation;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }



}   

