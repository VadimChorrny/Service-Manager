using Core.Entities.BankEntity;
using Core.Entities.CurrencyEntity;
using Core.Entities.Enums;
using Core.Entities.LanguageEntity;
using Core.Entities.OtherEntities;
using Core.Entities.CountryEntity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.CardEntity;
using Core.Entities.SubscriptionEntity;
using Core.Entities.TransactionEntity;

namespace Core.Entities.UserEntity
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public DateTime RegistrationDay { get; set; } = DateTime.Now;
        public DateTime LastActivityDay { get; set; } = DateTime.Now;

        [ForeignKey("Language")]
        public Guid? LangId { get; set; }
        public virtual Language Language { get; set; }
        //public int ConnectedBanks { get; set; }
        //public int CreateSubscriptions { get; set; } // Don`t know
        public bool Notification { get; set; } = true;

        public bool RoundNumbersToIntegers { get; set; } = false;
        //[ForeignKey("Bank")]
        //public Guid? BankId { get; set; }
        //public virtual Bank Banks { get; set; } // Incorrect o
        public virtual Gender Gender { get; set; }
        [ForeignKey("Status")]
        public Guid? StatusId { get; set; }
        public virtual Status Status { get; set; }
        //public virtual Payment Payments { get; set; }
        public virtual PremiumMembership PremiumMembership { get; set; }
        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; } // Incorrect maybe
        //Main Currency
        [ForeignKey("Currency")]
        public int? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; } // Main currency of User
        public virtual ICollection<UserBank> Banks { get; set; } = new HashSet<UserBank>();
        //public virtual ICollection<Card> Cards { get; set; } //= new HashSet<Card>();
        //public virtual ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
        //public virtual ICollection<Subscription> Subscriptions { get; set; } = new HashSet<Subscription>();
        public virtual PayExperience PayExperience { get; set; } // enum
    }
}
