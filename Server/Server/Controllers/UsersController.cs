using Microsoft.AspNetCore.Mvc;
using Server.Users;

namespace Server.Controllers
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
            Console.WriteLine("-------------смена пользователя");
            Console.WriteLine(UserRepository.SearchByEmailAndPassword(email, password));
            Console.WriteLine("-------------смена пользователя");
            return UserRepository.SearchByEmailAndPassword(email, password); 
        }


    }
}
