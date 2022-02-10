using SportsGrounds.Interfaces;
using SportsGrounds.Models;

namespace SportsGrounds.Classes
{
    public class CRUD : ICRUD
    {
        private readonly SportsGroundsContext _db;
        public CRUD(SportsGroundsContext db)
        {
            _db = db;
        }
        public void CreateMap(Map Map)
        {
            if(_db.Maps.FirstOrDefault(u=>(u.Longitude == Map.Longitude) && (u.Latitude == Map.Latitude)) == null)
            {
                _db.Maps.Add(Map);
                _db.SaveChanges();
            }

        }

        public void CreateUser(User User)
        {
            if (_db.Users.FirstOrDefault(u => u.NickName == User.NickName) == null)
            {
                _db.Users.Add(User);
                _db.SaveChanges();
            }
        }

        public void DeleteMap(Map Map)
        {
            if (_db.Maps.FirstOrDefault(u => u.Id == Map.Id) != null)
            {
                _db.Maps.Remove(Map);
                _db.SaveChanges();
            }
        }

        public void DeleteUser(User User)
        {
            if (_db.Users.FirstOrDefault(u => u.Id == User.Id) != null)
            {
                _db.Users.Remove(User);
                _db.SaveChanges();
            }
        }

        public Map GetMap(Guid Id)
        {
            var map = _db.Maps.FirstOrDefault(u => u.Id == Id);
            if (map!= null)
                return map;

            return null;


        }

        public List<Map> GetMaps() => _db.Maps.ToList();


        public User GetUser(Guid Id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == Convert.ToString(Id));
            if (user != null)
                return user;

            return null;

        }
        public User? GetUserToName(string name)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == name);
            if (user != null)
                return user;

            return null;

        }

        public List<User> GetUsers() => _db.Users.ToList();


        public void UpdateMap(Map Map)
        {
            if (_db.Maps.FirstOrDefault(u => u.Id == Map.Id) != null)
            {
                _db.Maps.Update(Map);
                _db.SaveChanges();
            }
        }

        public void UpdateUser(User User)
        {
            if (_db.Users.FirstOrDefault(u => u.Id == User.Id) != null)
            {
                _db.Users.Update(User);
                _db.SaveChanges();
            }
        }
    }
}
