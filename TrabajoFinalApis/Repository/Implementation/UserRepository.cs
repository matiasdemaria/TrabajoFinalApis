using Microsoft.EntityFrameworkCore;
using TrabajoFinalApis.Data;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Repository.Interfaces;

namespace TrabajoFinalApis.Repository.Implementation;

public class UserRepository : IUserRepository
{
    private readonly TrabajoFinalApisContext _context; //llamado a la base de datos
    public UserRepository(TrabajoFinalApisContext context)
    {
        _context = context;
    }

    public void Add(User newUser)
    {
        _context.Add(newUser);
    }

    public void Remove(User user)
    {
        _context.Remove(user);
    }

    public bool ExistsById(int userId)
    {
        return _context.Users.Any(x => x.Id == userId);
    }

    public User? GetByEmail(string email)
    {
        var usuario = _context.Users.FirstOrDefault(x => x.Email== email);
        return usuario;
    }

    public User? GetById(int userId)
    {
        var usuario = _context.Users.FirstOrDefault(x => x.Id == userId);
        return usuario;
    }

    public User? GetByUsername(string username)
    {
        var usuario = _context.Users.FirstOrDefault(x => x.Username == username);
        return usuario;
    }

    public int SaveChanges()
    {
        // Devuelve true si se afectó al menos 1 fila
        return _context.SaveChanges();
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }
}


