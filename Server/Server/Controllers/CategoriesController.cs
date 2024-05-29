﻿using Microsoft.AspNetCore.Mvc;
using Server.Models.Categories1;
using Server.Wallets;

namespace Server.Controllers
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
            Category savedCathegory = CategoriesRepository.SaveCategory(category);
            if (savedCathegory != null) return Ok(savedCathegory);
            else return BadRequest();
        }

        [HttpPost]
        public IActionResult DaleteCategory([FromBody] Category category)
        {
            bool delete = CategoriesRepository.DeleteCategory(category);
            if (delete != null) return Ok();
            else return BadRequest();
        }




        [HttpPost]
        public List<Category> GetCategories(string id)
        {
            Console.WriteLine($"id пользователя при получении категорий {id}");
            List <Category> a = CategoriesRepository.SearchByUserID(int.Parse(id));

            return a;
        }
    }
}
