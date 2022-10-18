using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomServices
{
    public interface IUserBankService
    {
        Task RegisterPrivat(string userId, string merchantId, string password, string cardNumber);
    }
}
