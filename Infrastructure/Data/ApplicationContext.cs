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
        //private readonly _userManager<IdentityUser> _userManager;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //_userManager = userManager;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasIndex(u => u.CurrencyCode).IsUnique();

            modelBuilder.Entity<Language>().HasData(
                new Language{ Id = Guid.Parse("6d13646d-700f-444c-8fbf-aa540f08700d"), Name = "English", SmallName = "EN" },
                new Language{ Id = Guid.Parse("0ea31b65-13ab-474d-bd52-3c79e8fea7ce"), Name = "Ukrainian", SmallName = "UA" }
                );
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<PhoneCode>().HasData(
                new PhoneCode{Id = 1, CountryId = 1, Code = "380"},
                new PhoneCode{Id = 2, CountryId = 2, Code = "45"},
                new PhoneCode{Id = 3, CountryId = 3, Code = "47"},
                new PhoneCode{Id = 4, CountryId = 4, Code = "41"},
                new PhoneCode{Id = 5, CountryId = 5, Code = "46"},
                new PhoneCode{Id = 6, CountryId = 6, Code = "358"},
                new PhoneCode{Id = 7, CountryId = 7, Code = "31"},
                new PhoneCode{Id = 8, CountryId = 8, Code = "64"},
                new PhoneCode{Id = 9, CountryId = 9, Code = "49"},
                new PhoneCode{Id = 10, CountryId = 10, Code = "352"},
                new PhoneCode{Id = 11, CountryId = 11, Code = "354"},
                new PhoneCode{Id = 12, CountryId = 12, Code = "44"},
                new PhoneCode{Id = 13, CountryId = 13, Code = "353"},
                new PhoneCode{Id = 14, CountryId = 14, Code = "43"},
                new PhoneCode{Id = 15, CountryId = 15, Code = "1"},
                new PhoneCode{Id = 16, CountryId = 16, Code = "852"},
                new PhoneCode{Id = 17, CountryId = 17, Code = "65"},
                new PhoneCode{Id = 18, CountryId = 18, Code = "61"},
                new PhoneCode{Id = 19, CountryId = 19, Code = "1"},
                new PhoneCode{Id = 20, CountryId = 20, Code = "81"},
                new PhoneCode{Id = 21, CountryId = 21, Code = "356"},
                new PhoneCode{Id = 22, CountryId = 22, Code = "372"},
                new PhoneCode{Id = 23, CountryId = 23, Code = "32"},
                new PhoneCode{Id = 24, CountryId = 24, Code = "33"},
                new PhoneCode{Id = 25, CountryId = 25, Code = "886"},
                new PhoneCode{Id = 26, CountryId = 26, Code = "34"},
                new PhoneCode{Id = 27, CountryId = 27, Code = "351"},
                new PhoneCode{Id = 28, CountryId = 28, Code = "386"},
                new PhoneCode{Id = 29, CountryId = 29, Code = "420"},
                new PhoneCode{Id = 30, CountryId = 30, Code = "82"},
                new PhoneCode{Id = 31, CountryId = 31, Code = "39"},
                new PhoneCode{Id = 32, CountryId = 32, Code = "972"},
                new PhoneCode{Id = 33, CountryId = 33, Code = "421"},
                new PhoneCode{Id = 34, CountryId = 34, Code = "370"},
                new PhoneCode{Id = 35, CountryId = 35, Code = "357"},
                new PhoneCode{Id = 36, CountryId = 36, Code = "371"},
                new PhoneCode{Id = 37, CountryId = 37, Code = "48"},
                new PhoneCode{Id = 38, CountryId = 38, Code = "56"},
                new PhoneCode{Id = 39, CountryId = 39, Code = "506"},
                new PhoneCode{Id = 40, CountryId = 40, Code = "598"},
                new PhoneCode{Id = 41, CountryId = 41, Code = "971"},
                new PhoneCode{Id = 42, CountryId = 42, Code = "60"},
                new PhoneCode{Id = 43, CountryId = 43, Code = "30"},
                new PhoneCode{Id = 44, CountryId = 44, Code = "974"},
                new PhoneCode{Id = 45, CountryId = 45, Code = "230"},
                new PhoneCode{Id = 46, CountryId = 46, Code = "385"},
                new PhoneCode{Id = 47, CountryId = 47, Code = "36"},
                new PhoneCode{Id = 48, CountryId = 48, Code = "40"},
                new PhoneCode{Id = 49, CountryId = 49, Code = "248"},
                new PhoneCode{Id = 50, CountryId = 50, Code = "359"},
                new PhoneCode{Id = 51, CountryId = 51, Code = "382"},
                new PhoneCode{Id = 52, CountryId = 52, Code = "507"},
                new PhoneCode{Id = 53, CountryId = 53, Code = "381"},
                new PhoneCode{Id = 54, CountryId = 54, Code = "995"},
                new PhoneCode{Id = 55, CountryId = 55, Code = "1-868"},
                new PhoneCode{Id = 56, CountryId = 56, Code = "51"},
                new PhoneCode{Id = 57, CountryId = 57, Code = "86"},
                new PhoneCode{Id = 58, CountryId = 58, Code = "973"},
                new PhoneCode{Id = 59, CountryId = 59, Code = "54"},
                new PhoneCode{Id = 60, CountryId = 60, Code = "968"},
                new PhoneCode{Id = 61, CountryId = 61, Code = "374"},
                new PhoneCode{Id = 62, CountryId = 62, Code = "965"},
                new PhoneCode{Id = 63, CountryId = 63, Code = "62"},
                new PhoneCode{Id = 64, CountryId = 64, Code = "1-876"},
                new PhoneCode{Id = 65, CountryId = 65, Code = "355"},
                new PhoneCode{Id = 66, CountryId = 66, Code = "66"},
                new PhoneCode{Id = 67, CountryId = 67, Code = "52"},
                new PhoneCode{Id = 68, CountryId = 68, Code = "7"},
                new PhoneCode{Id = 69, CountryId = 69, Code = "55"},
                new PhoneCode{Id = 70, CountryId = 70, Code = "387"},
                new PhoneCode{Id = 71, CountryId = 71, Code = "966"},
                new PhoneCode{Id = 72, CountryId = 72, Code = "57"},
                new PhoneCode{Id = 73, CountryId = 73, Code = "94"},
                new PhoneCode{Id = 74, CountryId = 74, Code = "267"},
                new PhoneCode{Id = 75, CountryId = 75, Code = "238"},
                new PhoneCode{Id = 76, CountryId = 76, Code = "1-809"},
                new PhoneCode{Id = 77, CountryId = 76, Code = "1-829"},
                new PhoneCode{Id = 78, CountryId = 76, Code = "1-849"},
                new PhoneCode{Id = 79, CountryId = 77, Code = "595"},
                new PhoneCode{Id = 80, CountryId = 78, Code = "593"},
                new PhoneCode{Id = 81, CountryId = 79, Code = "373"},
                new PhoneCode{Id = 82, CountryId = 80, Code = "597"},
                new PhoneCode{Id = 83, CountryId = 81, Code = "27"},
                new PhoneCode{Id = 84, CountryId = 82, Code = "63"},
                new PhoneCode{Id = 85, CountryId = 83, Code = "84"},
                new PhoneCode{Id = 86, CountryId = 84, Code = "962"},
                new PhoneCode{Id = 87, CountryId = 85, Code = "264"},
                new PhoneCode{Id = 88, CountryId = 86, Code = "592"},
                new PhoneCode{Id = 89, CountryId = 87, Code = "90"},
                new PhoneCode{Id = 90, CountryId = 88, Code = "994"},
                new PhoneCode{Id = 91, CountryId = 89, Code = "501"},
                new PhoneCode{Id = 92, CountryId = 90, Code = "217"}
            );
            #region Country
            modelBuilder.Entity<Country>().HasData(
                new Country {Id = 1, Name = "Ukraine"},
                new Country {Id = 2, Name = "Denmark"},
                new Country {Id = 3, Name = "Norway"},
                new Country {Id = 4, Name = "Switzerland"},
                new Country {Id = 5, Name = "Sweden"},
                new Country {Id = 6, Name = "Finland"},
                new Country {Id = 7, Name = "Netherlands"},
                new Country {Id = 8, Name = "New Zealand"},
                new Country {Id = 9, Name = "Germany"},
                new Country {Id = 10, Name = "Luxembourg"},
                new Country {Id = 11, Name = "Iceland"},
                new Country {Id = 12, Name = "United Kingdom"},
                new Country {Id = 13, Name = "Ireland"},
                new Country {Id = 14, Name = "Austria"},
                new Country {Id = 15, Name = "Canada"},
                new Country {Id = 16, Name = "Hong Kong"},
                new Country {Id = 17, Name = "Singapore"},
                new Country {Id = 18, Name = "Australia"},
                new Country {Id = 19, Name = "United States"},
                new Country {Id = 20, Name = "Japan"},
                new Country {Id = 21, Name = "Malta"},
                new Country {Id = 22, Name = "Estonia"},
                new Country {Id = 23, Name = "Belgium"},
                new Country {Id = 24, Name = "France"},
                new Country {Id = 25, Name = "Taiwan"},
                new Country {Id = 26, Name = "Spain"},
                new Country {Id = 27, Name = "Portugal"},
                new Country {Id = 28, Name = "Slovenia"},
                new Country {Id = 29, Name = "Czech Republic"},
                new Country {Id = 30, Name = "South Korea"},
                new Country {Id = 31, Name = "Italy"},
                new Country {Id = 32, Name = "Israel"},
                new Country {Id = 33, Name = "Slovakia"},
                new Country {Id = 34, Name = "Lithuania"},
                new Country {Id = 35, Name = "Cyprus"},
                new Country {Id = 36, Name = "Latvia"},
                new Country {Id = 37, Name = "Poland"},
                new Country {Id = 38, Name = "Chile"},
                new Country {Id = 39, Name = "Costa Rica"},
                new Country {Id = 40, Name = "Uruguay"},
                new Country {Id = 41, Name = "United Arab Emirates"},
                new Country {Id = 42, Name = "Malaysia"},
                new Country {Id = 43, Name = "Greece"},
                new Country {Id = 44, Name = "Qatar"},
                new Country {Id = 45, Name = "Mauritius"},
                new Country {Id = 46, Name = "Croatia"},
                new Country {Id = 47, Name = "Hungary"},
                new Country {Id = 48, Name = "Romania"},
                new Country {Id = 49, Name = "Seychelles"},
                new Country {Id = 50, Name = "Bulgaria"},
                new Country {Id = 51, Name = "Montenegro"},
                new Country {Id = 52, Name = "Panama"},
                new Country {Id = 53, Name = "Serbia"},
                new Country {Id = 54, Name = "Georgia"},
                new Country {Id = 55, Name = "Trinidad And Tobago"},
                new Country {Id = 56, Name = "Peru"},
                new Country {Id = 57, Name = "China"},
                new Country {Id = 58, Name = "Bahrain"},
                new Country {Id = 59, Name = "Argentina"},
                new Country {Id = 60, Name = "Oman"},
                new Country {Id = 61, Name = "Armenia"},
                new Country {Id = 62, Name = "Kuwait"},
                new Country {Id = 63, Name = "Indonesia"},
                new Country {Id = 64, Name = "Jamaica"},
                new Country {Id = 65, Name = "Albania"},
                new Country {Id = 66, Name = "Thailand"},
                new Country {Id = 67, Name = "Mexico"},
                new Country {Id = 68, Name = "Kazakhstan"},
                new Country {Id = 69, Name = "Brazil"},
                new Country {Id = 70, Name = "Bosnia And Herzegovina"},
                new Country {Id = 71, Name = "Saudi Arabia"},
                new Country {Id = 72, Name = "Colombia"},
                new Country {Id = 73, Name = "Sri Lanka"},
                new Country {Id = 74, Name = "Botswana"},
                new Country {Id = 75, Name = "Cape Verde"},
                new Country {Id = 76, Name = "Dominican Republic"},
                new Country {Id = 77, Name = "Paraguay"},
                new Country {Id = 78, Name = "Ecuador"},
                new Country {Id = 79, Name = "Moldova"},
                new Country {Id = 80, Name = "Suriname"},
                new Country {Id = 81, Name = "South Africa"},
                new Country {Id = 82, Name = "Philippines"},
                new Country {Id = 83, Name = "Vietnam"},
                new Country {Id = 84, Name = "Jordan"},
                new Country {Id = 85, Name = "Namibia"},
                new Country {Id = 86, Name = "Guyana"},
                new Country {Id = 87, Name = "Turkey"},
                new Country {Id = 88, Name = "Azerbaijan"},
                new Country {Id = 89, Name = "Belize"},
                new Country {Id = 90, Name = "Tunisia"});
#endregion
            modelBuilder.Entity<BillingCycle>().HasData(
                new BillingCycle { Id = 1, Name = "Monthly" },
                new BillingCycle { Id = 2, Name = "Yearly" },
                new BillingCycle { Id = 3, Name = "Half-Yearly" },
                new BillingCycle { Id = 4, Name = "Weekly" },
                new BillingCycle { Id = 5, Name = "Quartaly" },
                new BillingCycle { Id = 6, Name = "Tap to fix" }
                );
            #region Banks
            modelBuilder.Entity<Bank>().HasIndex(b => b.Name).IsUnique();
            modelBuilder.Entity<Bank>().HasData(
                new Bank { Id = (int)Core.DTOs.Constants.Bank.MONOBANK, Name = "Monobank", CountryId = 1, Links = "www.monobank.ua", LinksApi = "https://api.monobank.ua/docs/" },
                new Bank { CountryId = 1, Id = (int)Core.DTOs.Constants.Bank.PRIVATBANK, Name = "PrivatBank", Links = "https://privatbank.ua/", LinksApi = "https://api.privatbank.ua/" },
                new Bank { Id = (int)Core.DTOs.Constants.Bank.UKRSIBBANK, Name = "UKRSIBBANK", CountryId = 1, Links = "https://ukrsibbank.com", LinksApi = "" },
                new Bank { Id = (int)Core.DTOs.Constants.Bank.CHASE, CountryId = 2, Name = "Chase", Links = "www.chase.com", LinksApi = "https://www.chase.com/digital/data-sharing" },
                new Bank { Id = (int)Core.DTOs.Constants.Bank.WELLS_FARGO_BANK, Name = "Wells Fargo Bank", CountryId = 2, Links = "http://www.wellsfargo.com", LinksApi = "https://developer.wellsfargo.com/" });
            //modelBuilder.Entity<User>().HasData(new User{ CountryId = 1, });
            #endregion
            #region Currencies
            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, CurrencyCode = "980", Name = "Ukrainian Hryvnia", ShortName = "UAH", LettersSign = "₴" },
                new Currency { Id = 2, CurrencyCode = "978", Name = "Euro", ShortName = "UAH", LettersSign = "€" },
                new Currency { Id = 3, CurrencyCode = "840", Name = "US Dollar", ShortName = "USD", LettersSign = "$" },
                new Currency { Id = 4, CurrencyCode = "826", Name = "British pound", ShortName = "GBP", LettersSign = "£" },
                new Currency { Id = 5, CurrencyCode = "124", Name = "Canadian Dollar", ShortName = "CAD", LettersSign = "$" },
                new Currency { Id = 6, CurrencyCode = "036", Name = "Australian Dollar", ShortName = "AUD", LettersSign = "$" },
                new Currency { Id = 7, CurrencyCode = "756", Name = "Swiss Franc", ShortName = "CHF", LettersSign = "CHF" },
                new Currency { Id = 8, CurrencyCode = "484", Name = "Mexican Peso", ShortName = "MXN", LettersSign = "$" },
                new Currency { Id = 9, CurrencyCode = "356", Name = "Indian Ruble", ShortName = "INR", LettersSign = "₹" },
                new Currency { Id = 10, CurrencyCode = "956", Name = "Brazilian Real", ShortName = "BRL", LettersSign = "R$" },
                new Currency { Id = 11, CurrencyCode = "208", Name = "Danish Krone", ShortName = "DKK", LettersSign = "kr." },
                new Currency { Id = 12, CurrencyCode = "752", Name = "Swedish Krona", ShortName = "SEK", LettersSign = "kr" },
                new Currency { Id = 13, CurrencyCode = "578", Name = "Norwegian Krone", ShortName = "NOK", LettersSign = "kr" },
                new Currency { Id = 14, CurrencyCode = "191", Name = "Croatian Kuna", ShortName = "HRK", LettersSign = "kn" },
                new Currency { Id = 15, CurrencyCode = "554", Name = "New Zealand Dollar", ShortName = "NZD", LettersSign = "$" },
                new Currency { Id = 16, CurrencyCode = "203", Name = "Czech Koruna", ShortName = "CZK", LettersSign = "Kč" },
                new Currency { Id = 17, CurrencyCode = "392", Name = "Japanese Yen", ShortName = "JPY", LettersSign = "¥" },
                new Currency { Id = 18, CurrencyCode = "985", Name = "Polish Zloty", ShortName = "PLN", LettersSign = "zł" },
                new Currency { Id = 19, CurrencyCode = "946", Name = "Romanian Leu", ShortName = "RON", LettersSign = "L" },
                new Currency { Id = 20, CurrencyCode = "764", Name = "Thai Baht", ShortName = "THB", LettersSign = "฿" },
                new Currency { Id = 21, CurrencyCode = "784", Name = "United Arab Emirates Dirham", ShortName = "AED", LettersSign = "د.إ" },
                new Currency { Id = 22, CurrencyCode = "344", Name = "Hong Kong Dollar", ShortName = "HKD", LettersSign = "$" },
                new Currency { Id = 23, CurrencyCode = "348", Name = "Hungarian Forint", ShortName = "HUF", LettersSign = "Ft" },
                new Currency { Id = 24, CurrencyCode = "376", Name = "Israeli New Sheqel", ShortName = "ILS", LettersSign = "₪" },
                new Currency { Id = 25, CurrencyCode = "702", Name = "Singapore Dollar", ShortName = "SGD", LettersSign = "$" },
                new Currency { Id = 26, CurrencyCode = "949", Name = "Turkish Lira", ShortName = "TRY", LettersSign = "₺" },
                new Currency { Id = 27, CurrencyCode = "710", Name = "South African Rand", ShortName = "ZAR", LettersSign = "R" },
                new Currency { Id = 28, CurrencyCode = "975", Name = "Bulgarian Lev", ShortName = "BGN", LettersSign = "lv." }
                );
            #endregion
            modelBuilder.Entity<UserBank>().HasOne<User>(ub => ub.User).WithMany(u => u.Banks)
                .HasForeignKey(ub => ub.UserId);
            modelBuilder.Entity<UserBank>().HasOne<Bank>(ub => ub.Bank).WithMany(b => b.UserBanks).HasForeignKey(ub => ub.BankId);
            //modelBuilder.Entity<Subscription>().HasOne<User>(s => s.User).WithMany(u => u.Subscriptions).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Transaction>().HasOne<Card>(t => t.Card).WithMany(c => c.Transactions).HasForeignKey(t => t.CardId);
            modelBuilder.Entity<Transaction>().HasOne <Subscription>(t => t.Subscription).WithMany(s => s.Transactions).HasForeignKey(t => t.SubscriptionId).OnDelete(DeleteBehavior.SetNull);
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
        public DbSet<PhoneCode> PhoneCodes { get; set; }
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
