using static GBS.Services.AccountApi.Models.Enums.Enums;

namespace GBS.Services.AccountApi.Models.DTO
{
    public class AccountDto
    {
        public string UserId { get; set; }

        public decimal AccountBalance { get; set; }
        public AccountType AccountType { get; set; }
        public string AccountNumber { get; set; }
        public bool IsActive { get; set; }


    }
}
