using Microsoft.EntityFrameworkCore;
using static GBS.Services.AccountApi.Models.Enums.Enums;

namespace GBS.Services.AccountApi.Models
{
    [Index(nameof(AccountNumber), IsUnique = true)]
    public class Account
    {
        public Guid AccountId { get; set; }

        public string UserId { get; set; }

        public decimal AccountBalance { get; set; }

        public string AccountNumber { get; set; }

        public AccountType AccountType { get; set; }

        public bool IsActive { get; set; }


    }
}
