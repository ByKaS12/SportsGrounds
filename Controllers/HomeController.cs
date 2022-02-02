using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SportsGrounds.Classes;
using SportsGrounds.Models;

namespace SportsGrounds.Controllers
{
    public class HomeController : Controller
    {
        private readonly SportsGroundsContext _db;
        public HomeController(SportsGroundsContext db)
        {
            _db = db;
        }
        public IActionResult Index() => View();

       
    }
}
