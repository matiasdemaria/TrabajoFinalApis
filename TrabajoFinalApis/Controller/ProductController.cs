using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoFinalApis.Model.Dto.Product.Request;
using TrabajoFinalApis.Model.Dto.Product.Response;
using TrabajoFinalApis.Service.Interface;

namespace TrabajoFinalApis.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRestaurantService _restaurantService;

        public ProductController(IProductService productService, IRestaurantService restaurantService)
        {
            _productService = productService;
            _restaurantService = restaurantService;
        }

        // -------- INVITADO --------

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public ActionResult<ProductResponseDto> GetById(int id)
        {
            var product = _productService.GetById(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpGet("restaurant/{restaurantId:int}")]
        [AllowAnonymous]
        public ActionResult<ICollection<ProductResponseDto>> GetByRestaurant(int restaurantId)
        {
            return Ok(_productService.GetByRestaurant(restaurantId));
        }

        [HttpGet("restaurant/{restaurantId:int}/category/{categoryId:int}")]
        [AllowAnonymous]
        public ActionResult<ICollection<ProductResponseDto>> GetByCategory(int restaurantId, int categoryId)
        {
            return Ok(_productService.GetByCategory(restaurantId, categoryId));
        }

        [HttpGet("restaurant/{restaurantId:int}/favorites")]
        [AllowAnonymous]
        public ActionResult<ICollection<ProductResponseDto>> GetFavorites(int restaurantId)
        {
            return Ok(_productService.GetFavorites(restaurantId));
        }

        [HttpGet("restaurant/{restaurantId:int}/discounted")]
        [AllowAnonymous]
        public ActionResult<ICollection<ProductResponseDto>> GetDiscounted(int restaurantId)
        {
            return Ok(_productService.GetDiscounted(restaurantId));
        }

        [HttpGet("restaurant/{restaurantId:int}/happyhour")]
        [AllowAnonymous]
        public ActionResult<ICollection<ProductResponseDto>> GetHappyHour(int restaurantId)
        {
            return Ok(_productService.GetHappyHour(restaurantId));
        }

        // -------- DUEÑO --------
        [HttpPost("categories/{categoryId:int}")]
        [Authorize]
        public IActionResult Create(int categoryId, [FromBody] ProductCreateRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var created = _productService.Create(categoryId, userId, dto);
            return Ok(created);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public ActionResult<ProductResponseDto> Update(int id, [FromBody] ProductUpdateRequestDto dto)
        {
            var userId = GetUserIdFromToken();
            return Ok(_productService.Update(userId, id, dto));
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public IActionResult Remove(int id)
        {
            var userId = GetUserIdFromToken();
            _productService.Remove(userId, id);
            return NoContent();
        }

        [HttpPut("{id:int}/discount")]
        [Authorize]
        public ActionResult<ProductResponseDto> UpdateDiscount(int id, [FromBody] ProductDiscountUpdateRequestDto dto)
        {
            var userId = GetUserIdFromToken();
            return Ok(_productService.UpdateDiscount(userId, id, dto));
        }


        [HttpPut("increase-prices/{restaurantId:int}")]
        [Authorize]
        public IActionResult IncreasePrices(int restaurantId, [FromBody] ProductPriceIncreaseRequestDto dto)
        {
            
                var userId = GetUserIdFromToken();

                _productService.IncreasePrices(restaurantId, userId, dto.percentage);

                return Ok(new { message = $"Precios aumentados un {dto.percentage}% exitosamente." });
            
        }

        [HttpPut("{id:int}/favorite")]
        [Authorize]
        public ActionResult<ProductResponseDto> UpdateFavorite(int id, [FromBody] ProductFavoriteUpdateRequestDto dto)
        {
            var userId = GetUserIdFromToken();
            return Ok(_productService.UpdateFavorite(userId, id, dto));
        }

        [HttpPut("{id:int}/happyhour")]
        [Authorize]
        public ActionResult<ProductResponseDto> UpdateHappyHour(int id, [FromBody] ProductHappyHourUpdateRequestDto dto)
        {
            var userId = GetUserIdFromToken();
            return Ok(_productService.UpdateHappyHour(userId, id, dto));
        }

        private int GetUserIdFromToken()
        {
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(sub);
        }

        [HttpPost("import-csv")]
        [Authorize]
        [Consumes("multipart/form-data")]
        public ActionResult<ProductImportResultDto> ImportCsv([FromForm] ProductCsvImportRequestDto form)
        {
            if (form.File == null || form.File.Length == 0)
                return BadRequest("Debe subir un archivo CSV.");

            var userId = GetUserIdFromToken();
            using var stream = form.File.OpenReadStream();

            var result = _productService.ImportFromCsv(
                userId,
                form.RestaurantId,
                stream
            );

            return Ok(result);
        }


    }
}
