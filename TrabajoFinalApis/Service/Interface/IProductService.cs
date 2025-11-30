using System.Collections.Generic;
using TrabajoFinalApis.Model.Dto.Product.Request;
using TrabajoFinalApis.Model.Dto.Product.Response;

namespace TrabajoFinalApis.Service.Interface
{
    public interface IProductService
    {
        // Invitado
        ProductResponseDto? GetById(int productId);
        ICollection<ProductResponseDto> GetByRestaurant(int restaurantId);
        ICollection<ProductResponseDto> GetByCategory(int restaurantId, int categoryId);
        ICollection<ProductResponseDto> GetFavorites(int restaurantId);
        ICollection<ProductResponseDto> GetDiscounted(int restaurantId);
        ICollection<ProductResponseDto> GetHappyHour(int restaurantId);

        // Dueño
        public ProductResponseDto Create(int categoryId, int userId, ProductCreateRequestDto dto);
        ProductResponseDto Update(int userId, int productId, ProductUpdateRequestDto dto);
        void Remove(int userId, int productId);
        ProductResponseDto UpdateDiscount(int userId, int productId, ProductDiscountUpdateRequestDto dto);
        ProductResponseDto UpdateFavorite(int userId, int productId, ProductFavoriteUpdateRequestDto dto);
        ProductResponseDto UpdateHappyHour(int userId, int productId, ProductHappyHourUpdateRequestDto dto);
        ProductImportResultDto ImportFromCsv(int userId, int restaurantId, Stream csvStream);
        void IncreasePrices(int restaurantId, int userId, decimal percentage);
    }   
}
