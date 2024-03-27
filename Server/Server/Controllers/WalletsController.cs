using Microsoft.AspNetCore.Mvc;
using Server.Wallets;

namespace Server.Controllers
{
    public class WalletsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public WalletRepository WalletsRepository = new WalletRepository();

        [HttpPost]
        public IActionResult RegisterAWallet([FromBody] Wallet wallet)
        {
            Console.WriteLine(wallet);
            if (WalletsRepository.Savewallet(wallet)) return Ok();
            else return BadRequest();
        }

        [HttpPost]
        public List<Wallet> GetWallets(string id)
        {
            return WalletsRepository.SearchByUserID(int.Parse(id));
        }

    }
}
