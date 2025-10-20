using TrabajoFinalApis.Entities;

namespace TrabajoFinalApis.Service.Interface;

public interface IUserService
{
    User? Authenticate(string email, string password);

}
