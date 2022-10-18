using Core.Interfaces.CustomServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBankController : ControllerBase
    {
        private readonly IUserBankService _userBankService;

        public UserBankController(IUserBankService userBankService)
        {
            _userBankService = userBankService;
        }
        [Authorize]
        [HttpPost("register-privat")]
        public async Task<IActionResult> RegisterPrivatBank(string merchantId, string password, string cardNumber)
        {
            await _userBankService.RegisterPrivat(User.Claims.FirstOrDefault().Value, merchantId ,password, cardNumber);
            return Ok();
        }
    }
}
