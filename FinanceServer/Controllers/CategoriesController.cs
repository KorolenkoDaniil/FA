using FinanceApplication.core.Category;
using Microsoft.AspNetCore.Mvc;

namespace FinanceServer.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public CategoryRepository CategoriesRepository = new CategoryRepository();

        [HttpPost]
        public IActionResult RegisterCategory([FromBody] Category category)
        {
            Console.WriteLine(category);
            if (CategoriesRepository.SaveCategory(category)) return Ok();
            else return BadRequest();
        }

        [HttpPost]
        public List<Category> GetCategories(string id)
        {
            return CategoriesRepository.SearchByUserID(int.Parse(id));
        }

    }
}
