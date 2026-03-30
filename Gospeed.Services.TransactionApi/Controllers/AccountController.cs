using GBS.Services.AccountApi.Models.DTO;
using GBS.Services.AccountApi.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static GBS.Services.AccountApi.Models.Enums.Enums;

namespace GBS.Services.AccountApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private ResponseDto _response;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
            _response = new ResponseDto();
        }

        //remember to call Ledger Account and create a record after creating an account, so in Ledger service when we want to store to
        [HttpPost("open-account")]
        public async Task<IActionResult> CreateAccount(CreateAccountDto userAccountDetails)
        {
            var userId = User.Claims.Where(u=>u.Type == ClaimTypes.NameIdentifier)?.FirstOrDefault()?.Value;
            var response = await _accountService.CreateAccount(userId,userAccountDetails);
            if(!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }

        [HttpGet]
       // [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAccount()
        {
            var userId = User.Claims.Where(u => u.Type == ClaimTypes.NameIdentifier)?.FirstOrDefault()?.Value;
            var response = await _accountService.GetAccount(userId);
            if(!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }

        [HttpDelete("{accountNumber}")]
        [Authorize(Roles ="ADMIN")]
        public async Task<IActionResult> DeleteAccount(string accountNumber)
        {
            var response = await _accountService.DeleteAccount(accountNumber);
            if(!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }



    }
}
