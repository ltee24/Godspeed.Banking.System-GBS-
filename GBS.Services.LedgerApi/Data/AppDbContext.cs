using GBS.Services.LedgerApi.Models;
using Microsoft.EntityFrameworkCore;
using static GBS.Services.LedgerApi.Enums.Enums;

namespace GBS.Services.LedgerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<LedgerEntry> LedgerEntries { get; set; } 
        public DbSet<LedgerAccount> LedgerAccounts { get; set; }
        public DbSet<LedgerTransaction> LedgerTransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LedgerAccount>().HasData(new LedgerAccount
            {
                Id = Guid.Parse("7f4f7c3e-5e9b-4e3e-9b52-9c7d8f7a1111"),
                Name = "Bank Vault Cash",
                Type = (LedgerAccountType)1,
                ReferenceAccountId = null,
                IsSystemAccount = true,

            });
        }
    }
}
