using GBS.Services.TransactionApi.Data;
using GBS.Services.TransactionApi.Models;
using GBS.Services.TransactionApi.Models.DTO;
using GBS.Services.TransactionApi.Service.IService;
using static GBS.Services.TransactionApi.Models.Enums.Enums;
namespace GBS.Services.TransactionApi.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _db;
        private readonly IAccountService _accountService;
        private readonly ILedgerService _ledgerService;
        private readonly ResponseDto _responseDto;

        public TransactionService(IAccountService accountService, ILedgerService ledgerService, AppDbContext db)
        {
            _accountService = accountService;
            _ledgerService = ledgerService;
            _db = db;
            _responseDto = new ResponseDto();
        }

        public async Task<ResponseDto> Deposit(TransactionRequestDto depositRequestDto)
        {
            var response = new ResponseDto();
            var acctResponse = await _accountService.GetAccount();
            if(acctResponse == null)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Deposit can not be made because account does not exist"
                };
            }
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = acctResponse.AccountId,
                Amount = depositRequestDto.Amount,
                Type = TransactionType.Deposit
            };
            try
            {
                var ledgerDepositRequest = new LedgerDto
                {
                    AccountId = acctResponse.AccountId,
                    TransactionId = transaction.Id,
                    Amount = depositRequestDto.Amount
                };
                await _ledgerService.PostDepositLedger(ledgerDepositRequest);
                _db.Transactions.Add(transaction);
                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;  
            }
            return new ResponseDto
            {
                IsSuccess = true,
                Message = $"Deposit of {depositRequestDto.Amount} was successful"
            };
        }

        public async Task<ResponseDto> Withdraw(TransactionRequestDto withdrawalRequest)
        {
            var acctResponse = await _accountService.GetAccount();
            if (acctResponse == null)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Deposit can not be made because account does not exist"
                };
            }
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = acctResponse.AccountId,
                Amount = withdrawalRequest.Amount,
                Type = TransactionType.Deposit
            };
            try
            {
                var ledgerWithdrawalRequest = new LedgerDto
                {
                    AccountId = acctResponse.AccountId,
                    TransactionId = transaction.Id,
                    Amount = withdrawalRequest.Amount,
                };
            }
        }
    }
}
