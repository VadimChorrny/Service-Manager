using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.DTOs.Transactions.Json
{
    public class Statement
    {
        [JsonProperty("@card")]
        public string Card { get; set; }
        [JsonProperty("@cardamount")]
        public string Amount { get; set; }
        [JsonProperty("@description")]
        public string Description { get; set; }
        [JsonProperty("@appcode")]
        public string AppCode { get; set; }
        [JsonProperty("@trandate")]
        public DateTime TranDate { get; set; }
        
    }
}
