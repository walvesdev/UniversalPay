using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversalPay.Database.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAccounts_Clients_ClientId",
                table: "PaymentAccounts");

            migrationBuilder.DropIndex(
                name: "IX_PaymentAccounts_ClientId",
                table: "PaymentAccounts");

            migrationBuilder.DropIndex(
                name: "IX_PaymentAccounts_Code",
                table: "PaymentAccounts");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "PaymentAccounts");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AccountId",
                table: "Clients",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_PaymentAccounts_AccountId",
                table: "Clients",
                column: "AccountId",
                principalTable: "PaymentAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_PaymentAccounts_AccountId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_AccountId",
                table: "Clients");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "PaymentAccounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAccounts_ClientId",
                table: "PaymentAccounts",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAccounts_Code",
                table: "PaymentAccounts",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentAccounts_Clients_ClientId",
                table: "PaymentAccounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
