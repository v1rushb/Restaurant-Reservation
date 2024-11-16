using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        [Required]
        [MaxLength(75)]
        public required string Name { get; set; }

        [MaxLength(700)]
        public string? Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public required decimal Price { get; set; }
        public List<OrderItem> OrderItems { get; set; } = [];

        public override string ToString()
        {
            return $"Id: {MenuItemId}, RestaurantId: {RestaurantId}, Name: {Name}, " +
                $"Description: {Description}, Price: {Price}";
        }
    }
}