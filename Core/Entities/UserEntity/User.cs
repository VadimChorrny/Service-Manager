using Core.Entities.BankEntity;
using Core.Entities.CurrencyEntity;
using Core.Entities.Enums;
using Core.Entities.LanguageEntity;
using Core.Entities.OtherEntities;
using Core.Entities.CountryEntity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.UserEntity
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime RegistrationDay { get; set; }
        public DateTime LastActivityDay { get; set; }
        [ForeignKey("Language")]
        public int LangId { get; set; }
        public Language Languages { get; set; }
        public int ConnectedBanks { get; set; }
        public int CreateSubscriptions { get; set; }
        public bool Notification { get; set; }
        public bool RoundNumbersToIntegers { get; set; }
        [ForeignKey("Bank")]
        public int? BankId { get; set; }
        public Bank Banks { get; set; }
        public Gender Gender { get; set; }
        [ForeignKey("Status")]
        public int? StatusId { get; set; }
        public Status Status { get; set; }
        public Payment Payments { get; set; }
        public PremiumMembership PremiumMembership { get; set; }
        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public Country Countries { get; set; }
        [ForeignKey("Currency")]
        public int? CurrencyId { get; set; }
        public Currency Currencies { get; set; }
        public PayExperience PayExperience { get; set; } // enum
    }
}
