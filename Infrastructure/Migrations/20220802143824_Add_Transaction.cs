using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Add_Transaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sum = table.Column<float>(type: "real", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    SubscriptionId = table.Column<int>(type: "int", nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CurrencyId",
                table: "Transactions",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
