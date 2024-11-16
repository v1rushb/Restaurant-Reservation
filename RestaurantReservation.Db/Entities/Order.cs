using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int? ReservationId { get; set; }
        public Reservation? Reservation { get; set; }
        public int? EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        [Required]
        public required DateTime OrderDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public required decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; } = [];

        public override string ToString()
        {
            return $"Id: {OrderId}, ReservationId: {ReservationId}, EmployeeId: {EmployeeId}, " +
                $"OrderDate: {OrderDate}, TotalAmount: {TotalAmount}";
        }
    }
}