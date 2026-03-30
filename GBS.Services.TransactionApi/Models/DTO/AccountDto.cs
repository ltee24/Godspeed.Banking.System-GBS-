

using static GBS.Services.TransactionApi.Models.Enums.Enums;

namespace GBS.Services.TransactionApi.Models.DTO
{
    public class AccountDto
    {
        public Guid AccountId { get; set; } 
        public string UserId { get; set; }
        
        public decimal AccountBalance { get; set; }
        public AccountType AccountType { get; set; }
        public string AccountNumber { get; set; }
        public bool IsActive { get; set; }


    }
}
