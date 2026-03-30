using GBS.Services.TransactionApi.Models.DTO;

namespace GBS.Services.TransactionApi.Service.IService
{
    public interface IAccountService
    {
        Task<AccountDto> GetAccount();
    }
}
