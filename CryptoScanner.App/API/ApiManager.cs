using CryptoScanner.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CryptoScanner.App.API
{
    public class ApiManager
    {
        public static List<CryptoModel> CryptoModels { get; set; } = new();

        public string baseUrl = "https://api.coingecko.com/api/v3/simple/price?ids=0x%2Cbitcoin%2Cdogecoin&vs_currencies=SEK";

        public async Task<List<CryptoModel>> GetCrypto()
        {

            List<CryptoModel> cryptos = new();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    

                using (var response = await httpClient.GetAsync(baseUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cryptos = JsonConvert.DeserializeObject<List<CryptoModel>>(apiResponse);

                    return cryptos;

                }
            }

            return null;
        }
    }
}
