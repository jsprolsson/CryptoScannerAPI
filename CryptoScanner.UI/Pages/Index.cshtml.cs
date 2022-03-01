using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CryptoScanner.Data.Models;
using CryptoScanner.App.API;

namespace CryptoScanner.UI.Pages
{
    public class IndexModel : PageModel
    {
        public CryptoModel CryptoModels { get; set; } = new();
        public List<CryptoModel> CryptoModelsList { get; set; } = new();

        public async Task OnGet()
        {
            ApiManager api = new();
            CryptoModels = await api.GetCrypto("bitcoin");
            CryptoModelsList = ApiManager.CryptoModels;
        }

    }
}