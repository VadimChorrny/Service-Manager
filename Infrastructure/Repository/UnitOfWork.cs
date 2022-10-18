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
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        // INITIAL DATABASE
        private ApplicationContext _context;
        // INITIAL REPOSITORIES
        private IRepository<User> _userRepository;
        private IRepository<Service> _serviceRepository;
        private IRepository<ServiceCategory> _serviceCategoryRepository;
        private IRepository<ServiceSubCategory> _serviceSubCategoryRepository;
        private IRepository<SubscriptionsSearch> _subscriptionsSearchRepository;
        private IRepository<Subscription> _subscriptionRepository;
        private IRepository<Transaction> _transactionRepository;
        private IRepository<Bank> _bankRepository;
        private IRepository<UserBank> _userBankRepository;
        private IRepository<Currency> _currencyRepository;
        private IRepository<BillingCycle> _billingCycleRepository;
        private IRepository<Language> _languageRepository;
        private IRepository<Country> _countryRepository;
        private IRepository<Card> _cardRepository;
        public UnitOfWork(ApplicationContext context) { _context = context; } // CTOR
        // GET FOR REPOSITORY
        public IRepository<Card> CardRepository
        {
            get
            {
                if (_cardRepository == null)
                    _cardRepository = new Repository<Card>(_context);
                return _cardRepository;
            }
        }
        public IRepository<BillingCycle> BillingCycleRepository
        {
            get
            {
                if (_billingCycleRepository == null)
                    _billingCycleRepository = new Repository<BillingCycle>(_context);
                return _billingCycleRepository;
            }
        }
        public IRepository<Country> CountryRepository
        {
            get
            {
                if (_countryRepository == null)
                    _countryRepository = new Repository<Country>(_context);
                return _countryRepository;
            }
        }
        public IRepository<Language> LanguageRepository
        {
            get
            {
                if (_languageRepository == null)
                    _languageRepository = new Repository<Language>(_context);
                return _languageRepository;
            }
        }
        public IRepository<Bank> BankRepository
        {
            get
            {
                if (_bankRepository == null)
                    _bankRepository = new Repository<Bank>(_context);
                return _bankRepository;
            }
        }
        public IRepository<Currency> CurrencyRepository
        {
            get
            {
                if (_currencyRepository == null)
                    _currencyRepository = new Repository<Currency>(_context);
                return _currencyRepository;
            }
        }
        public IRepository<Transaction> TransactionRepository
        {
            get
            {
                if (_transactionRepository == null)
                    _transactionRepository = new Repository<Transaction>(_context);
                return _transactionRepository;
            }
        }
        public IRepository<UserBank> UserBankRepository
        {
            get
            {
                if (_userBankRepository == null)
                    _userBankRepository = new Repository<UserBank>(_context);
                return _userBankRepository;
            }
        }
        public IRepository<Subscription> SubscriptionRepository
        {
            get
            {
                if (_subscriptionRepository == null)
                    _subscriptionRepository = new Repository<Subscription>(_context);
                return _subscriptionRepository;
            }
        }
        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new Repository<User>(_context);
                return _userRepository;
            }
        }
        public IRepository<SubscriptionsSearch> SubscriptionsSearchRepository
        {
            get
            {
                if (_subscriptionsSearchRepository == null)
                    _subscriptionsSearchRepository = new Repository<SubscriptionsSearch>(_context);
                return _subscriptionsSearchRepository;
            }
        }
        public IRepository<Service> ServiceRepository
        {
            get
            {
                if (_serviceRepository == null)
                    _serviceRepository = new Repository<Service>(_context);
                return _serviceRepository;
            }
        }
        public IRepository<ServiceCategory> ServiceCategoryRepository
        {
            get
            {
                if (_serviceCategoryRepository == null)
                    _serviceCategoryRepository = new Repository<ServiceCategory>(_context);
                return _serviceCategoryRepository;
            }
        }
        public IRepository<ServiceSubCategory> ServiceSubCategoryRepository
        {
            get
            {
                if (_serviceSubCategoryRepository == null)
                    _serviceSubCategoryRepository = new Repository<ServiceSubCategory>(_context);
                return _serviceSubCategoryRepository;
            }
        }
        // REALISE Save();
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
        // DISPOSING
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();
                this._disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
