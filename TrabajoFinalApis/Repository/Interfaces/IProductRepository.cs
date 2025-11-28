using System.Collections.Generic;
using TrabajoFinalApis.Entities;

namespace TrabajoFinalApis.Repository.Interfaces
{
    public interface IProductRepository
    {
        // ----- Búsquedas básicas -----

        // Traer un producto por Id (para detalle, editar, borrar, etc.)
        Product? GetById(int id);

        // Todos los productos de un restaurante
        IEnumerable<Product> GetByRestaurantId(
            int restaurantId

        );

        // Productos de una categoría dentro de un restaurante (para filtro por categoría)
        IEnumerable<Product> GetByCategory(
            int restaurantId,
            int categoryId
          
        );

        // Productos marcados como favoritos (invited: "productos favoritos")
        IEnumerable<Product> GetFavorites(
            int restaurantId
            
        );

        // Productos con descuento
        IEnumerable<Product> GetDiscounted(
            int restaurantId

        );

        // Productos en happy hour
        IEnumerable<Product> GetHappyHour(
            int restaurantId
            
        );

        // ----- Validaciones -----

        // Ver si existe un producto
        bool Exists(int id);

        // Verificar que el producto pertenezca a un restaurante
        // (vía Category.RestaurantId, la implementación se encarga del join)
        bool BelongsToRestaurant(int productId, int restaurantId);

        // ----- CRUD -----

        // Crear producto
        void Add(Product product);

        // Marcar como modificado
        void Update(Product product);

        // Eliminar (borrado físico; si querés soft delete lo manejás en el servicio con IsAvailable/IsActive)
        void Remove(Product product);

        // Persistir cambios en la base
        int SaveChanges();
    }
}
