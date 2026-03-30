using static GBS.Services.TransactionApi.Models.Enums.Enums;

namespace GBS.Services.TransactionApi.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount {  get; set; }
        public TransactionType Type { get; set; }
    }
}
