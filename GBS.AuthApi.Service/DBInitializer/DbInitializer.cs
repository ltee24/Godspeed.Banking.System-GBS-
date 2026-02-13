using GBS.AuthApi.Service.Data;
using GBS.AuthApi.Service.Models;
using GBS.AuthApi.Service.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GBS.AuthApi.Service.DBInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<GodSpeedUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _db;

        public DbInitializer(UserManager<GodSpeedUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            if(!_roleManager.RoleExistsAsync(SD.RoleAdmin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.RoleAdmin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.RoleStaff)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.RoleCustomer)).GetAwaiter().GetResult();
            }

            return;
        }
    }
}
