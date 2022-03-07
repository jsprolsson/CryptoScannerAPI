using CryptoScanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CryptoScanner.Data.MemoryCacheManager
{
    public class CacheManager
    {
        public static async Task CacheStartingCryptos(List<CryptoModel> cryptos)
        {
            ObjectCache cache = MemoryCache.Default;
            CacheItemPolicy policy = new();
            CacheItem cachedCryptos = new CacheItem("cryptos", cryptos);
            cache.Set(cachedCryptos, policy);
        }
        
        public static List<CryptoModel> GetCachedCryptos()
        {
            ObjectCache cache = MemoryCache.Default;
            CacheItem cachedCryptos = cache.GetCacheItem("cryptos");
            List<CryptoModel> cryptos = new List<CryptoModel>();
            if (cachedCryptos != null)
            {
                cryptos = (List<CryptoModel>)cache.Get("cryptos");
            }

            return cryptos;
        }

        public static void CacheCrypto(CryptoModel crypto)
        {
            ObjectCache cache = MemoryCache.Default;
            CacheItem cachedCryptos = cache.GetCacheItem("cryptos");
            List<CryptoModel> cryptos = new();

            if (cachedCryptos != null)
            {
                cryptos = (List<CryptoModel>)cache.Get("cryptos");
            }

            cryptos.Add(crypto);
            CacheItemPolicy policy = new();
            cachedCryptos = new CacheItem("cryptos", cryptos);
            cache.Set(cachedCryptos, policy);
        }

    }
}
