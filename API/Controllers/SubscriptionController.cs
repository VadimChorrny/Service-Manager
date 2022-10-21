using Core.DTOs.Monobank;
using Core.Interfaces.CustomServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet("get-monobank-accounts")]
        public async Task<IActionResult> GetMonobankAccounts(string token)
        {
            return Ok(await _subscriptionService.GetMonobankAccounts(token));
        }

        [HttpPost("register-transaction-from-accounts-monobank")]
        public async Task<IActionResult> RegisterTransactionsFromAccountsMonobank(IEnumerable<AccountMonobankDTO> monobankAccounts, string token, string userId, DateTime? from)
        {
            await _subscriptionService.RegisterSubscriptionsFromAccountsMonobank(monobankAccounts, token, from, userId);
            return Ok();
        }

        [HttpGet("calculate-subscriptions")]
        public async Task<IActionResult> CalculateSubscriptions(string userId)
        {
            return Ok(await _subscriptionService.CalculateSubscriptions(userId));
        }

        [HttpGet("get-subscriptions-by-user-id")]
        public async Task<IActionResult> GetSubscriptionsByUserId(string userId)
        {
            return Ok(await _subscriptionService.GetSubscriptionsByUser(userId));
        }
    }
}
