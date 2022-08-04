using Core.DTOs.Google;
using Core.DTOs.UserDTO;
using Core.Interfaces.CustomInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        } // I love u

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDTO data)
        {
            await _accountService.RegisterAsync(data);
            return Ok("Successfully created new user!");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDTO data)
        {
            var tokens = await _accountService.LoginAsync(data.Email, data.Password);
            return Ok(tokens);
        }

        [AllowAnonymous]
        [HttpPost("google-authenticate")]
        public async Task<IActionResult> GoogleAuthenticate([FromBody] GoogleUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(it => it.Errors).Select(it => it.ErrorMessage));
            var user = await _accountService.AuthenticateGoogleUserAsync(request);
            return Ok(await _accountService.GenerateTokens(user));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] AuthenticationDTO userTokensDTO)
        {
            var tokens = await _accountService.RefreshTokenAsync(userTokensDTO);
            return Ok(tokens);
        }
    }
}
