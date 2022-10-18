using Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.UserDTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDay { get; set; }
        public DateTime LastActivityDay { get; set; }
        public int? LangId { get; set; }
        public int ConnectedBanks { get; set; }
        public bool Notification { get; set; }
        public bool RoundNumbersToIntegers { get; set; }
        public Gender Gender { get; set; }
        public int? StatusId { get; set; }
        public Payment Payments { get; set; }
        public PremiumMembership PremiumMembership { get; set; }
        public int? CountryId { get; set; }
        public int? CurrencyId { get; set; }
        public PayExperience PayExperience { get; set; } // enum
    }
}
