using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.DTOs.Transactions.Json
{
    public class Info
    {
        [JsonProperty("statements")]
        public Statements Statements { get; set; }
    }
}
