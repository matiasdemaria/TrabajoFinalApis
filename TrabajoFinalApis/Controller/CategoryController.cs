using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Model.Dto.Category;
using TrabajoFinalApis.Model.Dto.Category.Request;
using TrabajoFinalApis.Model.Dto.Category.Response;
using TrabajoFinalApis.Model.Dto.Product.Request;
using TrabajoFinalApis.Service.Interface;

namespace TrabajoFinalApis.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService,IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        // INVITADO
        [HttpGet("restaurant/{restaurantId:int}")]
        [AllowAnonymous]
        public ActionResult<ICollection<CategoryResponseDto>> GetByRestaurant(int restaurantId)
        {
            return Ok(_categoryService.GetByRestaurant(restaurantId));
        }

        // DUEÑO
        [HttpPost("categories/{restaurantId:int}")]
        [Authorize]
        public IActionResult Create(int restaurantId, CategoryCreateRequestDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!); //Obtiene el id del usuario desde el token
            var created = _categoryService.Create(restaurantId,userId,dto);
            return Ok(created);
        }


        [HttpPut("{id:int}")]
        [Authorize]
        public ActionResult<CategoryResponseDto> Update(int id, [FromBody] CategoryUpdateRequestDto dto)
        {
            var userId = GetUserIdFromToken();
            return Ok(_categoryService.Update(id, userId ,dto));
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public IActionResult Remove(int id)
        {
            var userId = GetUserIdFromToken();
            _categoryService.Remove(id,userId);
            return NoContent();
        }

        private int GetUserIdFromToken()
        {
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(sub);
        }
    }
}
