using GBS.Services.AuthApi.Models.DTO;
using GBS.Services.AuthApi.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GBS.Services.AuthApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private ResponseDto _response;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            _response = new ResponseDto();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterUserDto registerUserDto)
        {
            var response = await _authService.Register(registerUserDto);
            if (!string.IsNullOrEmpty(response))
            {
                _response.IsSuccess = false;
                _response.Message = response;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginUserDto loginUserDto)
        {
            var response = await _authService.Login(loginUserDto);
            if(response.UserDetails == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or Pssword is Incorrect";
                return BadRequest(_response);
            }
            _response.Result = response;
            return Ok(_response);
        }
    }
}
