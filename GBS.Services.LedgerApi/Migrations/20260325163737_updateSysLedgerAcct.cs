using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBS.Services.LedgerApi.Migrations
{
    /// <inheritdoc />
    public partial class updateSysLedgerAcct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LedgerAccounts",
                keyColumn: "Id",
                keyValue: new Guid("0abdc2d6-dc0e-49e7-85f6-22afdb0e43d7"));

            migrationBuilder.InsertData(
                table: "LedgerAccounts",
                columns: new[] { "Id", "IsSystemAccount", "Name", "ReferenceAccountId", "Type" },
                values: new object[] { new Guid("7f4f7c3e-5e9b-4e3e-9b52-9c7d8f7a1111"), true, "Bank Vault Cash", null, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LedgerAccounts",
                keyColumn: "Id",
                keyValue: new Guid("7f4f7c3e-5e9b-4e3e-9b52-9c7d8f7a1111"));

            migrationBuilder.InsertData(
                table: "LedgerAccounts",
                columns: new[] { "Id", "IsSystemAccount", "Name", "ReferenceAccountId", "Type" },
                values: new object[] { new Guid("0abdc2d6-dc0e-49e7-85f6-22afdb0e43d7"), true, "Bank Vault Cash", null, 1 });
        }
    }
}
