using Microsoft.AspNetCore.Identity;

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
    public class User : IdentityUser
    {
        public string? NickName { get; set; }
        public TypePlayerBasket TypeBasketPlayer { get; set; }
        public Sports SportsPlay { get; set; }
        public virtual Map? Map { get; set; }
        public DateTime? TimeToMeet { get; set; }
    }

}
