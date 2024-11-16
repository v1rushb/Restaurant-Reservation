using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }

        [Required]
        [MaxLength(75)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public required string Address { get; set; }

        [Required]
        [Phone]
        [MaxLength(10)]
        public required string PhoneNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public required string OpeningHours { get; set; }
        public List<Reservation> Reservations { get; set; } = [];

        public List<Table> Tables { get; set; } = [];

        public List<Employee> Employees { get; set; } = [];

        public List<MenuItem> MenuItems { get; set; } = [];
        
        public override string ToString()
        {
            return $"Id: {RestaurantId}, Name: {Name}, Address: {Address}, PhoneNumber: {PhoneNumber}, " +
                $"OpeningHours: {OpeningHours}";
        }
        
    }
}