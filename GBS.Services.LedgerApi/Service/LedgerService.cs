using Azure;
using GBS.Services.LedgerApi.Data;
using GBS.Services.LedgerApi.Models;
using GBS.Services.LedgerApi.Models.DTO;
using GBS.Services.LedgerApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace GBS.Services.LedgerApi.Service
{
    public class LedgerService : ILedgerService
    {
        public LedgerService(AppDbContext db)
        {
            _db = db;
        }

        public AppDbContext _db {  get; set; }

        public async Task<ResponseDto> CreateUserLedgerAccount(CreateLedgerAccountDto userLedger)
        {
            var response = new ResponseDto();
            var createLedgerAcct = new LedgerAccount
            {
                Id = Guid.NewGuid(),
                Name = userLedger.AccountName,
                Type = Enums.Enums.LedgerAccountType.Liability,
                ReferenceAccountId = userLedger.ReferenceAccountId,
                IsSystemAccount = false,

            };  
            try
            {
                _db.LedgerAccounts.Add(createLedgerAcct);
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
            };
        }

        public async Task<ResponseDto> RecordDepositLedger(LedgerDto ledgerEntries)
        {
            var response = new ResponseDto();
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                var depositTrax = new LedgerTransaction
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                };
                await _db.LedgerTransactions.AddAsync(depositTrax);
                var userLedgerAcct = await _db.LedgerAccounts.FirstAsync(x => x.ReferenceAccountId == ledgerEntries.AccountId);
                var systemLedgerAcct = await _db.LedgerAccounts.FirstAsync(x => x.IsSystemAccount == true);
                var debitEntry = new LedgerEntry
                {
                    Id = Guid.NewGuid(),
                    TransactionId =depositTrax.Id,
                    AccountId = systemLedgerAcct.Id,
                    Debit = ledgerEntries.Amount,
                    Credit = 0,
                    CreatedAt = DateTime.UtcNow,
                };
                var creditEntry = new LedgerEntry
                {
                    Id = Guid.NewGuid(),
                    TransactionId = depositTrax.Id,
                    AccountId = userLedgerAcct.Id,
                    Credit = ledgerEntries.Amount,
                    Debit = 0,
                    CreatedAt = DateTime.UtcNow,
                };
                await _db.LedgerEntries.AddRangeAsync(debitEntry, creditEntry);
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return new ResponseDto
            {
                IsSuccess = true,
            };
        }
    }
}
