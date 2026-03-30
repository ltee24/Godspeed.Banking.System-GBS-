using System.ComponentModel.DataAnnotations;

namespace GBS.Services.TransactionApi.Models.Enums
{
    public class Enums
    {
        public enum TransactionType
        {
            Deposit = 0,
            Withdrawal = 1,
            Transfer = 2,
        }

        public enum AccountType
        {
            Savings = 1,
            Current = 2,
            [Display(Name = "Fixed Deposit")]
            FixedDeposit = 3,
        }


    }
}
