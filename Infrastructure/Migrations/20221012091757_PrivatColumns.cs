using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class PrivatColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantPassword",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "37321187-90bc-468a-94f2-76f535059764");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "3cda8d8b-5571-4d9a-ab3c-14c334e8424a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "LastActivityDay", "PasswordHash", "RegistrationDay" },
                values: new object[] { "ef873fef-9a5b-4160-86f1-11e3d13e5bad", new DateTime(2022, 10, 12, 12, 17, 56, 830, DateTimeKind.Local).AddTicks(6952), "AQAAAAEAACcQAAAAEPxwqK1ig9dBBFPd24bUSbv8DOaEuEHR1daDxElczA17uYpHjd+4NMj1qCq0mKKPsQ==", new DateTime(2022, 10, 12, 12, 17, 56, 830, DateTimeKind.Local).AddTicks(6923) });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_RemindMeId",
                table: "Subscriptions",
                column: "RemindMeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_RemindMes_RemindMeId",
                table: "Subscriptions",
                column: "RemindMeId",
                principalTable: "RemindMes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_RemindMes_RemindMeId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_RemindMeId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MerchantPassword",
                table: "Cards");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "6c1d1c47-e74b-4efa-8744-00987f400048");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "103eea27-1705-409a-ac7a-4250b457fad5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "LastActivityDay", "PasswordHash", "RegistrationDay" },
                values: new object[] { "feb44219-a0bd-458f-9752-ab0fd9c372e7", new DateTime(2022, 10, 11, 18, 23, 36, 499, DateTimeKind.Local).AddTicks(9626), "AQAAAAEAACcQAAAAEHf9+13yBNK9GlOoHBxHiDi1uq5SY94u0CWURINqCbzRPYlbUHuD54xLOCCohwQYww==", new DateTime(2022, 10, 11, 18, 23, 36, 499, DateTimeKind.Local).AddTicks(9595) });
        }
    }
}
