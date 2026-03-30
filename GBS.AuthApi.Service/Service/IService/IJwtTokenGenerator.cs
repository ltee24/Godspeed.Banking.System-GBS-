using GBS.Services.AuthApi.Models;

namespace GBS.Services.AuthApi.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(GodSpeedUser user,IEnumerable<string> roles);
    }
}
