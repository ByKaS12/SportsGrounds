using Microsoft.AspNetCore.Mvc;
using SportsGrounds.Classes;
using SportsGrounds.Models;

namespace SportsGrounds.Controllers
{
    public class UserController : Controller
    {
        private readonly SportsGroundsContext _db;
        public UserController(SportsGroundsContext db)
        {
            _db = db;
        }
        public IActionResult Index() => View();

        public IActionResult Auth(string Login, string Password)
        {
            CRUD CRUD = new CRUD(_db);
            string exp = string.Empty;
            var User = _db.Users.FirstOrDefault(u=>u.Login == Login);
            if (User != null)
                if (User.Password == Base.GetHash(Password))
                    return View("Index", User);
            //TODO: array errors
            return View("Error", exp);
        }
        public IActionResult Registration() => View("Registration");
        public IActionResult RegUser(string Login, string Password)
        {
            CRUD CRUD = new CRUD(_db);
            string exp = string.Empty;
            var UserCheck = _db.Users.FirstOrDefault(u => u.Login == Login);
            if (UserCheck != null)
                return View("Error",exp);
            User user = new User();
            user.Login = Login;
            if(Password!= string.Empty)
            user.Password = Base.GetHash(Password);
            else
                return View("Error", exp);
            user.CreatedDate = DateTime.UtcNow.Date;
            CRUD.CreateUser(user);
            return View("Index");
        }

    }
}
