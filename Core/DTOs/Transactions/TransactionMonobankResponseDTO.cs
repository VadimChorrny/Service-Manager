using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Transactions
{
    public class TransactionMonobankResponseDTO
    {
        public string Id { get; set; }
        public int Time { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}
