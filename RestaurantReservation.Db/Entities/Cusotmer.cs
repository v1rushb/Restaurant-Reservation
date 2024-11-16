using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities {
    public class Customer {

        public int CustomerId { get; set; } // TODO: Id instead of CustomerId?

        [Required]
        [MaxLength(45)]
        public required string FirstName { get; set; }
        
        [Required]
        [MaxLength(45)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(85)]
        public required string Email { get; set; }

        [Required]
        [Phone]
        [MaxLength(10)]
        public required string PhoneNumber { get; set; }
        public List<Reservation> Reservations { get; set; } = [];

        public override string ToString() 
        {
            return $"Id: {CustomerId}, Name: {FirstName} {LastName}, " +
                $"Email: {Email}, Phone: {PhoneNumber}"; 
        }
    }

}
