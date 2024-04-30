using FinanceAppl.Operations;
using Microsoft.AspNetCore.Mvc;
using Server.Operations;
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
            Wallet savedWallet = WalletsRepository.Savewallet(wallet);
            if (savedWallet != null) return Ok(savedWallet);
            else return BadRequest();
        }


        [HttpPost]
        public List<Wallet> GetWallets(string id)
        {
            return WalletsRepository.SearchByUserID(int.Parse(id));
        }

    }
}
