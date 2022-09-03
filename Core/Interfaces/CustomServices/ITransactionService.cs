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
        Task<TransactionDTO> GetAllTransactions(); // { get; set; }
        Task<TransactionDTO> GetTransactionById(string transactionId);
        Task<bool> AddTransactionsFromExcel(string path);
    }
}
