using GBS.AuthApi.Service.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GBS.AuthApi.Service.Data
{
    public class AppDbContext:IdentityDbContext<GodSpeedUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<GodSpeedUser> GodSpeedUsers { get; set; }
    }
}
