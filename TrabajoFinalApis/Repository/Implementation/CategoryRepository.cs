using TrabajoFinalApis.Data;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Repository.Interfaces;

namespace TrabajoFinalApis.Repository.Implementation;

public class CategoryRepository : ICategoryRepository
{
    public CategoryRepository(TrabajoFinalApisContext context)
    {
        _context = context;
    }

    public void Create(Category newCategory)
    {
        throw new NotImplementedException();
    }

    public void Delete(int userId, int idCategory)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetAllCategories(int userId)
    {
        throw new NotImplementedException();
    }

    public Category? GetOneByUser(int userId, int contactId)
    {
        throw new NotImplementedException();
    }

    public void Update(int userId, Category UpdateCategory, int categoryId)
    {
        throw new NotImplementedException();
    }
}

private readonly TrabajoFinalApisContext _context; //llamado a la base de datos
    
}
