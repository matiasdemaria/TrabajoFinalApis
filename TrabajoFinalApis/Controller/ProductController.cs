using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoFinalApis.Entities;
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

        public ProductController(IProductService productService)
        {
            _productService = productService;
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
    }
}
