using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public int? MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Id: {OrderItemId}, OrderId: {OrderId}, MenuItemId: {MenuItemId}, " +
                $"Quantity: {Quantity}";
        }
    }
}