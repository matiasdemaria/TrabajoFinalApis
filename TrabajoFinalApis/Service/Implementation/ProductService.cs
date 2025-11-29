using System.Transactions;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Model.Dto.Product.Request;
using TrabajoFinalApis.Model.Dto.Product.Response;
using TrabajoFinalApis.Repository.Interfaces;
using TrabajoFinalApis.Service.Interface;

namespace TrabajoFinalApis.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public ProductService(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IRestaurantRepository restaurantRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _restaurantRepository = restaurantRepository;
        }

        public ProductResponseDto? GetById(int productId)
        {
            var product = _productRepository.GetById(productId);
            return product == null ? null : MapToProductResponseDto(product);
        }

        public ICollection<ProductResponseDto> GetByRestaurant(int restaurantId)
        {
            var products = _productRepository.GetByRestaurantId(restaurantId);
            return products
                .Select(MapToProductResponseDto)
                .ToList();
        }

        public ICollection<ProductResponseDto> GetByCategory(int restaurantId, int categoryId)
        {
            var products = _productRepository.GetByCategory(restaurantId, categoryId);
            return products
                .Select(MapToProductResponseDto)
                .ToList();
        }

        public ICollection<ProductResponseDto> GetFavorites(int restaurantId)
        {
            var products = _productRepository.GetFavorites(restaurantId);
            return products
                .Select(MapToProductResponseDto)
                .ToList();
        }

        public ICollection<ProductResponseDto> GetDiscounted(int restaurantId)
        {
            var products = _productRepository.GetDiscounted(restaurantId);
            return products
                .Select(MapToProductResponseDto)
                .ToList();
        }

        public ICollection<ProductResponseDto> GetHappyHour(int restaurantId)
        {
            var products = _productRepository.GetHappyHour(restaurantId);
            return products
                .Select(MapToProductResponseDto)
                .ToList();
        }

        //  DUEÑO 

        public ProductResponseDto Create(int categoryId, int userId, ProductCreateRequestDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            // 1) Validar categoría
            var category = _categoryRepository.GetById(categoryId);
            if (category == null || !category.IsActive)
                throw new Exception("Categoría no encontrada o inactiva.");

            // 2) Validar que el restaurante de esa categoría pertenezca al usuario
            var restaurant = _restaurantRepository.GetById(category.RestaurantId);
            if (restaurant == null)
                throw new Exception("Restaurante asociado no encontrado.");

            if (restaurant.UserId != userId)
                throw new Exception("No tenés permisos para crear productos en este restaurante.");

            // 3) Crear entidad
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                IsAvailable = dto.IsAvailable,   
                IsFavorite = false,              
                DiscountPercentage = null,       
                IsHappyHour = false,             
                CategoryId = categoryId
            };

            _productRepository.Add(product);
            var saved = _productRepository.SaveChanges();

            if (saved == 0)
                throw new Exception("No se pudo guardar el producto.");

            return MapToProductResponseDto(product);
        }


        public ProductResponseDto Update(int productId, int userId, ProductUpdateRequestDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new Exception("Producto no encontrado.");

            var category = _categoryRepository.GetById(product.CategoryId);
            if (category == null || !category.IsActive)
                throw new Exception("Categoría asociada no encontrada o inactiva.");

            var restaurant = _restaurantRepository.GetById(category.RestaurantId);
            if (restaurant == null)
                throw new Exception("Restaurante asociado no encontrado.");

            if (restaurant.UserId != userId)
                throw new Exception("No tenés permisos para modificar productos en este restaurante.");

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;

            _productRepository.Update(product);
            var saved = _productRepository.SaveChanges();

            if (saved == 0)
                throw new Exception("No se pudo guardar el producto.");

            return MapToProductResponseDto(product);
        }





        public void Remove(int userId, int productId)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new Exception("Producto no encontrado.");

            ValidateProductOwnership(userId, product);

            _productRepository.Remove(product);
            var saved = _productRepository.SaveChanges();

            if (saved == 0)
                throw new Exception("No se pudo guardar los cambios.");
        }


        public ProductResponseDto UpdateDiscount(int userId, int productId, ProductDiscountUpdateRequestDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new Exception("Producto no encontrado.");

            ValidateProductOwnership(userId, product);

            product.DiscountPercentage = dto.DiscountPercentage;

            _productRepository.Update(product);
            var saved = _productRepository.SaveChanges();

            if (saved == 0)
                throw new Exception("No se pudo guardar el producto.");

            return MapToProductResponseDto(product);
        }


        public ProductResponseDto UpdateFavorite(int userId, int productId, ProductFavoriteUpdateRequestDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new Exception("Producto no encontrado.");

            ValidateProductOwnership(userId, product);

            product.IsFavorite = dto.IsFavorite;

            _productRepository.Update(product);
            var saved = _productRepository.SaveChanges();

            if (saved == 0)
                throw new Exception("No se pudo guardar el producto.");

            return MapToProductResponseDto(product);
        }





        public ProductResponseDto UpdateHappyHour(int userId, int productId, ProductHappyHourUpdateRequestDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                throw new Exception("Producto no encontrado.");
            }

            ValidateProductOwnership(userId, product);

            product.IsHappyHour = dto.IsHappyHour;
            product.HappyHourEnd = dto.HappyHourEnd;
            product.HappyHourStart = dto.HappyHourStart;

            _productRepository.Update(product);

            var saved = _productRepository.SaveChanges();
            if (saved == 0)
            {
                throw new Exception("No se pudo guardar el producto.");
            }

            return MapToProductResponseDto(product);
        }




        private void ValidateProductOwnership(int userId, Product product)
        {
            // Traigo la categoría del producto
            var category = _categoryRepository.GetById(product.CategoryId);
            if (category == null)
            {
                throw new Exception("Categoría asociada al producto no encontrada.");
            }
            
            // Traigo el restaurante
            var restaurant = _restaurantRepository.GetById(category.RestaurantId);
            if (restaurant == null)
            {
                throw new Exception("Restaurante asociado al producto no encontrado.");
            }
                
            if (restaurant.UserId != userId)
            {
                throw new Exception("No tenés permisos para operar sobre este producto.");
            }
        }

        private ProductResponseDto MapToProductResponseDto(Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsFavorite = product.IsFavorite,
                DiscountPercentage = product.DiscountPercentage,
                IsHappyHour = product.IsHappyHour,
            };
        }
    }
}
