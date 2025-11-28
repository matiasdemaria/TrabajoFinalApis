using System.Collections.Generic;
using TrabajoFinalApis.Entities;

namespace TrabajoFinalApis.Repository.Interfaces
{
    public interface ICategoryRepository
    {

        // Obtener una categoría por Id
        Category? GetById(int id);

        // Listar categorías de un restaurante
        IEnumerable<Category> GetByRestaurantId(int restaurantId);

        // Verificar si existe una categoría
        bool Exists(int id);

        // Verificar que una categoría pertenezca a un restaurante concreto
        bool BelongsToRestaurant(int categoryId, int restaurantId);

        // Crear categoría
        void Add(Category category);

        // Marcar cambios en una categoría ya existente
        void Update(Category category);

        // Eliminar (hard delete, el soft delete lo manejás en el servicio con IsActive)
        void Remove(Category category);

        // Guardar cambios en base
        int SaveChanges();
    }
}
