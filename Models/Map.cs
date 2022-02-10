namespace SportsGrounds.Models
{
    public enum TypeMaps
    {
        SportGround,
        BasketGround,
        FootballGround,
        VolleyballGround
    }
    public class Map
    {
        public Guid Id { get; set; } 
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public TypeMaps Type { get; set; }
        public string? Address { get; set; }
        public virtual List<User> Users { get; set; } = new List<User>();
        public string PathImg { get; set; } = string.Empty;


    }
}
