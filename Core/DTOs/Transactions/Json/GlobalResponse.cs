using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.DTOs.Transactions.Json
{
    public class GlobalResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
}
