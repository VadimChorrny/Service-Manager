using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.DTOs.Transactions.Json
{
    public class Data
    {
        [JsonProperty("oper")]
        public string Oper { get; set; }
        [JsonProperty("info")] public Info Info { get; set; }
    }
}
