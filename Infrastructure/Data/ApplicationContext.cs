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
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        //private readonly UserManager<IdentityUser> _userManager;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //_userManager = userManager;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasIndex(u => u.CurrencyCode).IsUnique();

            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Ukraine" }, 
                new Country { Id = 2, Name = "USA" }, 
                new Country { Id = 3, Name = "Poland" });
            modelBuilder.Entity<BillingCycle>().HasData(
                new BillingCycle { Id = 1, Name = "Monthly" },
                new BillingCycle { Id = 2, Name = "Yearly" },
                new BillingCycle { Id = 3, Name = "Half-Yearly"}
                );

            modelBuilder.Entity<Bank>().HasIndex(b => b.Name).IsUnique();
            modelBuilder.Entity<Bank>().HasData(
                new Bank { Id = 1, Name = "Monobank", CountryId = 1, Links = "www.monobank.ua", LinksAPI = "https://api.monobank.ua/docs/" },
                new Bank { CountryId = 1, Id = 2, Name = "PrivatBank", Links = "https://privatbank.ua/", LinksAPI = "https://api.privatbank.ua/" },
                new Bank { Id = 3, Name = "UKRSIBBANK", CountryId = 1, Links = "https://ukrsibbank.com", LinksAPI = "" }, 
                new Bank { Id = 4, CountryId = 2, Name = "Chase", Links = "www.chase.com", LinksAPI = "https://www.chase.com/digital/data-sharing" }, 
                new Bank { Id = 5, Name = "Wells Fargo Bank", CountryId = 2, Links = "http://www.wellsfargo.com", LinksAPI = "https://developer.wellsfargo.com/" });
            //modelBuilder.Entity<User>().HasData(new User{ CountryId = 1, });

            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, CurrencyCode = "980", Name = "Ukrainian Hryvnia", ShortName = "UAH", LettersSign = "₴" },
                new Currency { Id = 2, CurrencyCode = "978", Name = "Euro",  ShortName = "UAH", LettersSign = "€" },
                new Currency { Id = 3, CurrencyCode = "840", Name= "US Dollar", ShortName = "USD", LettersSign= "$" },
                new Currency { Id = 4, CurrencyCode = "826", Name = "British pound", ShortName = "GBP", LettersSign= "£" },
                new Currency{ Id = 5, CurrencyCode = "124", Name = "Canadian Dollar", ShortName = "CAD", LettersSign = "$" },
                new Currency {Id = 6, CurrencyCode = "036", Name = "Australian Dollar", ShortName= "AUD", LettersSign = "$" },
                new Currency { Id = 7, CurrencyCode = "756", Name = "Swiss Franc", ShortName = "CHF", LettersSign = "CHF" },
                new Currency{ Id = 8, CurrencyCode = "484", Name = "Mexican Peso", ShortName = "MXN", LettersSign = "$" },
                new Currency{ Id = 9, CurrencyCode = "356", Name = "Indian Ruble", ShortName = "INR", LettersSign = "₹"},
                new Currency { Id = 10, CurrencyCode = "956",Name = "Brazilian Real", ShortName = "BRL", LettersSign = "R$"},
                new Currency { Id = 11, CurrencyCode = "208",Name= "Danish Krone", ShortName = "DKK", LettersSign = "kr." },
                new Currency { Id = 12, CurrencyCode = "752", Name = "Swedish Krona", ShortName = "SEK", LettersSign = "kr" },
                new Currency{ Id = 13, CurrencyCode = "578", Name = "Norwegian Krone", ShortName = "NOK", LettersSign = "kr" },
                new Currency{ Id = 14, CurrencyCode = "191", Name = "Croatian Kuna", ShortName = "HRK", LettersSign = "kn" },
                new Currency{Id = 15, CurrencyCode = "554", Name = "New Zealand Dollar", ShortName = "NZD", LettersSign = "$" },
                new Currency{Id = 16, CurrencyCode = "203", Name = "Czech Koruna", ShortName = "CZK", LettersSign = "Kč" },
                new Currency{Id = 17, CurrencyCode = "392", Name = "Japanese Yen", ShortName = "JPY", LettersSign = "¥" },
                new Currency{Id = 18, CurrencyCode = "985", Name = "Polish Zloty", ShortName = "PLN", LettersSign = "zł" },
                new Currency{Id = 19, CurrencyCode = "946", Name = "Romanian Leu", ShortName = "RON", LettersSign = "L" },
                new Currency { Id = 20, CurrencyCode = "764", Name= "Thai Baht", ShortName = "THB", LettersSign = "฿" },
                new Currency{ Id = 21, CurrencyCode="784", Name = "United Arab Emirates Dirham", ShortName = "AED", LettersSign = "د.إ" },
                new Currency{Id = 22, CurrencyCode = "344", Name = "Hong Kong Dollar", ShortName = "HKD", LettersSign = "$" },
                new Currency{Id = 23, CurrencyCode = "348", Name = "Hungarian Forint", ShortName = "HUF", LettersSign = "Ft"},
                new Currency { Id = 24, CurrencyCode = "376", Name = "Israeli New Sheqel", ShortName="ILS", LettersSign = "₪" },
                new Currency{Id=25, CurrencyCode = "702", Name = "Singapore Dollar", ShortName = "SGD", LettersSign = "$" },
                new Currency{ Id = 26, CurrencyCode = "949", Name = "Turkish Lira", ShortName= "TRY", LettersSign = "₺" },
                new Currency{ Id = 27, CurrencyCode = "710", Name = "South African Rand", ShortName = "ZAR", LettersSign = "R" },
                new Currency { Id = 28, CurrencyCode = "975", Name = "Bulgarian Lev", ShortName = "BGN", LettersSign= "lv." }
                );
            modelBuilder.Entity<UserBank>().HasOne<User>(ub => ub.User).WithMany(u => u.Banks)
                .HasForeignKey(ub => ub.UserId);
            modelBuilder.Entity<UserBank>().HasOne<Bank>(ub => ub.Bank).WithMany(b => b.UserBanks).HasForeignKey(ub => ub.BankId);
            //modelBuilder.Entity<Subscription>().HasOne<User>(s => s.User).WithMany(u => u.Subscriptions).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Transaction>().HasOne<Card>(t => t.Card).WithMany(c => c.Transactions).HasForeignKey(t => t.CardId);
            //modelBuilder.Entity
            //modelBuilder.Entity<Card>().On
            //ApplicationDbInitializer.SeedUsers(_userManager);
            new RoleConfiguration().Configure(modelBuilder.Entity<IdentityRole>());
            new AdminConfiguration().Configure(modelBuilder.Entity<User>());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BillingCycle> BillingCycles { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<ServiceCategory> Categories { get; set; }
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
        public DbSet<ServiceSubCategory> Subcategories { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SubscriptionsSearch> SubscriptionsSearches { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserBank> UserBanks { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
