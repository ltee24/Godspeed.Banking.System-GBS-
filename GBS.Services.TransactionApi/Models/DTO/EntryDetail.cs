namespace GBS.Services.TransactionApi.Models.DTO
{
    public class EntryDetail
    {
        public Guid AccountId { get; set; }
        public string Debit {  get; set; }
        public string Credit { get; set; }
    }
}
