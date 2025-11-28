using TrabajoFinalApis.Entities;

namespace TrabajoFinalApis.Repository.Interfaces;

public interface IUserRepository
{
    // Lecturas
    bool ExistsById(int userId);

    User? GetById(int userId);

    User? GetByEmail(string email);
    
    User? GetByUsername(string username);

    // Altas, bajas, modificaciones
    void Add(User newUser);

    void Update(User user);

    void Remove(User user);

    // Confirmar cambios en DB (EF)
    int SaveChanges();
}