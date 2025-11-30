using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoFinalApis.Model.Dto.User.Request;
using TrabajoFinalApis.Model.Dto.User.Response;
using TrabajoFinalApis.Service.Interface;

namespace TrabajoFinalApis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // todos los endpoints de este controller requieren JWT
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user/me
        [HttpGet("me")]
        public ActionResult<UserResponseDto> GetMyProfile()
        {
            var userId = GetUserIdFromToken();
            var user = _userService.GetById(userId);
            return Ok(user);
        }

        // PUT: api/user/me
        [HttpPatch("me")]
        public ActionResult<UserResponseDto> UpdateMyProfile([FromBody] UserUpdateRequestDto dto)
        {
            var userId = GetUserIdFromToken();
            var updated = _userService.Update(userId, dto);
            return Ok(updated);
        }

        // PUT: api/user/me/password
        [HttpPatch("me/password")]
        public IActionResult ChangePassword([FromBody] UserChangePasswordRequestDto dto)
        {
            var userId = GetUserIdFromToken();
            _userService.ChangePassword(userId, dto);
            return NoContent();
        }

        // DELETE: api/user/me
        [HttpDelete("me")]
        public IActionResult RemoveMyAccount()
        {
            var userId = GetUserIdFromToken();
            _userService.Remove(userId);
            return NoContent();
        }

        private int GetUserIdFromToken()
        {
            // Primero intentamos con el 'sub' del JWT, si no, con NameIdentifier
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(sub!);
        }
    }
}
