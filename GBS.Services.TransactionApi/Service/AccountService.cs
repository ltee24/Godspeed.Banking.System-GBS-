using GBS.Services.TransactionApi.Models.DTO;
using GBS.Services.TransactionApi.Service.IService;
using Newtonsoft.Json;

namespace GBS.Services.TransactionApi.Service
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AccountDto> GetAccount()
        {
            var client = _httpClientFactory.CreateClient("Account");
            var response = await client.GetAsync($"api/account");
            var apiContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (apiResponse.IsSuccess)
            {
                return JsonConvert.DeserializeObject<AccountDto>(Convert.ToString(apiResponse.Result));
            }
            return new AccountDto();
        }
    }
}
