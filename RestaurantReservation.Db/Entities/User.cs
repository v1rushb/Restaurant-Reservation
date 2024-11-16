using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities {
    public class User 
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}