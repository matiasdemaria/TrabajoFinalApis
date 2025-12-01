using System.Transactions;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Model.Dto.Product.Request;
using TrabajoFinalApis.Model.Dto.Product.Response;
using TrabajoFinalApis.Repository.Interfaces;
using TrabajoFinalApis.Service.Interface;
using System.IO;
using System.Linq;
using System.Collections.Generic;



namespace TrabajoFinalApis.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IRestaurantRepository restaurantRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _restaurantRepository = restaurantRepository;
        }

        //INVITADO
        public ProductResponseDto? GetById(int productId)
        {
            var product = _productRepository.GetById(productId);

            if (product == null)
                throw new KeyNotFoundException($"No se encontro el producto con Id {productId}");

            return MapToProductResponseDto(product);
        }
        public ICollection<ProductResponseDto> GetByRestaurant(int restaurantId)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);
            if (restaurant == null)
                throw new KeyNotFoundException($"No existe un restaurante con Id {restaurantId}.");

            var products = _productRepository.GetByRestaurantId(restaurantId);
            if (products == null || products.Any() == false)
                throw new KeyNotFoundException($"El restaurante con Id {restaurantId} no tiene productos");

            return products.Select(MapToProductResponseDto).ToList();
        }
        public ICollection<ProductResponseDto> GetByCategory(int restaurantId, int categoryId)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);
            if (restaurant == null)
                throw new KeyNotFoundException($"No existe un restaurante con Id {restaurantId}.");

            var categories = _categoryRepository.GetById(categoryId);
            if (categories == null)
                throw new KeyNotFoundException($"No existe una categoria con Id {categoryId}.");

            var products = _productRepository.GetByCategory(restaurantId, categoryId);
            if (products == null)
                throw new KeyNotFoundException($"No existen productos en la categoria con Id {categoryId}");

            return products.Select(MapToProductResponseDto).ToList();
        }
        public ICollection<ProductResponseDto> GetFavorites(int restaurantId)
        {
            var products = _productRepository.GetFavorites(restaurantId);
            if (products == null || !products.Any())
                throw new KeyNotFoundException($"El restaurante no tiene productos favoritos");

            return products.Select(MapToProductResponseDto).ToList();
        }
        public ICollection<ProductResponseDto> GetDiscounted(int restaurantId)
        {
            var products = _productRepository.GetDiscounted(restaurantId);
            if (products == null || !products.Any())
                throw new KeyNotFoundException($"El restaurante no tiene productos con descuento");

            return products.Select(MapToProductResponseDto).ToList();
        }
        public ICollection<ProductResponseDto> GetHappyHour(int restaurantId)
        {
            if (_restaurantRepository.Exists(restaurantId) == false)
                throw new KeyNotFoundException($"No existe un restaurante con Id {restaurantId}.");

            var products = _productRepository.GetHappyHour(restaurantId);
            if (products == null || products.Any() == false)
                throw new KeyNotFoundException($"El restaurante no tiene productos en Happy Hour");

            return products.Select(MapToProductResponseDto).ToList();
        }

        //  DUEÑO 
        public ProductResponseDto Create(int categoryId, int userId, ProductCreateRequestDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var category = _categoryRepository.GetById(categoryId);
            if (category == null || category.IsActive == false)
                throw new Exception("Categoría no encontrada o inactiva.");

            var restaurant = _restaurantRepository.GetById(category.RestaurantId);
            if (restaurant == null)
                throw new Exception("Restaurante asociado no encontrado.");

            if (restaurant.UserId != userId)
                throw new Exception("No tenés permisos para crear productos en este restaurante.");

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
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;

            ValidateProductOwnership(userId,product);

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
        public void IncreasePrices(int restaurantId, int userId, decimal percentage)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);
            if (restaurant == null)
            {
                throw new KeyNotFoundException("No existe el restaurante.");
            }
            if (restaurant.UserId != userId)
            {
                throw new UnauthorizedAccessException("No tienes permiso para modificar este restaurante.");
            }
            var productos = _productRepository.GetByRestaurantId(restaurantId);
            if (productos.Any() == false)
            {
                throw new Exception("El restaurante no tiene productos cargados.");
            }

            var factor = 1 + (percentage / 100);

            foreach (var product in productos)
            {
                product.Price = product.Price * factor;
                _productRepository.Update(product);
            }
            _productRepository.SaveChanges();
        }

        public ProductImportResultDto ImportFromCsv(int userId, int restaurantId, Stream csvStream)
        {
            if (csvStream == null)
                throw new ArgumentNullException(nameof(csvStream));

            // 1) Validar restaurante y dueño
            var restaurant = _restaurantRepository.GetById(restaurantId);
            if (restaurant == null)
                throw new Exception("Restaurante no encontrado.");

            if (restaurant.UserId != userId)
                throw new Exception("No tenés permisos para importar datos en este restaurante.");

            var result = new ProductImportResultDto();

            using var reader = new StreamReader(csvStream);

            // 2) Leer encabezado (y descartarlo)
            var headerLine = reader.ReadLine();
            // Podrías validar acá si querés que tenga exactamente CategoryName,...

            // 3) Traer categorías existentes
            var categories = _categoryRepository.GetByRestaurantId(restaurantId).ToList();

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                result.TotalRows++;

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var columns = line.Split(',');

                if (columns.Length < 4)
                {
                    result.Errors.Add($"Fila {result.TotalRows}: columnas insuficientes.");
                    continue;
                }

                var categoryName = columns[0].Trim();
                var productName = columns[1].Trim();
                var description = columns[2].Trim();
                var priceString = columns[3].Trim();
                var isAvailable = true;

                if (columns.Length >= 5)
                {
                    bool.TryParse(columns[4].Trim(), out isAvailable);
                }

                if (string.IsNullOrWhiteSpace(categoryName) ||
                    string.IsNullOrWhiteSpace(productName) ||
                    string.IsNullOrWhiteSpace(priceString))
                {
                    result.Errors.Add($"Fila {result.TotalRows}: datos obligatorios vacíos.");
                    continue;
                }

                // ✅ Parseo simple del precio
                if (!decimal.TryParse(priceString, out var price))
                {
                    result.Errors.Add($"Fila {result.TotalRows}: precio inválido '{priceString}'.");
                    continue;
                }

                // 4) Buscar o crear categoría
                var category = categories
                    .FirstOrDefault(c => c.Name.ToLower() == categoryName.ToLower());

                if (category == null)
                {
                    category = new Category
                    {
                        Name = categoryName,
                        RestaurantId = restaurantId
                    };

                    _categoryRepository.Add(category);

                    //Guardamos ya  para que se genere el Id
                    _categoryRepository.SaveChanges();

                    // Ahora category.Id ya tiene el valor real de la DB
                    categories.Add(category);
                    result.CreatedCategories++;
                }


                var product = new Product
                {
                    Name = productName,
                    Description = description,
                    Price = price,
                    IsAvailable = isAvailable,
                    DiscountPercentage = null,
                    IsHappyHour = false,
                    HappyHourStart = null,
                    HappyHourEnd = null,
                    IsFavorite = false,
                    CategoryId = category.Id   // ahora existe en la DB
                };

                _productRepository.Add(product);

                result.ImportedProducts++;
            }

            var saved = _productRepository.SaveChanges();
            if (saved == 0)
                throw new Exception("No se pudieron guardar los cambios de la importación.");

            return result;
        }


    }

}
