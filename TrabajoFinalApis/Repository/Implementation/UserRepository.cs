using Microsoft.EntityFrameworkCore;
using TrabajoFinalApis.Data;
using TrabajoFinalApis.Entities;

namespace TrabajoFinalApis.Repository.Implementation;

public class UserRepository
{
    private readonly TrabajoFinalApisContext _context; //llamado a la base de datos
    public UserRepository(TrabajoFinalApisContext context)
    {
        _context = context;
    }

    
    public void test(int id)
    {
        var todos = _context.Users.FirstOrDefault(x => x.Id == id);
    }

}
