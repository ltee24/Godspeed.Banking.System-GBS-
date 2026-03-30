using GBS.Services.TransactionApi.Models.DTO;
using GBS.Services.TransactionApi.Service.IService;
using Newtonsoft.Json;
using System.Text;

namespace GBS.Services.TransactionApi.Service
{
    public class LedgerService : ILedgerService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LedgerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> PostDepositLedger(LedgerDto ledgerRequest)
        {
            string jsonPayload = JsonConvert.SerializeObject(ledgerRequest);
            var client = _httpClientFactory.CreateClient("Ledger");
            var path = $"api/ledger/record-deposit";
            var content = new StringContent(jsonPayload,Encoding.UTF8,"application/json");
            var response = await client.PostAsync(path,content);
            var apicontent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ResponseDto>(apicontent);
            if (apiResponse.IsSuccess)
            {
                return true;
            }
            return false;
        }
    }
}
