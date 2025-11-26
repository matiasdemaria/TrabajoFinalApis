using TrabajoFinalApis.Data;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Repository.Interfaces;

namespace TrabajoFinalApis.Repository.Implementation;

public class CategoryRepository : ICategoryRepository
{
    private readonly TrabajoFinalApisContext _context; //llamado a la base de datos
    public CategoryRepository(TrabajoFinalApisContext context)
    {
        _context = context;
    }

    public void Create(Category newCategory)
    {
        _context.Categories.Add(newCategory);
        _context.SaveChanges();
    }

    public void Delete(int userId, int idCategory)
    {
        var categoria = _context.Categories.FirstOrDefault(x => x.Id == idCategory && x.UserId == userId);
        _context.Remove(categoria);
        _context.SaveChanges();
    }
    public void Update(Category UpdateCategory)
    {
        _context.Categories.Update(UpdateCategory);
        _context.SaveChanges();
    }
    public IEnumerable<Category> GetAllCategories(int userId)
    {
        var categorias = _context.Categories.Where(x => x.UserId == userId).ToList();
        return categorias;
    }

    public Category? GetOneByUser(int userId, int categoryId)
    {
        var category = _context.Categories.FirstOrDefault(x => x.Id == categoryId && x.UserId == userId);
        return category;
    }
    
}


    
