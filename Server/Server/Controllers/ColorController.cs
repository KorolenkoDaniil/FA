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

        [HttpPost]
        public List<Colorss> GetColors()
        {
            List<Colorss> colors = colorRepository.ReturnAllColors();
            Console.WriteLine("-----------------------");
            foreach (Colorss colorss in colors)
            {
                Console.WriteLine(colorss);
            }
            Console.WriteLine("-----------------------");
            return colors;
        }
    }
}
