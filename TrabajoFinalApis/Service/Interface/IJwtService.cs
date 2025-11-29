using TrabajoFinalApis.Entities;

namespace TrabajoFinalApis.Service.Interface
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
