using Microsoft.EntityFrameworkCore;
using TrabajoFinalApis.Data;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Repository.Interfaces;

namespace TrabajoFinalApis.Repository.Implementation;

public class UserRepository:IUserRepository
{
    private readonly TrabajoFinalApisContext _context; //llamado a la base de datos
    public UserRepository(TrabajoFinalApisContext context)
    {
        _context = context;
    }
    public bool CheckIfUserExists(int userId)
    {
        var usuario = _context.Users;
        if(usuario.Any(x => x.Id == userId))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int Create(User newUser)
    {
        var usuarios = _context.Users;
        newUser.Id = usuarios.Max(x => x.Id) + 1;
        usuarios.Add(newUser);
        return newUser.Id;
        
    }

    public List<User> GetAll()
    {
        var usuarios = _context.Users.ToList();
        return usuarios;
        
    }

    public User? GetById(int userId)
    {
        var usuario = _context.Users.FirstOrDefault(x => x.Id == userId);
        return usuario;
    }

    public User? GetUserByUsername(string username)
    {
        var usuario = _context.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        return usuario;
    }

    public void RemoveUser(int userId)
    {
        var usuario = _context.Users.FirstOrDefault(x => x.Id == userId);
        _context.Users.Remove(usuario);       
        
    }

    public void Update(User updatedUser, int userId)
    {
        throw new NotImplementedException();
    }
}
