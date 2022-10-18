using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedTariff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Tariff",
                table: "Subscriptions",
                type: "real",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LangId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "940e6919-0bcf-4591-9246-443888c8e9c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "428dc82c-d0f7-41f0-8fb4-8d7ffedee326");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "LastActivityDay", "PasswordHash", "RegistrationDay" },
                values: new object[] { "988ad809-ed10-4cdd-b1aa-fd985cb606b4", new DateTime(2022, 10, 18, 0, 26, 19, 235, DateTimeKind.Local).AddTicks(8074), "AQAAAAEAACcQAAAAEGN491HsrKjHkAOva8BGQ5XHQbGMPzx3rtDVvQ0NYZpvT5sQaVMm15WUsCp3OsVSUw==", new DateTime(2022, 10, 18, 0, 26, 19, 235, DateTimeKind.Local).AddTicks(8039) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tariff",
                table: "Subscriptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "LangId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
        }
    }
}
