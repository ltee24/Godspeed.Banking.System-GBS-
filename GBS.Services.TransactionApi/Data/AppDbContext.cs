using GBS.Services.TransactionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GBS.Services.TransactionApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
