using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsGrounds.Classes;
using SportsGrounds.Models;
using SportsGrounds.ViewModels;

namespace SportsGrounds.Controllers
{
    public class AccountController : Controller
    {
        private readonly SportsGroundsContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(SportsGroundsContext db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index(string Name) => View(new CRUD(_db).GetUserToName(Name));
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register() => View();

        public IActionResult Change(User user)
        {
            var DbUser = _db.Users.FirstOrDefault(u => u.Id == user.Id);
            if (DbUser != null)
            {
                if(user.NickName!=null)
                    DbUser.NickName = user.NickName;
                DbUser.SportsPlay = user.SportsPlay;
                DbUser.TypeBasketPlayer = user.TypeBasketPlayer;
                if (user.PhoneNumber != null)
                    DbUser.PhoneNumber = user.PhoneNumber;
                _db.Users.Update(DbUser);
                _db.SaveChanges();
            }
            return View("Index", DbUser);
        }
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email};
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }

}

