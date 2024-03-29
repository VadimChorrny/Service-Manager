﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryTranslates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTranslates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LettersSign = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateFormats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFormatName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmallName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RemindMes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemindMes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Synchronizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Synchronizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Links = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinksApi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhoneCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneCodes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingCycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingCycles_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    RegistrationDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActivityDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notification = table.Column<bool>(type: "bit", nullable: false),
                    RoundNumbersToIntegers = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PremiumMembership = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    PayExperience = table.Column<int>(type: "int", nullable: false),
                    ConfirmationEmailToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationEmailTokenExpirationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceSubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Categories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Subcategories_ServiceSubCategoryId",
                        column: x => x.ServiceSubCategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserBanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    SynchronizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBanks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserBanks_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tariff = table.Column<float>(type: "real", nullable: true),
                    BillingCycleId = table.Column<int>(type: "int", nullable: false),
                    RemindMeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subscriptions_BillingCycles_BillingCycleId",
                        column: x => x.BillingCycleId,
                        principalTable: "BillingCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Subscriptions_RemindMes_RemindMeId",
                        column: x => x.RemindMeId,
                        principalTable: "RemindMes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subscriptions_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionsSearches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionsSearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionsSearches_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserBankId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_UserBanks_UserBankId",
                        column: x => x.UserBankId,
                        principalTable: "UserBanks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SearchPhone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionsSearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchPhone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchPhone_SubscriptionsSearches_SubscriptionsSearchId",
                        column: x => x.SubscriptionsSearchId,
                        principalTable: "SubscriptionsSearches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionFromBankId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sum = table.Column<float>(type: "real", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "9e5e69ae-7b33-4f1c-9063-d70f9d9688e7", "Administrator", "ADMINISTRATOR" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "1e12d04f-fd57-4de3-89a0-6a24cfdfa6cd", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "ConfirmationEmailToken", "ConfirmationEmailTokenExpirationDate", "CountryId", "CurrencyId", "Email", "EmailConfirmed", "Gender", "LangId", "LastActivityDay", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Notification", "PasswordHash", "PayExperience", "PhoneNumber", "PhoneNumberConfirmed", "PremiumMembership", "RegistrationDay", "RoundNumbersToIntegers", "SecurityStamp", "StatusId", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "B22698B8-42A2-4115-9631-1C2D1E2AC5F7", 0, null, "86894b93-b00d-4ef7-9867-c757084cd56c", null, null, null, null, "Admin@Admin.com", true, 0, null, new DateTime(2022, 10, 21, 14, 49, 15, 61, DateTimeKind.Local).AddTicks(2083), false, null, null, "ADMIN@ADMIN.COM", "MASTERADMIN", true, "AQAAAAEAACcQAAAAEDhrBsvVTh4Tl+UiJGBpnub/q57qyr0spvyWlCtXdOgVT7F8yK0qFwOJQZBZGrkN1Q==", 0, "XXXXXXXXXXXXX", true, 0, new DateTime(2022, 10, 21, 14, 49, 15, 61, DateTimeKind.Local).AddTicks(2053), false, "00000000-0000-0000-0000-000000000000", null, null, false, "masteradmin" });

            migrationBuilder.InsertData(
                table: "BillingCycles",
                columns: new[] { "Id", "LangId", "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Monthly" },
                    { 2, null, null, "Yearly" },
                    { 3, null, null, "Half-Yearly" },
                    { 4, null, null, "Weekly" },
                    { 5, null, null, "Quartaly" },
                    { 6, null, null, "Tap to fix" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Flag", "Name" },
                values: new object[,]
                {
                    { 1, null, "Ukraine" },
                    { 2, null, "Denmark" },
                    { 3, null, "Norway" },
                    { 4, null, "Switzerland" },
                    { 5, null, "Sweden" },
                    { 6, null, "Finland" },
                    { 7, null, "Netherlands" },
                    { 8, null, "New Zealand" },
                    { 9, null, "Germany" },
                    { 10, null, "Luxembourg" },
                    { 11, null, "Iceland" },
                    { 12, null, "United Kingdom" },
                    { 13, null, "Ireland" },
                    { 14, null, "Austria" },
                    { 15, null, "Canada" },
                    { 16, null, "Hong Kong" },
                    { 17, null, "Singapore" },
                    { 18, null, "Australia" },
                    { 19, null, "United States" },
                    { 20, null, "Japan" },
                    { 21, null, "Malta" },
                    { 22, null, "Estonia" },
                    { 23, null, "Belgium" },
                    { 24, null, "France" },
                    { 25, null, "Taiwan" },
                    { 26, null, "Spain" },
                    { 27, null, "Portugal" },
                    { 28, null, "Slovenia" },
                    { 29, null, "Czech Republic" },
                    { 30, null, "South Korea" },
                    { 31, null, "Italy" },
                    { 32, null, "Israel" },
                    { 33, null, "Slovakia" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Flag", "Name" },
                values: new object[,]
                {
                    { 34, null, "Lithuania" },
                    { 35, null, "Cyprus" },
                    { 36, null, "Latvia" },
                    { 37, null, "Poland" },
                    { 38, null, "Chile" },
                    { 39, null, "Costa Rica" },
                    { 40, null, "Uruguay" },
                    { 41, null, "United Arab Emirates" },
                    { 42, null, "Malaysia" },
                    { 43, null, "Greece" },
                    { 44, null, "Qatar" },
                    { 45, null, "Mauritius" },
                    { 46, null, "Croatia" },
                    { 47, null, "Hungary" },
                    { 48, null, "Romania" },
                    { 49, null, "Seychelles" },
                    { 50, null, "Bulgaria" },
                    { 51, null, "Montenegro" },
                    { 52, null, "Panama" },
                    { 53, null, "Serbia" },
                    { 54, null, "Georgia" },
                    { 55, null, "Trinidad And Tobago" },
                    { 56, null, "Peru" },
                    { 57, null, "China" },
                    { 58, null, "Bahrain" },
                    { 59, null, "Argentina" },
                    { 60, null, "Oman" },
                    { 61, null, "Armenia" },
                    { 62, null, "Kuwait" },
                    { 63, null, "Indonesia" },
                    { 64, null, "Jamaica" },
                    { 65, null, "Albania" },
                    { 66, null, "Thailand" },
                    { 67, null, "Mexico" },
                    { 68, null, "Kazakhstan" },
                    { 69, null, "Brazil" },
                    { 70, null, "Bosnia And Herzegovina" },
                    { 71, null, "Saudi Arabia" },
                    { 72, null, "Colombia" },
                    { 73, null, "Sri Lanka" },
                    { 74, null, "Botswana" },
                    { 75, null, "Cape Verde" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Flag", "Name" },
                values: new object[,]
                {
                    { 76, null, "Dominican Republic" },
                    { 77, null, "Paraguay" },
                    { 78, null, "Ecuador" },
                    { 79, null, "Moldova" },
                    { 80, null, "Suriname" },
                    { 81, null, "South Africa" },
                    { 82, null, "Philippines" },
                    { 83, null, "Vietnam" },
                    { 84, null, "Jordan" },
                    { 85, null, "Namibia" },
                    { 86, null, "Guyana" },
                    { 87, null, "Turkey" },
                    { 88, null, "Azerbaijan" },
                    { 89, null, "Belize" },
                    { 90, null, "Tunisia" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyCode", "Flag", "LettersSign", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "980", null, "₴", "Ukrainian Hryvnia", "UAH" },
                    { 2, "978", null, "€", "Euro", "UAH" },
                    { 3, "840", null, "$", "US Dollar", "USD" },
                    { 4, "826", null, "£", "British pound", "GBP" },
                    { 5, "124", null, "$", "Canadian Dollar", "CAD" },
                    { 6, "036", null, "$", "Australian Dollar", "AUD" },
                    { 7, "756", null, "CHF", "Swiss Franc", "CHF" },
                    { 8, "484", null, "$", "Mexican Peso", "MXN" },
                    { 9, "356", null, "₹", "Indian Ruble", "INR" },
                    { 10, "956", null, "R$", "Brazilian Real", "BRL" },
                    { 11, "208", null, "kr.", "Danish Krone", "DKK" },
                    { 12, "752", null, "kr", "Swedish Krona", "SEK" },
                    { 13, "578", null, "kr", "Norwegian Krone", "NOK" },
                    { 14, "191", null, "kn", "Croatian Kuna", "HRK" },
                    { 15, "554", null, "$", "New Zealand Dollar", "NZD" },
                    { 16, "203", null, "Kč", "Czech Koruna", "CZK" },
                    { 17, "392", null, "¥", "Japanese Yen", "JPY" },
                    { 18, "985", null, "zł", "Polish Zloty", "PLN" },
                    { 19, "946", null, "L", "Romanian Leu", "RON" },
                    { 20, "764", null, "฿", "Thai Baht", "THB" },
                    { 21, "784", null, "د.إ", "United Arab Emirates Dirham", "AED" },
                    { 22, "344", null, "$", "Hong Kong Dollar", "HKD" },
                    { 23, "348", null, "Ft", "Hungarian Forint", "HUF" },
                    { 24, "376", null, "₪", "Israeli New Sheqel", "ILS" },
                    { 25, "702", null, "$", "Singapore Dollar", "SGD" },
                    { 26, "949", null, "₺", "Turkish Lira", "TRY" },
                    { 27, "710", null, "R", "South African Rand", "ZAR" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyCode", "Flag", "LettersSign", "Name", "ShortName" },
                values: new object[] { 28, "975", null, "lv.", "Bulgarian Lev", "BGN" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SmallName" },
                values: new object[] { new Guid("0ea31b65-13ab-474d-bd52-3c79e8fea7ce"), "Ukrainian", "UA" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SmallName" },
                values: new object[] { new Guid("6d13646d-700f-444c-8fbf-aa540f08700d"), "English", "EN" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2301D884-221A-4E7D-B509-0113DCC043E1", "B22698B8-42A2-4115-9631-1C2D1E2AC5F7" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "CountryId", "InstructionDescription", "InstructionTitle", "Links", "LinksApi", "Logo", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, null, "www.monobank.ua", "https://api.monobank.ua/docs/", null, "Monobank" },
                    { 2, 1, null, null, "https://privatbank.ua/", "https://api.privatbank.ua/", null, "PrivatBank" },
                    { 3, 1, null, null, "https://ukrsibbank.com", "", null, "UKRSIBBANK" },
                    { 4, 2, null, null, "www.chase.com", "https://www.chase.com/digital/data-sharing", null, "Chase" },
                    { 5, 2, null, null, "http://www.wellsfargo.com", "https://developer.wellsfargo.com/", null, "Wells Fargo Bank" }
                });

            migrationBuilder.InsertData(
                table: "PhoneCodes",
                columns: new[] { "Id", "Code", "CountryId" },
                values: new object[,]
                {
                    { 1, "380", 1 },
                    { 2, "45", 2 },
                    { 3, "47", 3 },
                    { 4, "41", 4 },
                    { 5, "46", 5 },
                    { 6, "358", 6 },
                    { 7, "31", 7 },
                    { 8, "64", 8 },
                    { 9, "49", 9 },
                    { 10, "352", 10 },
                    { 11, "354", 11 },
                    { 12, "44", 12 },
                    { 13, "353", 13 },
                    { 14, "43", 14 },
                    { 15, "1", 15 },
                    { 16, "852", 16 },
                    { 17, "65", 17 },
                    { 18, "61", 18 },
                    { 19, "1", 19 },
                    { 20, "81", 20 },
                    { 21, "356", 21 },
                    { 22, "372", 22 },
                    { 23, "32", 23 },
                    { 24, "33", 24 },
                    { 25, "886", 25 },
                    { 26, "34", 26 },
                    { 27, "351", 27 },
                    { 28, "386", 28 },
                    { 29, "420", 29 },
                    { 30, "82", 30 },
                    { 31, "39", 31 },
                    { 32, "972", 32 },
                    { 33, "421", 33 },
                    { 34, "370", 34 },
                    { 35, "357", 35 },
                    { 36, "371", 36 }
                });

            migrationBuilder.InsertData(
                table: "PhoneCodes",
                columns: new[] { "Id", "Code", "CountryId" },
                values: new object[,]
                {
                    { 37, "48", 37 },
                    { 38, "56", 38 },
                    { 39, "506", 39 },
                    { 40, "598", 40 },
                    { 41, "971", 41 },
                    { 42, "60", 42 },
                    { 43, "30", 43 },
                    { 44, "974", 44 },
                    { 45, "230", 45 },
                    { 46, "385", 46 },
                    { 47, "36", 47 },
                    { 48, "40", 48 },
                    { 49, "248", 49 },
                    { 50, "359", 50 },
                    { 51, "382", 51 },
                    { 52, "507", 52 },
                    { 53, "381", 53 },
                    { 54, "995", 54 },
                    { 55, "1-868", 55 },
                    { 56, "51", 56 },
                    { 57, "86", 57 },
                    { 58, "973", 58 },
                    { 59, "54", 59 },
                    { 60, "968", 60 },
                    { 61, "374", 61 },
                    { 62, "965", 62 },
                    { 63, "62", 63 },
                    { 64, "1-876", 64 },
                    { 65, "355", 65 },
                    { 66, "66", 66 },
                    { 67, "52", 67 },
                    { 68, "7", 68 },
                    { 69, "55", 69 },
                    { 70, "387", 70 },
                    { 71, "966", 71 },
                    { 72, "57", 72 },
                    { 73, "94", 73 },
                    { 74, "267", 74 },
                    { 75, "238", 75 },
                    { 76, "1-809", 76 },
                    { 77, "1-829", 76 },
                    { 78, "1-849", 76 }
                });

            migrationBuilder.InsertData(
                table: "PhoneCodes",
                columns: new[] { "Id", "Code", "CountryId" },
                values: new object[,]
                {
                    { 79, "595", 77 },
                    { 80, "593", 78 },
                    { 81, "373", 79 },
                    { 82, "597", 80 },
                    { 83, "27", 81 },
                    { 84, "63", 82 },
                    { 85, "84", 83 },
                    { 86, "962", 84 },
                    { 87, "264", 85 },
                    { 88, "592", 86 },
                    { 89, "90", 87 },
                    { 90, "994", 88 },
                    { 91, "501", 89 },
                    { 92, "217", 90 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrencyId",
                table: "AspNetUsers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LangId",
                table: "AspNetUsers",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatusId",
                table: "AspNetUsers",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_CountryId",
                table: "Banks",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_Name",
                table: "Banks",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BillingCycles_LanguageId",
                table: "BillingCycles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserBankId",
                table: "Cards",
                column: "UserBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CurrencyCode",
                table: "Currencies",
                column: "CurrencyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCodes_CountryId",
                table: "PhoneCodes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchPhone_SubscriptionsSearchId",
                table: "SearchPhone",
                column: "SubscriptionsSearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceCategoryId",
                table: "Services",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceSubCategoryId",
                table: "Services",
                column: "ServiceSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_BillingCycleId",
                table: "Subscriptions",
                column: "BillingCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CurrencyId",
                table: "Subscriptions",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_RemindMeId",
                table: "Subscriptions",
                column: "RemindMeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ServiceId",
                table: "Subscriptions",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionsSearches_ServiceId",
                table: "SubscriptionsSearches",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CardId",
                table: "Transactions",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CurrencyId",
                table: "Transactions",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SubscriptionId",
                table: "Transactions",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBanks_BankId",
                table: "UserBanks",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBanks_UserId",
                table: "UserBanks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CountryTranslates");

            migrationBuilder.DropTable(
                name: "DateFormats");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "PhoneCodes");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "SearchPhone");

            migrationBuilder.DropTable(
                name: "Synchronizations");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SubscriptionsSearches");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "UserBanks");

            migrationBuilder.DropTable(
                name: "BillingCycles");

            migrationBuilder.DropTable(
                name: "RemindMes");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
