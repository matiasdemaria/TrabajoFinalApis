using TrabajoFinalApis.Data;

namespace TrabajoFinalApis.Repository.Implementation;

public class CategoryRepository
{
    private readonly TrabajoFinalApisContext _context; //llamado a la base de datos
    public CategoryRepository(TrabajoFinalApisContext context)
    {
        _context = context;
    }
}
