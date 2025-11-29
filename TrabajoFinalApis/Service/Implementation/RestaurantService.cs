using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Model.Dto.Category;
using TrabajoFinalApis.Model.Dto.Product.Response;
using TrabajoFinalApis.Model.Dto.Restaurant.Request;
using TrabajoFinalApis.Model.Dto.Restaurant.Response;
using TrabajoFinalApis.Repository.Interfaces;
using TrabajoFinalApis.Service.Interface;

namespace TrabajoFinalApis.Services.Implementation;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;

    public RestaurantService(IRestaurantRepository restaurantRepository, IUserRepository userRepository, ICategoryRepository categoryRepository, IProductRepository productRepository)
    {
        _restaurantRepository = restaurantRepository;
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }

    public RestaurantResponseDto Create(int userId, RestaurantCreateRequestDto dto)
    {
        if (!_userRepository.ExistsById(userId))
        {
            throw new Exception("El usuario no es válido para crear el restaurante.");
        }

        if (_restaurantRepository.GetByName(dto.RestaurantName) != null)
        {
            throw new Exception("Ya existe un restaurante con ese nombre.");
        }

        var newRestaurant = new Restaurant
        {
            RestaurantName = dto.RestaurantName,
            Description = dto.Description,
            Address = dto.Address,
            Phone = dto.Phone,
            UserId = userId,
            IsActive = true
        };

        _restaurantRepository.Add(newRestaurant);
        _restaurantRepository.SaveChanges();

        return MapToRestaurantResponseDto(newRestaurant);
    }

    public void Remove(int userId, int restaurantId)
    {
        var restaurant = _restaurantRepository.GetById(restaurantId);

        if (restaurant == null)
            throw new Exception("El restaurante que desea borrar no existe.");

        // VALIDACIÓN DE SEGURIDAD
        if (restaurant.UserId != userId)
            throw new Exception("No tienes permiso para borrar este restaurante.");

        _restaurantRepository.Remove(restaurant);
        _restaurantRepository.SaveChanges();
    }

    public RestaurantResponseDto Update(int userId, int restaurantId, RestaurantUpdateRequestDto dto)
    {
        var restaurant = _restaurantRepository.GetById(restaurantId);

        if (restaurant == null)
            throw new Exception("El restaurante que desea actualizar no existe.");

        if (restaurant.UserId != userId)
            throw new Exception("El usuario no puede modificar este restaurante.");

        restaurant.Address = dto.Address;
        restaurant.Description = dto.Description;
        restaurant.Phone = dto.Phone;
        restaurant.RestaurantName = dto.RestaurantName;
        // No hace falta actualizar UserId ni Id, esos no cambian.

        _restaurantRepository.Update(restaurant);
        _restaurantRepository.SaveChanges();

        return MapToRestaurantResponseDto(restaurant);
    }

    public ICollection<RestaurantResponseDto> GetAll()
    {
        var restaurants = _restaurantRepository.GetAll();
        return restaurants.Select(MapToRestaurantResponseDto).ToList();
    }

    public ICollection<RestaurantResponseDto> GetAllByUser(int userId)
    {
        if (!_userRepository.ExistsById(userId))
            throw new Exception("El usuario no existe.");

        var restaurants = _restaurantRepository.GetAllByUserId(userId);

        if (restaurants == null)
            return new List<RestaurantResponseDto>();

        return restaurants.Select(MapToRestaurantResponseDto).ToList();
    }

    public RestaurantResponseDto GetById(int restaurantId)
    {
        var restaurant = _restaurantRepository.GetById(restaurantId);

        if (restaurant == null)
            throw new Exception("El restaurante no existe.");

        return MapToRestaurantResponseDto(restaurant);
    }

    public ICollection<CategoryWithProductsResponseDto> GetMenu(int restaurantId)
    {
        if (!_restaurantRepository.Exists(restaurantId))
        {
            throw new Exception("El restaurante no existe.");
        }

        var categories = _categoryRepository.GetByRestaurantId(restaurantId);
        var allProducts = _productRepository.GetByRestaurantId(restaurantId);

        var menu = new List<CategoryWithProductsResponseDto>();

        foreach (var category in categories)
        {
            var productsInThisCategory = allProducts
                .Where(p => p.CategoryId == category.Id)
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    IsAvailable = p.IsAvailable, 
                    IsFavorite = p.IsFavorite,
                    DiscountPercentage = p.DiscountPercentage,
                    IsHappyHour = p.IsHappyHour,
                    HappyHourStart = p.HappyHourStart,
                    HappyHourEnd = p.HappyHourEnd
                })
                .ToList();

            menu.Add(new CategoryWithProductsResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Products = productsInThisCategory
            });
        }

        return menu;
    }

    // Método privado para evitar repetir código de mapeo
    public RestaurantResponseDto MapToRestaurantResponseDto(Restaurant r)
    {
        return new RestaurantResponseDto
        {
            Id = r.Id,
            RestaurantName = r.RestaurantName,
            Description = r.Description,
            Address = r.Address,
            Phone = r.Phone,
            IsActive = r.IsActive
        };
    }
}