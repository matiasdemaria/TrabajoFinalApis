using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Model.Dto.Category;
using TrabajoFinalApis.Model.Dto.Category.Response;
using TrabajoFinalApis.Model.Dto.Restaurant.Request;
using TrabajoFinalApis.Model.Dto.Restaurant.Response;
using TrabajoFinalApis.Service.Interface;

namespace TrabajoFinalApis.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // ----------- INVITADO -----------

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<ICollection<RestaurantResponseDto>> GetAll()
        {
            return Ok(_restaurantService.GetAll());
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public ActionResult<RestaurantResponseDto> GetById(int id)
        {
            var restaurant = _restaurantService.GetById(id);
            return restaurant == null ? NotFound() : Ok(restaurant);
        }

        [HttpGet("{id:int}/menu")]
        [AllowAnonymous]
        public ActionResult<ICollection<CategoryWithProductsResponseDto>> GetMenu(int id)
        {
            return Ok(_restaurantService.GetMenu(id));
        }

        // ----------- DUEÑO -----------

        [HttpGet("mine")]
        [Authorize]
        public ActionResult<ICollection<RestaurantResponseDto>> GetMyRestaurants()
        {
            var userId = GetUserIdFromToken();
            return Ok(_restaurantService.GetAllByUser(userId));
        }

        [HttpPost]
        [Authorize]
        public ActionResult<RestaurantResponseDto> Create([FromBody] RestaurantCreateRequestDto dto)
        {
            var userId = GetUserIdFromToken();
            var restaurant = _restaurantService.Create(userId, dto);
            return Ok(restaurant);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public ActionResult<RestaurantResponseDto> Update(int id, [FromBody] RestaurantUpdateRequestDto dto)
        {
            var userId = GetUserIdFromToken();
            return Ok(_restaurantService.Update(userId, id, dto));
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public IActionResult Remove(int id)
        {
            var userId = GetUserIdFromToken();
            _restaurantService.Remove(userId, id);
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
