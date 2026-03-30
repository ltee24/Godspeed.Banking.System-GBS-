using System.ComponentModel.DataAnnotations;

namespace GBS.Services.AccountApi.Models.Enums
{
    public class Enums
    {
        public enum AccountType
        {
            Savings = 1,
            Current = 2,
            [Display(Name = "Fixed Deposit")]
            FixedDeposit = 3,
        }
    }
}
