namespace SportsGrounds.Models
{
   public enum TypePlayerBasket
    {
        PointGuard,
        ShootingGuard,
        SmallForward,
        PowerForward,
        Center

    }
    public enum Sports
    {
        BasketBall,
        Football,
        Volleyball,
        Other
    }
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? NickName { get; set; }
        public TypePlayerBasket TypeBasketPlayer { get; set; }
    }

}
