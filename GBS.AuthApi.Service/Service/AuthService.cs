using GBS.AuthApi.Service.Utility;
using GBS.Services.AuthApi.Data;
using GBS.Services.AuthApi.Models;
using GBS.Services.AuthApi.Models.DTO;
using GBS.Services.AuthApi.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace GBS.Services.AuthApi.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<GodSpeedUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext db, UserManager<GodSpeedUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponseDto> Login(LoginUserDto loginUserDto)
        {
            GodSpeedUser user = _db.GodSpeedUsers.FirstOrDefault(u => u.UserName == loginUserDto.UserName);
            bool isValid = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);
            if (user == null || !isValid)
            {
                return new LoginResponseDto() { UserDetails = null, Token = "" };
            }
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);
            UserDetailsDto userDetails = new()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Firstname,
                PhoneNumber = user.PhoneNumber
            };
            LoginResponseDto responseDto = new LoginResponseDto()
            {
                UserDetails = userDetails,
                Token = token
            };
            return responseDto;
        }

        public async Task<string> Register(RegisterUserDto registerUser)
        {

            GodSpeedUser user = new()
            {
                Email = registerUser.Email,
                Firstname = registerUser.Firstname,
                Lastname = registerUser.Lastname,
                Address = registerUser.Address,
                State = registerUser.State,
                DateOfBirth = registerUser.DateOfBirth,
                PhoneNumber = registerUser.PhoneNumber,
                UserName = registerUser.Email,
                NormalizedEmail = registerUser.Email.ToUpper(),
            };
            var result = await _userManager.CreateAsync(user, registerUser.Password);
            try
            {
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, SD.RoleCustomer);
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {

            }
            return "Error Encountered";

        }
    }
}
