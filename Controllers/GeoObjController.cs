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
        public IActionResult Participate (DateTime MeetTime,Guid MapId,string name)
        {
            CRUD CRUD = new(_db);
            var User = CRUD.GetUserToName(name);
            if (User != null)
            {
                var Map = CRUD.GetMap(MapId);
                if (Map != null)
                {
                    User.TimeToMeet = MeetTime;
                    CRUD.UpdateUser(User);
                    if (Map.Users.FirstOrDefault(u => u.UserName == User.UserName) == null)
                    {
                        Map.Users.Add(User);
                        CRUD.UpdateMap(Map);
                    }

                    return View("Index", Map);
                }
                else
                {
                    return View("Index", this.Map);
                }

            }
            else
            {
                return View("Index", this.Map);
            }
        }
    }
}
