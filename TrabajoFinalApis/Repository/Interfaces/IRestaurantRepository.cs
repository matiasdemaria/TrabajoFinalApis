using TrabajoFinalApis.Entities;

namespace TrabajoFinalApis.Repository.Interfaces;

public interface IRestaurantRepository
{
    // Listar todos los restaurantes (para invitado)
    IEnumerable<Restaurant> GetAll();

    // 🔹 Para el dueño: solo sus restaurantes
    IEnumerable<Restaurant> GetAllByUserId(int userId);

    Restaurant? GetById(int restaurantId);

    Restaurant? GetByName(string restaurantName);

    void Add(Restaurant newRestaurant);

    void Update(Restaurant Restaurant);

    void Remove(Restaurant Restaurant);

    int SaveChanges();

    bool Exists(int restaurantId);

    bool BelongsToUser(int restaurantId, int userId);

}