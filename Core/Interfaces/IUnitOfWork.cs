using Core.Entities.BankEntity;
using Core.Entities.BillingCycleEntity;
using Core.Entities.CardEntity;
using Core.Entities.CategoryEntity;
using Core.Entities.CountryEntity;
using Core.Entities.CurrencyEntity;
using Core.Entities.LanguageEntity;
using Core.Entities.SubscriptionEntity;
using Core.Entities.TransactionEntity;
using Core.Entities.UserEntity;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Service> ServiceRepository { get; }
        IRepository<ServiceCategory> ServiceCategoryRepository { get; }
        IRepository<ServiceSubCategory> ServiceSubCategoryRepository { get; }
        IRepository<SubscriptionsSearch> SubscriptionsSearchRepository { get; }
        IRepository<Subscription> SubscriptionRepository { get; }
        IRepository<Transaction> TransactionRepository { get; }
        IRepository<Bank> BankRepository { get; }
        IRepository<UserBank> UserBankRepository { get; }
        IRepository<Currency> CurrencyRepository { get; }
        IRepository<BillingCycle> BillingCycleRepository { get; }
        IRepository<Language> LanguageRepository { get; }
        IRepository<Country> CountryRepository { get; }
        IRepository<Card> CardRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
