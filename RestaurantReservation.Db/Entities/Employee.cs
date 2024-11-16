namespace RestaurantReservation.Db.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public List<Order> Orders { get; set; } = [];

        public override string ToString()
        {
            return $"Id: {EmployeeId}, Name: {FirstName} {LastName}, Restaurant Id: " +
                $"{RestaurantId} Position: {Position}";
        }
    }
}