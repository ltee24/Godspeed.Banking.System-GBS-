using static GBS.Services.AccountApi.Models.Enums.Enums;

namespace GBS.Services.AccountApi.Models.DTO
{
    public class CreateAccountDto
    {
        public string AccountName {  get; set; }
        public AccountType accountType { get; set; }
    }
}
