using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.DTOs.Monobank
{
    public class AccountMonobankDTO
    {
        public string Id { get; set; }
        public string CurrencyCode { get; set; }
        [JsonProperty("maskedPan")]
        public string[] CardNumber { get; set; }
    }
}
