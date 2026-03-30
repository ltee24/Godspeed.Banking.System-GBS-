using static GBS.Services.LedgerApi.Enums.Enums;

namespace GBS.Services.LedgerApi.Models
{
    public class LedgerAccount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LedgerAccountType Type { get; set; }
        public Guid? ReferenceAccountId { get; set; }
        public bool IsSystemAccount {  get; set; }
    }
}
