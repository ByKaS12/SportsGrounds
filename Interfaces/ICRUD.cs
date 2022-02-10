using SportsGrounds.Models;

namespace SportsGrounds.Interfaces
{
    public interface ICRUD
    {
        public void CreateMap(Map map);
        public void UpdateMap(Map map);
        public void DeleteMap(Map map);
        public Map GetMap(Guid Id);
        public List<Map> GetMaps();
        public void CreateUser(User User);
        public void UpdateUser(User User);
        public void DeleteUser(User User);
        public User GetUser(Guid Id);
        public User? GetUserToName(string name);
        public List<User> GetUsers();
        
        
    }
}
