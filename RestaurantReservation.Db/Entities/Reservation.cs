using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities {
    public class Reservation {
        public int ReservationId { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        
        public int? RestaurantId { get; set; }

        public Restaurant? Restaurant { get; set; }

        public int? TableId { get; set; }
        public Table? Table { get; set; }

        [Required]
        public required DateTime ReservationDate { get; set; }


        [Required]
        [Range(0, int.MaxValue)]
        public required int PartySize { get; set; }
        public List<Order> Orders { get; set; } = [];

        public override string ToString()
        {
            return $"Id: {ReservationId}, CustomerId: {CustomerId}, RestaurantId: {RestaurantId}, " +
                $"TableId: {TableId}, ReservationDate: {ReservationDate}, PartySize: {PartySize}";
        }

    }
}
