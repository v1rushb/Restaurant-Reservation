namespace RestaurantReservation.Db.Entities
{
    public class Table
    {
        public int TableId { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        public int Capacity { get; set; }
        public List<Reservation> Reservations { get; set; } = [];

        public override string ToString()
        {
            return $"Id: {TableId}, RestaurantId: {RestaurantId}, Capacity: {Capacity}";
        }
    }
}