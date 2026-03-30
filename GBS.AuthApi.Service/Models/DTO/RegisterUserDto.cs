namespace GBS.Services.AuthApi.Models.DTO
{
    public class RegisterUserDto
    {
        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address {  get; set; }

        public string State {  get; set; }

        public DateOnly DateOfBirth { get; set; }   

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string? Role { get; set; }
    }
}
