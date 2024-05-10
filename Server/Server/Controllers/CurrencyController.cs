using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    public class CurrencyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<Currency> GetCurrency()
        {
            Currency currencyRate = CurrencyService.currencyRate;
            Console.WriteLine(currencyRate);

            return currencyRate;
        }
    }
}
