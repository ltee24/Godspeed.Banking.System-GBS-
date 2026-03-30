using GBS.Services.AccountApi.Models.DTO;
using static GBS.Services.AccountApi.Models.Enums.Enums;

namespace GBS.Services.AccountApi.Service.IService
{
    public interface IAccountService
    {
        Task<ResponseDto> CreateAccount(string userId, CreateAccountDto userAccountDetails);

        Task<ResponseDto> GetAccount(string userId);

        Task<ResponseDto> DeleteAccount(string accountNumber);
    }
}
