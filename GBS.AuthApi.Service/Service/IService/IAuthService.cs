using GBS.Services.AuthApi.Models.DTO;

namespace GBS.Services.AuthApi.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegisterUserDto registerUser);
        Task<LoginResponseDto> Login(LoginUserDto loginUserDto);
    }
}
