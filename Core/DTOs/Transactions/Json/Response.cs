using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.DTOs.Transactions.Json
{
    public class Response
    {
        [JsonProperty("@version")]
        public string Version { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
