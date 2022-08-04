using Core.Entities;
using Core.Entities.BankEntity;
using Core.Entities.BillingCycleEntity;
using Core.Entities.CardEntity;
using Core.Entities.CategoryEntity;
using Core.Entities.CountryEntity;
using Core.Entities.CurrencyEntity;
using Core.Entities.LanguageEntity;
using Core.Entities.OtherEntities;
using Core.Entities.SubscriptionEntity;
using Core.Entities.TransactionEntity;
using Core.Entities.UserEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BillingCycle> BillingCycles { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryTranslate> CountryTranslates { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<DateFormat> DateFormats { get; set; }
        public DbSet<Labels> Labels { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<RemindMe> RemindMes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Synchronization> Synchronizations { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionList> SubscriptionLists { get; set; }
        public DbSet<SubscriptionsSearch> SubscriptionsSearches { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserBank> UserBanks { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
