using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Banks_BanksBankId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountriesCountryId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Currencies_CurrenciesCurrencyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Languages_LanguagesLanguageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Statuses_StatusId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BanksBankId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CountriesCountryId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurrenciesCurrencyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LanguagesLanguageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StatusId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BanksBankId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConnectedBanks",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CountriesCountryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreateSubscriptions",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrenciesCurrencyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LanguagesLanguageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastActivityDay",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Notification",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PayExperience",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Payments",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PremiumMembership",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistrationDay",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoundNumbersToIntegers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BanksBankId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConnectedBanks",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountriesCountryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateSubscriptions",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrenciesCurrencyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguagesLanguageId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActivityDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Notification",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayExperience",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Payments",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PremiumMembership",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RoundNumbersToIntegers",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BanksBankId",
                table: "AspNetUsers",
                column: "BanksBankId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountriesCountryId",
                table: "AspNetUsers",
                column: "CountriesCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrenciesCurrencyId",
                table: "AspNetUsers",
                column: "CurrenciesCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LanguagesLanguageId",
                table: "AspNetUsers",
                column: "LanguagesLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatusId",
                table: "AspNetUsers",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Banks_BanksBankId",
                table: "AspNetUsers",
                column: "BanksBankId",
                principalTable: "Banks",
                principalColumn: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_CountriesCountryId",
                table: "AspNetUsers",
                column: "CountriesCountryId",
                principalTable: "Countries",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Currencies_CurrenciesCurrencyId",
                table: "AspNetUsers",
                column: "CurrenciesCurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Languages_LanguagesLanguageId",
                table: "AspNetUsers",
                column: "LanguagesLanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Statuses_StatusId",
                table: "AspNetUsers",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId");
        }
    }
}
