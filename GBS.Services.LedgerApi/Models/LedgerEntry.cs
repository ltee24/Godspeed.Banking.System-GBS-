namespace GBS.Services.LedgerApi.Models
{
    public class LedgerEntry
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public Guid AccountId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
