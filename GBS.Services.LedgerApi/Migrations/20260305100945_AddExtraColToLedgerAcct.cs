using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBS.Services.LedgerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddExtraColToLedgerAcct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LedgerAccounts",
                keyColumn: "Id",
                keyValue: new Guid("9461fec2-423b-4fc4-be03-18c5bbc69131"));

            migrationBuilder.AddColumn<bool>(
                name: "IsSystemAccount",
                table: "LedgerAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ReferenceAccountId",
                table: "LedgerAccounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "LedgerAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "LedgerAccounts",
                columns: new[] { "Id", "IsSystemAccount", "Name", "ReferenceAccountId", "Type" },
                values: new object[] { new Guid("0abdc2d6-dc0e-49e7-85f6-22afdb0e43d7"), true, "Bank Vault Cash", null, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LedgerAccounts",
                keyColumn: "Id",
                keyValue: new Guid("0abdc2d6-dc0e-49e7-85f6-22afdb0e43d7"));

            migrationBuilder.DropColumn(
                name: "IsSystemAccount",
                table: "LedgerAccounts");

            migrationBuilder.DropColumn(
                name: "ReferenceAccountId",
                table: "LedgerAccounts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "LedgerAccounts");

            migrationBuilder.InsertData(
                table: "LedgerAccounts",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9461fec2-423b-4fc4-be03-18c5bbc69131"), "Bank Vault Cash" });
        }
    }
}
