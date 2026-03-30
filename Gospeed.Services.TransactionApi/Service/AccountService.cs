using GBS.Services.AccountApi.Data;
using GBS.Services.AccountApi.Models;
using GBS.Services.AccountApi.Models.DTO;
using GBS.Services.AccountApi.Service.IService;
using Microsoft.EntityFrameworkCore;
using static GBS.Services.AccountApi.Models.Enums.Enums;

namespace GBS.Services.AccountApi.Service
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _db;
        private readonly ILedgerService _ledgerService;


        public AccountService(AppDbContext db, ILedgerService ledgerService)
        {
            _db = db;
            _ledgerService = ledgerService;
        }

        public async Task<ResponseDto> CreateAccount(string userId,CreateAccountDto userAccountDetails)
        {
            var response = new ResponseDto();
            bool userAcctExists = _db.Accounts.Any(x => x.UserId == userId);
            if (!userAcctExists)
            {
                Account account = new Account
                {
                    AccountId = Guid.NewGuid(),
                    UserId = userId,
                    AccountBalance = 0.00m,
                    AccountNumber = await GenerateAccountNumber(),
                    AccountType = userAccountDetails.accountType,
                    IsActive = true,
                };
                try
                {
                    var userLedgerAcct = new CreateLedgerAccountDto
                    {
                        AccountName = userAccountDetails.AccountName,
                        ReferenceAccountId = account.AccountId
                    };
                    await _ledgerService.CreateUserLedgerAccount(userLedgerAcct);
                    _db.Accounts.Add(account);
                    await _db.SaveChangesAsync();
                    response.Result = new AccountDto
                    {
                        AccountNumber = account.AccountNumber,
                        AccountType = account.AccountType,
                        IsActive = true
                    };
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = ex.Message;

                }
                return response;
            }
            response.IsSuccess = false;
            response.Message = "User already has an existing account";
            return response;
          

        }

        public async Task<ResponseDto> DeleteAccount(string accountNumber)
        {
            var response = new ResponseDto();
            Account account = await _db.Accounts.FirstOrDefaultAsync(x=>x.AccountNumber == accountNumber);
            if (account == null)
            {
               return new ResponseDto { IsSuccess = false,Message = "Account does not exist" };
               
            }
            try
            {
                account.IsActive = false;
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<ResponseDto> GetAccount(string userId)
        {
            var response = new ResponseDto();
            Account account = await _db.Accounts.FirstOrDefaultAsync(x => x.UserId == userId && x.IsActive == true);
            if (account == null)
            {
                return new ResponseDto { IsSuccess = false, Message = "Account does not exist" };

            }
            //remember to use a DTO instead
            response.Result = account;
            return response;   
        }

        private async Task<string> GenerateAccountNumber()
        {
            var bytes = Guid.NewGuid().ToByteArray();
            long number = Math.Abs(BitConverter.ToInt64(bytes, 0));
            string accountNumber = (number % 10_000_000_000).ToString("D10");
            return accountNumber;


        }
    }
}
