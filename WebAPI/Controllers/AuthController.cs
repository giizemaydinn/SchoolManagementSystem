using Business.Abstract;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var result = await _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        //{
        //    var userExists = await _authService.UserExists(userForRegisterDto.Email);
        //    if (!userExists.Success)
        //    {
        //        return BadRequest(userExists.Message);
        //    }

        //    var registerResult = await _authService.Register(userForRegisterDto);
        //    var result = await _authService.CreateAccessToken(registerResult.Data);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }

        //    return BadRequest(result.Message);
        //}

    }
}
