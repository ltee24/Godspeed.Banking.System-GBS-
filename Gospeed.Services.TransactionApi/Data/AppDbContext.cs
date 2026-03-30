using GBS.Services.AccountApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GBS.Services.AccountApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }
        
        public DbSet<Account> Accounts { get; set; }
    }
}
