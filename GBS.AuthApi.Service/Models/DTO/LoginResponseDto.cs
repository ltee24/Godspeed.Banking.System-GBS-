namespace GBS.Services.AuthApi.Models.DTO
{
    public class LoginResponseDto
    {
        public UserDetailsDto UserDetails { get; set; }
        public string Token { get; set; }
    }
}
