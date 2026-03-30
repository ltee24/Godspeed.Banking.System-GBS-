namespace GBS.Services.LedgerApi.Models.DTO
{
    public class CreateLedgerAccountDto
    {
         public string AccountName {  get; set; }   
         public Guid? ReferenceAccountId { get; set; }  
    }
}
