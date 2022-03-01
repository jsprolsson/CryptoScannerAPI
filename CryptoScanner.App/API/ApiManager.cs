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
        public static CryptoModel CryptoModels { get; set; } = new();

        public string baseUrl = "https://api.coingecko.com/api/v3";

        public async Task<CryptoModel> GetCrypto(string cryptoId)
        {

            CryptoModel cryptos = new();

            string url = String.Concat(baseUrl, $"/simple/price?ids={cryptoId}&vs_currencies=SEK");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cryptos = JsonConvert.DeserializeObject<CryptoModel>(apiResponse);

                }
            }


            return cryptos;
        }
    }
}
