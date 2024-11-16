using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int? RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; } // check later

        [Required]
        [MaxLength(45)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(45)]
        public required string LastName { get; set; }

        [Required]
        [MaxLength(45)]
        public required string Position { get; set; }
        public List<Order> Orders { get; set; } = [];

        public override string ToString()
        {
            return $"Id: {EmployeeId}, Name: {FirstName} {LastName}, Restaurant Id: " +
                $"{RestaurantId} Position: {Position}";
        }
    }
}