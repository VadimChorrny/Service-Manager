using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Google
{
    public class GoogleUserRequest
    {
        public const string PROVIDER = "google";
        [JsonProperty("idToken")]
        [Required]
        public string IdToken { get; set; }
    }
}
