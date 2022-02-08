using Microsoft.AspNetCore.Mvc;
using SportsGrounds.Classes;
using SportsGrounds.Models;

namespace SportsGrounds.Controllers
{
    public class GeoObjController : Controller
    {
        private readonly SportsGroundsContext _db;
        public Map Map;
        public GeoObjController(SportsGroundsContext db)
        {
            _db = db;
        }
        public IActionResult Index() => View(Map);

        public IActionResult GetInfObj(Guid Id)
        {
            CRUD CRUD = new(_db);
            Map = CRUD.GetMap(Id);
            if(Map == null)
                return NotFound();
            return View("Index",Map);
        }

    }
}
