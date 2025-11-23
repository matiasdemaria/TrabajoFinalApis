using TrabajoFinalApis.Data;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Repository.Interfaces;

namespace TrabajoFinalApis.Repository.Implementation;

public class ProductRepository:IProductRepository
{
    private readonly TrabajoFinalApisContext _context; //llamado a la base de datos
    public ProductRepository(TrabajoFinalApisContext context)
    {
        _context = context;
    }
    public int Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product.Id;
    }

    public List<Product> GetAllProductsByUser(int userId)
    {
        var productos = _context.Products.Where(x => x.UserId == userId).ToList();
        return productos;
    }

    public List<Product> GetFavorites(int userId)
    {
        var favoritos = _context.Products.Where(x => x.UserId == userId).Where(x => x.IsFavorite == true).ToList();
        return favoritos;
    }

    public List<Product> GetHappyHourProducts(int userId)
    {
        var happyHour = _context.Products.Where(x => x.UserId == userId).Where(x => x.IsHappyHour == true).ToList();
        return happyHour;
    }

    public Product GetProductById(int productId, int userId)
    {
        var producto = _context.Products.Where(x => x.UserId == userId).Where(x => x.Id == productId).ToList();
        return producto;
    }

    public List<Product> GetProductsByCategory(int categoryId, int userId)
    {
        throw new NotImplementedException();
    }

    public void Remove(int productId, int userId)
    {
        throw new NotImplementedException();
    }

    public void Update(Product product)
    {
        throw new NotImplementedException();
    }
}
