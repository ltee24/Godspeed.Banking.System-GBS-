using GBS.Services.LedgerApi.Models.DTO;
using GBS.Services.LedgerApi.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace GBS.Services.LedgerApi.Controllers
{
    [Route("api/ledger")]
    [ApiController]
    public class LedgerController : ControllerBase
    {
        private readonly ILedgerService _ledgerService;
        private ResponseDto _response;

        public LedgerController(ILedgerService ledgerService)
        {
            _response = new ResponseDto();
            _ledgerService = ledgerService;
        }

        [HttpPost("Record-Deposit")]
        public async Task<IActionResult> CreateDepositLedger(LedgerDto ledgerEntries)
        {
           var response = await _ledgerService.RecordDepositLedger(ledgerEntries);
            if(response.IsSuccess != true)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("create/ledger-account")]
        public async Task<IActionResult> CreateUserLedgerAccount(CreateLedgerAccountDto userLedgerAcct)
        {
            var response = await _ledgerService.CreateUserLedgerAccount(userLedgerAcct);
            if(response.IsSuccess != true)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
