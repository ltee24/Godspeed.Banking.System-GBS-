using GBS.Services.TransactionApi.Models.DTO;

namespace GBS.Services.TransactionApi.Service.IService
{
    public interface ILedgerService
    {
        Task<bool> PostDepositLedger(LedgerDto ledgerRequest);
    }
}
