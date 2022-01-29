using Microsoft.AspNetCore.Mvc;
using SportsGrounds.Classes;

namespace SportsGrounds.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Func()
        {
            string url = "https://search-maps.yandex.ru/v1/?text=category_id:(77500452834)&ll=38.078237,54.88628&spn=0.052069,0.050552&rspn=1&results=500&lang=ru_RU&apikey=b4a7ecbb-6ea1-40ba-b43d-03efb446b4a9";
            GetRequest request = new GetRequest(url);
            request.Run();
            //TODO
            return View();
        }
    }
}
