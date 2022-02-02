using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SportsGrounds.Classes;
using SportsGrounds.Models;

namespace SportsGrounds.Controllers
{
    public class MapController : Controller
    {
        private readonly SportsGroundsContext _db;
        public MapController(SportsGroundsContext db)
        {
            _db = db;
        }
        public IActionResult Index() => View(null);

        public IActionResult GetGeoObjFromServ() => View("Index", new CRUD(_db).GetMaps());

        public IActionResult LoadGeoObjInServ()
        {

            string url = "https://search-maps.yandex.ru/v1/?text=category_id:(77500452834)&ll=38.078237,54.88628&spn=0.06,0.06&rspn=1&results=500&lang=ru_RU&apikey=b4a7ecbb-6ea1-40ba-b43d-03efb446b4a9";
            string urlTest = "https://search-maps.yandex.ru/v1/?text=category_id:(77500452834)&ll=37.61552,55.75697&spn=0.06,0.06&rspn=1&results=500&lang=ru_RU&apikey=b4a7ecbb-6ea1-40ba-b43d-03efb446b4a9";
            GetRequest request = new GetRequest(urlTest);
            request.Run();
            var response = request.Response;

            var json = JObject.Parse(response);
            var features = json["features"];
            CRUD CRUD = new CRUD(_db);
            try
            {
                foreach (var feature in features)
                {
                    var geometry = feature["geometry"];
                    var coordinates = geometry["coordinates"];
                    double Longitude = (double)coordinates[0];
                    double Latitude = (double)coordinates[1];
                    var properties = feature["properties"];
                    string name = (string)properties["name"];
                    var CompanyMetaData = properties["CompanyMetaData"];
                    string address = (string)CompanyMetaData["address"];
                    Map map = new();
                    map.Longitude = Longitude;
                    map.Latitude = Latitude;
                    map.Address = address;
                    map.Type = TypeMaps.SportGround;
                    CRUD.CreateMap(map);


                }
            }
            catch (Exception)
            {
            }

            //TODO
            return View("Index");
        }
    }
}
