using System.Collections.Generic;
using System.Linq;
using TrabajoFinalApis.Data;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Repository.Interfaces;

namespace TrabajoFinalApis.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly TrabajoFinalApisContext _context;

        public ProductRepository(TrabajoFinalApisContext context)
        {
            _context = context;
        }
        public Product? GetById(int id)
        {
            return _context.Products
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetByRestaurantId(int restaurantId)
        {
            return _context.Products
                .Where(p => p.Category.RestaurantId == restaurantId)
                .ToList();
        }
        public IEnumerable<Product> GetByCategory(int restaurantId, int categoryId)
        {
            return _context.Products
                .Where(p => p.CategoryId == categoryId &&
                            p.Category.RestaurantId == restaurantId)
                .ToList();
        }

        public IEnumerable<Product> GetFavorites(int restaurantId)
        {
            return _context.Products
                .Where(p => p.IsFavorite &&
                            p.Category.RestaurantId == restaurantId)
                .ToList();
        }

        public IEnumerable<Product> GetDiscounted(int restaurantId)
        {
            return _context.Products
                .Where(p => p.Category.RestaurantId == restaurantId &&
                            p.DiscountPercentage != null)
                .ToList();
        }

        public IEnumerable<Product> GetHappyHour(int restaurantId)
        {
            return _context.Products
                .Where(p => p.Category.RestaurantId == restaurantId &&
                            p.IsHappyHour)
                .ToList();
        }


        // ----- Validaciones -----

        public bool Exists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }

        public bool BelongsToRestaurant(int productId, int restaurantId)
        {
            return _context.Products.Any(p =>
                p.Id == productId &&
                p.Category.RestaurantId == restaurantId);
        }

        // ----- CRUD -----

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
