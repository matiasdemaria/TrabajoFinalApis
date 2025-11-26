using TrabajoFinalApis.Entities;

namespace TrabajoFinalApis.Repository.Interfaces;

public interface IUserRepository
{
    bool CheckIfUserExists(int userId);
    User? GetUserByUsername(string username);
    int Create(User newUser);
    List<User> GetAll();
    User? GetById(int userId);
    User? GetByEmail(string email);
    void RemoveUser(int userId);
    void Update(User updatedUser, int userId);
}
