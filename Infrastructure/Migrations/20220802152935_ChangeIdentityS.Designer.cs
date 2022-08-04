﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220802152935_ChangeIdentityS")]
    partial class ChangeIdentityS
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Entities.BankEntity.Bank", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BankId"), 1L, 1);

                    b.Property<int?>("CounterUser")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("InstructionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Links")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinksAPI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BankId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Core.Entities.BillingCycleEntity.BillingCycle", b =>
                {
                    b.Property<int>("BilLingCycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BilLingCycleId"), 1L, 1);

                    b.Property<int?>("LangId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BilLingCycleId");

                    b.ToTable("BillingCycles");
                });

            modelBuilder.Entity("Core.Entities.CardEntity.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardId"), 1L, 1);

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserBankId")
                        .HasColumnType("int");

                    b.HasKey("CardId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Core.Entities.CategoryEntity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<int?>("LangId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Core.Entities.CountryEntity.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Core.Entities.CountryEntity.CountryTranslate", b =>
                {
                    b.Property<int>("CountryTranslateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryTranslateId"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LangId")
                        .HasColumnType("int");

                    b.HasKey("CountryTranslateId");

                    b.ToTable("CountryTranslates");
                });

            modelBuilder.Entity("Core.Entities.CurrencyEntity.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CurrencyId"), 1L, 1);

                    b.Property<int>("CountUser")
                        .HasColumnType("int");

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Core.Entities.LanguageEntity.Language", b =>
                {
                    b.Property<int?>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("LanguageId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmallName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Core.Entities.OtherEntities.DateFormat", b =>
                {
                    b.Property<int>("DateFormatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DateFormatId"), 1L, 1);

                    b.Property<string>("DateFormatName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DateFormatId");

                    b.ToTable("DateFormats");
                });

            modelBuilder.Entity("Core.Entities.OtherEntities.Labels", b =>
                {
                    b.Property<int>("LabelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LabelId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LabelId");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("Core.Entities.OtherEntities.Membership", b =>
                {
                    b.Property<int>("MembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembershipId"), 1L, 1);

                    b.Property<int?>("LangId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sum")
                        .HasColumnType("int");

                    b.HasKey("MembershipId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("Core.Entities.OtherEntities.RemindMe", b =>
                {
                    b.Property<int>("RemindMeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RemindMeId"), 1L, 1);

                    b.Property<int?>("LangId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RemindMeId");

                    b.ToTable("RemindMes");
                });

            modelBuilder.Entity("Core.Entities.OtherEntities.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"), 1L, 1);

                    b.Property<int?>("LangId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Core.Entities.OtherEntities.Synchronization", b =>
                {
                    b.Property<int>("SynchronizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SynchronizationId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("LangId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SynchronizationId");

                    b.ToTable("Synchronizations");
                });

            modelBuilder.Entity("Core.Entities.SubscriptionEntity.Subcategory", b =>
                {
                    b.Property<int>("SubcategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubcategoryId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("LangId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubcategoryId");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("Core.Entities.SubscriptionEntity.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionId"), 1L, 1);

                    b.Property<int?>("BillingCycleId")
                        .HasColumnType("int");

                    b.Property<int?>("LabelId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RemindMeId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("SubscriptionsListId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Core.Entities.SubscriptionEntity.SubscriptionList", b =>
                {
                    b.Property<int>("SubscriptionListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionListId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("CountUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubcategoryId")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionListId");

                    b.ToTable("SubscriptionLists");
                });

            modelBuilder.Entity("Core.Entities.SubscriptionEntity.SubscriptionsSearch", b =>
                {
                    b.Property<int>("SubscriptionSearchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionSearchId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubscriptionsListId")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionSearchId");

                    b.ToTable("SubscriptionsSearches");
                });

            modelBuilder.Entity("Core.Entities.TransactionEntity.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<string>("Card")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CardId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<float?>("Sum")
                        .HasColumnType("real");

                    b.HasKey("TransactionId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Core.Entities.UserEntity.UserBank", b =>
                {
                    b.Property<int>("UserBankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserBankId"), 1L, 1);

                    b.Property<int?>("BankId")
                        .HasColumnType("int");

                    b.Property<int?>("SynchronizationId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserBankId");

                    b.ToTable("UserBanks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Core.Entities.UserEntity.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("BanksBankId")
                        .HasColumnType("int");

                    b.Property<int?>("ConnectedBanks")
                        .HasColumnType("int");

                    b.Property<int?>("CountriesCountryId")
                        .HasColumnType("int");

                    b.Property<int?>("CreateSubscriptions")
                        .HasColumnType("int");

                    b.Property<int?>("CurrenciesCurrencyId")
                        .HasColumnType("int");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("LanguagesLanguageId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastActivityDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Notification")
                        .HasColumnType("bit");

                    b.Property<int?>("PayExperience")
                        .HasColumnType("int");

                    b.Property<int?>("Payments")
                        .HasColumnType("int");

                    b.Property<int?>("PremiumMembership")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RegistrationDay")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("RoundNumbersToIntegers")
                        .HasColumnType("bit");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("BanksBankId");

                    b.HasIndex("CountriesCountryId");

                    b.HasIndex("CurrenciesCurrencyId");

                    b.HasIndex("LanguagesLanguageId");

                    b.HasIndex("StatusId");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Core.Entities.TransactionEntity.Transaction", b =>
                {
                    b.HasOne("Core.Entities.CurrencyEntity.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.UserEntity.User", b =>
                {
                    b.HasOne("Core.Entities.BankEntity.Bank", "Banks")
                        .WithMany()
                        .HasForeignKey("BanksBankId");

                    b.HasOne("Core.Entities.CountryEntity.Country", "Countries")
                        .WithMany()
                        .HasForeignKey("CountriesCountryId");

                    b.HasOne("Core.Entities.CurrencyEntity.Currency", "Currencies")
                        .WithMany()
                        .HasForeignKey("CurrenciesCurrencyId");

                    b.HasOne("Core.Entities.LanguageEntity.Language", "Languages")
                        .WithMany()
                        .HasForeignKey("LanguagesLanguageId");

                    b.HasOne("Core.Entities.OtherEntities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Banks");

                    b.Navigation("Countries");

                    b.Navigation("Currencies");

                    b.Navigation("Languages");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
