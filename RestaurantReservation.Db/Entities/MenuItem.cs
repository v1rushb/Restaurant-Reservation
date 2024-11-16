namespace RestaurantReservation.Db.Entities
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<OrderItem> OrderItems { get; set; } = [];

        public override string ToString()
        {
            return $"Id: {MenuItemId}, RestaurantId: {RestaurantId}, Name: {Name}, " +
                $"Description: {Description}, Price: {Price}";
        }
    }
}