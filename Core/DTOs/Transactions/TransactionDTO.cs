using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.DTOs.Transactions
{
    public class TransactionDTO
    {
        [JsonProperty("to")]
        public DateTime? CreatedDate { get; set; }
        //public string CategoryTitle { get; set; }
        //public string Payee { get; set; }
        //public string Card { get; set; }
        public string Description { get; set; }
        public float Sum { get; set; }
    }
}
