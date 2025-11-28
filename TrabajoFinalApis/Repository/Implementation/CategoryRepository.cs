using TrabajoFinalApis.Data;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Repository.Interfaces;

namespace TrabajoFinalApis.Repository.Implementation;

public class CategoryRepository:ICategoryRepository
{
    private readonly TrabajoFinalApisContext _context; //llamado a la base de datos
    public CategoryRepository(TrabajoFinalApisContext context)
    {
        _context = context;
    }

    public void Add(Category category)
    {
        _context.Categories.Add(category);
    }

    public bool BelongsToRestaurant(int categoryId, int restaurantId)
    {
        return _context.Categories.Any(x => x.Id == categoryId && x.RestaurantId == restaurantId);
    }

    public bool Exists(int id)
    {
        return _context.Categories.Any(X => X.Id == id);
    }

    public Category? GetById(int id)
    {
        var categoria = _context.Categories.FirstOrDefault(x => x.Id == id);
        return categoria;
    }

    public IEnumerable<Category> GetByRestaurantId(int restaurantId)
    {
        var categorias = _context.Categories.Where(x => x.RestaurantId == restaurantId).ToList();
        return categorias;
    }

    public void Remove(Category category)
    {
        _context.Remove(category);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Update(Category category)
    {
        _context.Update(category);
    }
}


    
