using GBS.Services.AccountApi.Models.DTO;
using GBS.Services.AccountApi.Service.IService;
using Newtonsoft.Json;
using System.Text;

namespace GBS.Services.AccountApi.Service
{
    public class LedgerService : ILedgerService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LedgerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateUserLedgerAccount(CreateLedgerAccountDto ledgerAccountDto)
        {
            string jsonPayload = JsonConvert.SerializeObject(ledgerAccountDto); 
            var client = _httpClientFactory.CreateClient("Ledger");
            var path = $"api/ledger/create/ledger-account";
            var content = new StringContent(jsonPayload,Encoding.UTF8,"application/json") ;
            var response = await client.PostAsync(path, content) ;
            var apiContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ResponseDto>(apiContent) ;
            if (apiResponse.IsSuccess)
            {
                return true ;
            }
            return false;

        }
    }
}
