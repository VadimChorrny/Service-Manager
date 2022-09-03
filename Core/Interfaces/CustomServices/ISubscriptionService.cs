using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.Monobank;
using Core.DTOs.Subscriptions;

namespace Core.Interfaces.CustomServices
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<AccountMonobankDTO>> GetMonobankAccounts(string token);
        Task<SubscriptionResponseDTO> GetAllSubscriptionsFromMonobank(string token, AccountMonobankDTO accountMonobank , DateTime fromTime);
        Task RegisterSubscriptionsFromAccountsMonobank(IEnumerable<AccountMonobankDTO> accountsMonobank, string token, DateTime? fromDate, string userId);
        Task<IEnumerable<SubscriptionResponseDTO>> GetSubscriptions(string userId);
    }
}
