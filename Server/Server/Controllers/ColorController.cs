using Microsoft.AspNetCore.Mvc;
using Server.Colors;

namespace Server.Controllers
{
    public class ColorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ColorRepository colorRepository = new ColorRepository();

        [HttpPost]
        public Colorss GetColor(int id)
        {
            Console.WriteLine(id);
            return colorRepository.SearchById(id);
        }
    }
}
