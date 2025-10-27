using TrabajoFinalApis.Data;

namespace TrabajoFinalApis.Repository.Implementation;

public class ProductRepository
{
    private readonly TrabajoFinalApisContext _context; //llamado a la base de datos
    public ProductRepository(TrabajoFinalApisContext context)
    {
        _context = context;
    }
}
