namespace GBS.Services.LedgerApi.Models.DTO
{
    public class LedgerDto
    {
       public decimal Amount { get; set; }

        public Guid TransactionId { get; set; }
       public Guid AccountId { get; set; }
    }
}
