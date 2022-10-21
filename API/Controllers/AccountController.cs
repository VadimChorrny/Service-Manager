using Core.DTOs.EmailDTO;
using Core.DTOs.Google;
using Core.DTOs.UserDTO;
using Core.Interfaces.CustomInterfaces;
using Core.Interfaces.CustomServices;
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
        private readonly IEmailService _emailService;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger, IEmailService emailService)
        {
            _accountService = accountService;
            _logger = logger;
            _emailService = emailService;
        } // I love u
        [Authorize]
        [HttpPost("edit-profile")]
        public IActionResult EditProfile()
        {
            return Ok();
        }
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                return Ok(await _accountService.GetUserProfile(User.Claims.FirstOrDefault().Value));
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    invalid = ex.Message
                });
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDTO data)
        {
            var callbackUrl = Request.GetTypedHeaders().Referer.ToString();
            await _accountService.RegisterAsync(data, callbackUrl);
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
        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync(EmailConfirmationTokenRequestDTO request)
        {
            await _emailService.ConfirmEmailAsync(request);
            return Ok();
        }
        #region Password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var callbackUrl = Request.GetTypedHeaders().Referer.ToString();
            await _emailService.SendResetPasswordEmailAsync(resetPasswordDTO, callbackUrl);
            return Ok();
        }
        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO model)
        {
            await _accountService.ChangePassword(model);
            return Ok();
        }
        #endregion
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] UserLogoutDTO userLogoutDTO)
        {
            await _accountService.LogoutAsync(userLogoutDTO);
            return Ok();
        }
    }
}
