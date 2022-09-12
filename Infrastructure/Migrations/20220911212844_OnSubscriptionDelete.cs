using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class OnSubscriptionDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Subscriptions_SubscriptionId",
                table: "Transactions");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Subscriptions_SubscriptionId",
                table: "Transactions",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Subscriptions_SubscriptionId",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "096feb0a-6486-4817-b46a-f5a336752124");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "871c121b-be74-4a35-af16-5945737026fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "LastActivityDay", "PasswordHash", "RegistrationDay" },
                values: new object[] { "cc07d81b-39a0-4970-9a95-9bf5f4472709", new DateTime(2022, 9, 11, 14, 56, 50, 95, DateTimeKind.Local).AddTicks(8547), "AQAAAAEAACcQAAAAEFAuE5OFt4/jQmZ0nKMBu/8l8ghbCPKjJR7dzVdKQOHoBUifMct6it14nTrtGRdd6Q==", new DateTime(2022, 9, 11, 14, 56, 50, 95, DateTimeKind.Local).AddTicks(8513) });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Subscriptions_SubscriptionId",
                table: "Transactions",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id");
        }
    }
}
