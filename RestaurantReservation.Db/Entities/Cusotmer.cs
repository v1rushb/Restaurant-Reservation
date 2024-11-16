namespace RestaurantReservation.Db.Entities {
    public class Customer {
        public int CustomerId { get; set; } // TODO: Id instead of CustomerId?
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public override string ToString() 
        {
            return $"Id: {CustomerId}, Name: {FirstName} {LastName}, " +
                $"Email: {Email}, Phone: {PhoneNumber}"; 
        }
    }

}
