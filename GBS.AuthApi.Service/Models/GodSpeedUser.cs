using Microsoft.AspNetCore.Identity;

namespace GBS.AuthApi.Service.Models
{
    public class GodSpeedUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
