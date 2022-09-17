using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ConfirmEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmationEmailToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ConfirmationEmailTokenExpirationDate",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "2cd5eb1e-de32-4c92-8227-6c82bb1a2290");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "87cb69c2-8fc6-4d46-8830-841801afe103");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "LastActivityDay", "PasswordHash", "RegistrationDay" },
                values: new object[] { "dcbd54f0-322f-4e35-b372-33fa8a4b7d87", new DateTime(2022, 9, 16, 20, 47, 0, 474, DateTimeKind.Local).AddTicks(7441), "AQAAAAEAACcQAAAAEM11q9w9Aa1AVNTwlnpvVP7N/WenBjnzTrM/FC13QloXKd3e2MuPBdXCT5OjR574Yw==", new DateTime(2022, 9, 16, 20, 47, 0, 474, DateTimeKind.Local).AddTicks(7393) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationEmailToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConfirmationEmailTokenExpirationDate",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "92a1fd23-012a-43ee-84f8-256ddc34992e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "b46dff66-64ef-40f2-aaa9-63becf2d0b5d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "LastActivityDay", "PasswordHash", "RegistrationDay" },
                values: new object[] { "78a5597c-e800-4e3f-be47-0fbb36df85cb", new DateTime(2022, 9, 12, 0, 28, 43, 753, DateTimeKind.Local).AddTicks(531), "AQAAAAEAACcQAAAAEDgwgDWchOqmHCk4v5VbCJ3yTYGylHEH6XE7zb44UVAuSN+Ate2//4RDT5dZXODe7A==", new DateTime(2022, 9, 12, 0, 28, 43, 753, DateTimeKind.Local).AddTicks(495) });
        }
    }
}
