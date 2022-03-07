using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CryptoScanner.Data.Models;
using CryptoScanner.App.API;

namespace CryptoScanner.UI.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string? Id { get; set; }
        public string? Message { get; set; }
        public List<CryptoModel> CryptoModelsList { get; set; } = new();

        public async Task OnGet(string msg)
        {
            Message = msg;
            ApiManager api = new();
            api.SortList();
            CryptoModelsList = ApiManager.CryptoModels;
        }

        public async Task<IActionResult> OnPost()
        {
            ApiManager api = new();
           Message = await api.GetCrypto(Id);
            return RedirectToPage("Index", new {msg = Message});

        }

    }
}