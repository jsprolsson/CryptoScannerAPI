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
        public static List<CryptoModel> CryptoModels { get; set; }

        public string baseUrl = "https://api.coingecko.com/api/v3";

        public static async Task GetStartingCrypto()
        {
            List<CryptoModel> cryptos = new();
            ApiManager apiManager = new ApiManager();

            string url = String.Concat(apiManager.baseUrl, $"/coins/markets?vs_currency=sek&ids=bitcoin%2Cdogecoin%2Cethereum%2Ctether%2Ccardano%2Csolana%2Cavalanche%2Cpolkadot&order=market_cap_asc&per_page=250&page=1&sparkline=false");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cryptos = JsonConvert.DeserializeObject<List<CryptoModel>>(apiResponse);

                }
            }

            CryptoModels = cryptos;
        }

        public void SortList()
        {
            CryptoModels = CryptoModels.OrderByDescending(x => x.current_price).ToList();
        }

        public async Task<string> GetCrypto(string coinId)
        {
            List<CryptoModel> cryptos = new();
            CryptoModel cryptoModel = new();
            string msg;

            string url = String.Concat(baseUrl, $"/coins/markets?vs_currency=sek&ids={coinId}&order=market_cap_asc&per_page=250&page=1&sparkline=false");

            using(var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cryptos = JsonConvert.DeserializeObject<List<CryptoModel>>(apiResponse);
                }
            }

            cryptoModel = cryptos.Find(x => x.id == coinId);
            

            if (cryptoModel == null)
            {
                return msg = "Bad Request!";
            }
            else
            {
                CryptoModels.Add(cryptoModel);
                return msg = "Coin added!";
            }

        }
    }
}
