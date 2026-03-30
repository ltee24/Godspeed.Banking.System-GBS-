using GBS.Services.TransactionApi.Models.DTO;

namespace GBS.Services.TransactionApi.Service.IService
{
    public interface ITransactionService
    {
        Task<ResponseDto> Deposit(TransactionRequestDto depositRequestDto);
        Task<ResponseDto> Withdraw(TransactionRequestDto depositRequestDto);
        
    }
}
