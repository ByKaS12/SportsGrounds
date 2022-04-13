using Newtonsoft.Json.Linq;
using SportsGrounds.Models;

namespace SportsGrounds.Classes
{
    public class ParserYandex
    {
        public GetRequest request;
        List<Map> maps;

        public ParserYandex()
        {
            maps = new List<Map>();
        }
        public void Parse()
        {
            string url = "https://search-maps.yandex.ru/v1/?text=category_id:(77500452834)&ll=38.078237,54.88628&spn=0.06,0.06&rspn=1&results=500&lang=ru_RU&apikey=b4a7ecbb-6ea1-40ba-b43d-03efb446b4a9";
            request = new GetRequest(url);
            request.Run();
            var response = request.Response;

            var json = JObject.Parse(response);
            var features = json["features"];
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
                    maps.Add(map);
                }
            }
            catch (Exception) { }  
        }
    }
}
