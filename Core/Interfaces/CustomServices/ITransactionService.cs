using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.Transactions;

namespace Core.Interfaces.CustomServices
{
    public interface ITransactionService
    {
        Task<List<TransactionsSuccessResponseDTO>> RegisterTransactionsPrivat(string userId, DateTime from, DateTime to);
        Task<IEnumerable<TransactionDTO>> GetAllTransactionsBySubscription(Guid id);
        Task<TransactionDTO> GetTransactionById(string transactionId);
        Task<bool> AddTransactionsFromExcel(string path);
    }
}
