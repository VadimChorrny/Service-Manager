using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.DTOs.Transactions.Json
{
    public class Statements
    {
        [JsonProperty("@status")]
        public string Status { get; set; }
        [JsonProperty("@credit")]
        public string Credit { get; set; }
        [JsonProperty("@debet")]
        public string Debet { get; set; }
        [JsonProperty("statement")] public Statement[] Statement { get; set; }
    }
}
