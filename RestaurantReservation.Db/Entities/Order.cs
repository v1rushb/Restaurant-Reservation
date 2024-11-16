namespace RestaurantReservation.Db.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ReservationId { get; set; }
        public Reservation? Reservation { get; set; }
        public int EmployeeId { get; set; }

        public Employee? Employee { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; } = [];

        public override string ToString()
        {
            return $"Id: {OrderId}, ReservationId: {ReservationId}, EmployeeId: {EmployeeId}, " +
                $"OrderDate: {OrderDate}, TotalAmount: {TotalAmount}";
        }
    }
}