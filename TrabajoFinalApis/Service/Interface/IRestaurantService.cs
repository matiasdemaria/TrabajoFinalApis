using System.Collections.Generic;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Model.Dto.Category;
using TrabajoFinalApis.Model.Dto.Category.Response;
using TrabajoFinalApis.Model.Dto.Restaurant.Request;
using TrabajoFinalApis.Model.Dto.Restaurant.Response;

namespace TrabajoFinalApis.Service.Interface;

public interface IRestaurantService
{
    // Invitado: lista de todos los restaurantes
    ICollection<RestaurantResponseDto> GetAll();

    // Invitado: detalle simple de un restaurante
    RestaurantResponseDto? GetById(int restaurantId);

    // Invitado: menú completo de un restaurante (categorías + productos)
    ICollection<CategoryWithProductsResponseDto> GetMenu(int restaurantId);
    
    // Dueño: lista de restaurantes del usuario logueado
    ICollection<RestaurantResponseDto> GetAllByUser(int userId);

    // Dueño: crear restaurante
    RestaurantResponseDto Create(int userId, RestaurantCreateRequestDto dto);

    // Dueño: actualizar restaurante (validando que le pertenezca)
    RestaurantResponseDto Update(int userId, int restaurantId, RestaurantUpdateRequestDto dto);

    // Dueño: borrar restaurante
    void Remove(int userId, int restaurantId);
    RestaurantResponseDto MapToRestaurantResponseDto(Restaurant r);
    

}

