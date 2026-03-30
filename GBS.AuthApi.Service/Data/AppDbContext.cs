using GBS.Services.AuthApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GBS.Services.AuthApi.Data
{
    public class AppDbContext:IdentityDbContext<GodSpeedUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<GodSpeedUser> GodSpeedUsers { get; set; }
    }
}
