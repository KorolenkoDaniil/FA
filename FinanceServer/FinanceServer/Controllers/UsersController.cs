﻿using FinanceApp.classes.Users;
using Microsoft.AspNetCore.Mvc;

namespace FinS.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public UserRepository UserRepository = new UserRepository();

        [HttpPost]
        public User Registration([FromBody] User user)
        {
            user.UserId = UserRepository.SaveUser(user);
            return user;
        }


        [HttpPost]
        public User Authorisation(string email, string password)
        {
            return UserRepository.SearchByEmailAndPassword(email, password); ;
        }


    }
}
