using System.Collections.Generic;
using TrabajoFinalApis.Model.Dto.Product.Request;
using TrabajoFinalApis.Model.Dto.Product.Response;

namespace TrabajoFinalApis.Service.Interface
{
    public interface IProductService
    {
        // Invitado / dueño: detalle de un producto
        ProductResponseDto? GetById(int productId);

        // Invitado: productos de un restaurante
        ICollection<ProductResponseDto> GetByRestaurant(int restaurantId);

        // Invitado: productos de una categoría dentro de un restaurante
        ICollection<ProductResponseDto> GetByCategory(int restaurantId, int categoryId);

        // Invitado: productos favoritos de un restaurante
        ICollection<ProductResponseDto> GetFavorites(int restaurantId);

        // Invitado: productos con descuento
        ICollection<ProductResponseDto> GetDiscounted(int restaurantId);

        // Invitado: productos en happy hour
        ICollection<ProductResponseDto> GetHappyHour(int restaurantId);

        // Dueño: crear producto
        public ProductResponseDto Create(int categoryId, int userId, ProductCreateRequestDto dto);

        // Dueño: actualizar producto
        ProductResponseDto Update(int userId, int productId, ProductUpdateRequestDto dto);

        // Dueño: borrar producto
        void Remove(int userId, int productId);

        // Dueño: modificar descuento
        ProductResponseDto UpdateDiscount(int userId, int productId, ProductDiscountUpdateRequestDto dto);

        // Dueño: marcar/desmarcar como favorito
        ProductResponseDto UpdateFavorite(int userId, int productId, ProductFavoriteUpdateRequestDto dto);

        // Dueño: habilitar/deshabilitar happy hour
        ProductResponseDto UpdateHappyHour(int userId, int productId, ProductHappyHourUpdateRequestDto dto);
    }
}
