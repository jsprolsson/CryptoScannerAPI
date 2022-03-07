using CryptoScanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoScanner.App.Logic
{
    public class AppLogicManager
    {
        public static List<CryptoModel> GetCryptos()
        {
            List<CryptoModel> sortedList = Data.MemoryCacheManager.CacheManager.GetCachedCryptos()
                .OrderByDescending(x => x.current_price).ToList();

            return sortedList;
        }

        public static void CacheCrypto(CryptoModel crypto)
        {
            Data.MemoryCacheManager.CacheManager.CacheCrypto(crypto);
        }
    }
}
