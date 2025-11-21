using TrabajoFinalApis.Entities;
namespace TrabajoFinalApis.Repository.Interfaces;

public interface IProductRepository
{
    int Create(Product product);
    void Remove(int productId, int userId);
    void Update(Product product);
    List<Product> GetAllProductsByUser(int userId);
    List<Product> GetProductsByCategory(int categoryId, int userId);
    Product GetProductById(int productId, int userId);
    List<Product> GetFavorites(int userId);
    List<Product> GetHappyHourProducts(int userId);
}
