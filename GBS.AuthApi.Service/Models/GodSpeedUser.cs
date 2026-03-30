using Microsoft.AspNetCore.Identity;

namespace GBS.Services.AuthApi.Models
{
    public class GodSpeedUser : IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}
