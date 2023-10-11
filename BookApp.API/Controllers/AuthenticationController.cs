using BookApp.Application.DTO;
using BookApp.Application.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO model)
        {
            return ReturnResponse(await _authService.Register(model));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            return ReturnResponse(await _authService.Login(model));
        }


        [HttpPost]
        [Route("RefreshToken")]

        public async Task<IActionResult> RefreshToken(RefreshTokenDTO tokenRequest)
        {
          return ReturnResponse( await _authService.VerifyRefreshToken(tokenRequest));
        }
    }
}
