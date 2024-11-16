using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities
{
    public class Table
    {
        public int TableId { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public required int Capacity { get; set; }
        public List<Reservation> Reservations { get; set; } = [];

        public override string ToString()
        {
            return $"Id: {TableId}, RestaurantId: {RestaurantId}, Capacity: {Capacity}";
        }
    }
}