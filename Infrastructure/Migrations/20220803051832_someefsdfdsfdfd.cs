using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class someefsdfdsfdfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConnectedBanks",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateSubscriptions",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LangId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguagesLanguageId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActivityDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Notification",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PayExperience",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Payments",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PremiumMembership",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "RoundNumbersToIntegers",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                name: "IX_AspNetUsers_BankId",
                table: "AspNetUsers",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrencyId",
                table: "AspNetUsers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LanguagesLanguageId",
                table: "AspNetUsers",
                column: "LanguagesLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatusId",
                table: "AspNetUsers",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Banks_BankId",
                table: "AspNetUsers",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Currencies_CurrencyId",
                table: "AspNetUsers",
                column: "CurrencyId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Banks_BankId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Currencies_CurrencyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Languages_LanguagesLanguageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Statuses_StatusId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BankId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurrencyId",
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
                name: "BankId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConnectedBanks",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreateSubscriptions",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LangId",
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
    }
}
