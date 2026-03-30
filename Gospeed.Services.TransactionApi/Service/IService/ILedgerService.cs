using GBS.Services.AccountApi.Models.DTO;

namespace GBS.Services.AccountApi.Service.IService
{
    public interface ILedgerService
    {
        Task<bool> CreateUserLedgerAccount(CreateLedgerAccountDto userLedgerAcct);
    }
}
