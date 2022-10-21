using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "be84763b-1a2c-4f31-9990-ae8c72f01104");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "0533ec6b-6ca5-475d-a390-b485f39669ff");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2301D884-221A-4E7D-B509-0113DCC043E1", "B22698B8-42A2-4115-9631-1C2D1E2AC5F7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "LastActivityDay", "PasswordHash", "RegistrationDay" },
                values: new object[] { "a1be4a14-98e1-4d94-af73-9b894a1f51ad", new DateTime(2022, 10, 19, 19, 30, 2, 206, DateTimeKind.Local).AddTicks(5131), "AQAAAAEAACcQAAAAEGdp9rOgQ7tHRvv8dhQuQIAUbvEEuOq2z84Q6GwXoRAA44qAmD4NEdwu+9xeMsJCcQ==", new DateTime(2022, 10, 19, 19, 30, 2, 206, DateTimeKind.Local).AddTicks(5094) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2301D884-221A-4E7D-B509-0113DCC043E1", "B22698B8-42A2-4115-9631-1C2D1E2AC5F7" });

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
    }
}
