using Microsoft.AspNetCore.Mvc;
using TrabajoFinalApis.Model.Dto.User.Request;
using TrabajoFinalApis.Model.Dto.User.Response;
using TrabajoFinalApis.Service.Interface;

namespace TrabajoFinalApis.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/authentication/register
        [HttpPost("register")]
        public ActionResult<UserResponseDto> Register([FromBody] UserCreateRequestDto dto)
        {
            var user = _userService.Register(dto);
            return Ok(user);
        }

        // POST: api/authentication/login
        [HttpPost("login")]
        public ActionResult<AuthResponseDto> Login([FromBody] UserLoginRequestDto dto)
        {
            var auth = _userService.Login(dto);
            return Ok(auth);
        }
    }
}
