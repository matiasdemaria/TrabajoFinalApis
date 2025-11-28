using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TrabajoFinalApis.Data;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Repository.Interfaces;

namespace TrabajoFinalApis.Repository.Implementation
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly TrabajoFinalApisContext _context;

        public RestaurantRepository(TrabajoFinalApisContext context)
        {
            _context = context;
        }

        //🔹 Invitado: todos los restaurantes
        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.
            ToList();
        }

         //🔹 Dueño: solo sus restaurantes
        public IEnumerable<Restaurant> GetAllByUserId(int userId)
        {
            var restaurantes = _context.Restaurants
                .Where(x => x.UserId == userId)
                .ToList();

            return restaurantes;
        }

        public Restaurant? GetById(int restaurantId)
        {
            var restaurante = _context.Restaurants
                .FirstOrDefault(x => x.Id == restaurantId);

            return restaurante;
        }

        public Restaurant? GetByName(string restaurantName)
        {
            var restaurante = _context.Restaurants
                .FirstOrDefault(x => x.RestaurantName == restaurantName);
             //👆 Ajustá RestaurantName si en tu entidad se llama distinto

            return restaurante;
        }

        public void Add(Restaurant newRestaurant)
        {
            _context.Restaurants.Add(newRestaurant);
        }

        public void Update(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
        }

        public void Remove(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public bool Exists(int restaurantId)
        {
            return _context.Restaurants.Any(x => x.Id == restaurantId);
        }

        public bool BelongsToUser(int restaurantId, int userId)
        {
            return _context.Restaurants.Any(x => x.Id == restaurantId && x.UserId == userId);
        }
    }
}