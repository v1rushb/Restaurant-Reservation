namespace RestaurantReservation.Db.Entities
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OpeningHours { get; set; }
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