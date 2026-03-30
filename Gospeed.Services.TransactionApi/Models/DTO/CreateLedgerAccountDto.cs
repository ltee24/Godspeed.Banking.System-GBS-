namespace GBS.Services.AccountApi.Models.DTO
{
    public class CreateLedgerAccountDto
    {
         public string AccountName {  get; set; }   
         public Guid? ReferenceAccountId { get; set; }  
    }
}
