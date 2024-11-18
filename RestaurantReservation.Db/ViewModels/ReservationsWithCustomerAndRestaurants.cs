namespace RestaurantReservation.Db.ViewModels 
{
    public class ReservationsWithCustomerAndRestaurants
    {
        public int? ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }

        public int? CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int? RestaurantId { get; set; }

        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantPhoneNumber { get; set; }
        public string RestaurantOpeningHours { get; set; }

        public override string ToString()
        {
            return $"ReservationId: {ReservationId}" +
                $"ReservationDate: {ReservationDate}, PartySize: {PartySize}, " +
                $"CustomerId: {CustomerId}, CustomerFirstName: {CustomerFirstName}, " +
                $"CustomerLastName: {CustomerLastName}, CustomerEmail: {CustomerEmail}, " +
                $"CustomerPhoneNumber: {CustomerPhoneNumber}, RestaurantId: {RestaurantId}, " +
                $"RestaurantName: {RestaurantName}, RestaurantAddress: {RestaurantAddress}, " +
                $"RestaurantPhoneNumber: {RestaurantPhoneNumber}, " +
                $"RestaurantOpeningHours: {RestaurantOpeningHours}";
        }
    }
}