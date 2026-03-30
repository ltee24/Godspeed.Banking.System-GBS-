using GBS.Services.TransactionApi.Models.DTO;
using GBS.Services.TransactionApi.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GBS.Services.TransactionApi.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
       private readonly ITransactionService _transactionService;
      
       private ResponseDto _response;

        public TransactionController(ITransactionService transactionService)
        {
            _response = new ResponseDto();
            _transactionService = transactionService;
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit(TransactionRequestDto depositRequest)
        {
            var response = await _transactionService.Deposit(depositRequest);
            if(response.IsSuccess != true)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Withdrawal")]
        public async Task<IActionResult> Withdrawal(TransactionRequestDto withdrawalRequest)
        {
            var response = await _transactionService.Withdraw(withdrawalRequest);
        }
    }
}
