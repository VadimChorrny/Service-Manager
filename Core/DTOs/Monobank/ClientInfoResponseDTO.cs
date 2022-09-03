using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.DTOs.Monobank
{
    public class ClientInfoResponseDTO
    {
        [JsonProperty("clientId")]
        public int Id { get; set; }
    }
}
