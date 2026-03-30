using GBS.Services.LedgerApi.Models.DTO;

namespace GBS.Services.LedgerApi.Service.IService
{
    public interface ILedgerService
    {
        Task<ResponseDto> RecordDepositLedger(LedgerDto ledgerEntries);

        Task<ResponseDto> CreateUserLedgerAccount(CreateLedgerAccountDto userLedger);
    }
}
