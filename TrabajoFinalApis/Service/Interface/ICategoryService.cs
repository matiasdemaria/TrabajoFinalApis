using System.Collections.Generic;
using TrabajoFinalApis.Model.Dto.Category.Request;
using TrabajoFinalApis.Model.Dto.Category.Response;
using TrabajoFinalApis.Model.Dto.Category; // CategoryUpdateRequestDto

namespace TrabajoFinalApis.Service.Interface
{
    public interface ICategoryService
    {
        // Invitado / dueño: listar categorías activas de un restaurante
        IEnumerable<CategoryResponseDto> GetByRestaurant(int restaurantId);

        // Dueño: crear categoría para uno de sus restaurantes
        CategoryResponseDto Create(int restaurantId, int UserId, CategoryCreateRequestDto dto);

        // Dueño: editar categoría propia
        CategoryResponseDto Update(int categoryId, int UserId, CategoryUpdateRequestDto dto);

        // Dueño: "borrar" categoría (soft delete: IsActive = false)
        void Remove(int categoryId, int UserId);
    }
}
