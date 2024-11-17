using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Extensions {
    public static class DatabaseSeed 
    {
        private static readonly DateTime _today = DateTime.Today;
        public static void SeedEntities(this ModelBuilder modelBuilder) {
            SeedCustomers(modelBuilder);
            SeedRestaurants(modelBuilder);
            SeedTables(modelBuilder);
            SeedEmployees(modelBuilder);
            SeedMenuItems(modelBuilder);
            SeedReservations(modelBuilder);
            SeedOrders(modelBuilder);
            SeedOrderItems(modelBuilder);
        }

        private static void SeedCustomers(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "Bashar", LastName = "Herbawi", Email = "cs.bashar.herbawi@gmail.com", PhoneNumber = "0592696336" },
                new Customer { CustomerId = 2, FirstName = "Ali", LastName = "Hassan", Email = "ali.hassan@example.com", PhoneNumber = "0591234567" },
                new Customer { CustomerId = 3, FirstName = "Obada", LastName = "Khalil", Email = "obada.khalil@example.com", PhoneNumber = "0592345678" },
                new Customer { CustomerId = 4, FirstName = "Omar", LastName = "Abdullah", Email = "omar.abdullah@example.com", PhoneNumber = "0593456789" },
                new Customer { CustomerId = 5, FirstName = "Omar", LastName = "Herbawi", Email = "omar.herbawi@example.com", PhoneNumber = "0594567890" }
            );
        }

        private static void SeedRestaurants(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { RestaurantId = 1, Name = "Al Quds Restaurant", Address = "Ramallah", PhoneNumber = "02-2987654", OpeningHours = "9:00 - 22:00" },
                new Restaurant { RestaurantId = 2, Name = "Nablus Delights", Address = "Nablus", PhoneNumber = "09-2345678", OpeningHours = "10:00 - 23:00" },
                new Restaurant { RestaurantId = 3, Name = "Hebron Grill", Address = "Hebron", PhoneNumber = "02-2298765", OpeningHours = "8:00 - 20:00" },
                new Restaurant { RestaurantId = 4, Name = "Gaza Seafood", Address = "Gaza City", PhoneNumber = "08-2887654", OpeningHours = "11:00 - 23:00" },
                new Restaurant { RestaurantId = 5, Name = "Jericho Oasis", Address = "Jericho", PhoneNumber = "02-2323456", OpeningHours = "9:00 - 21:00" }
            );
        }

        private static void SeedTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, RestaurantId = 1, Capacity = 4 },
                new Table { TableId = 2, RestaurantId = 1, Capacity = 6 },
                new Table { TableId = 3, RestaurantId = 2, Capacity = 2 },
                new Table { TableId = 4, RestaurantId = 3, Capacity = 8 },
                new Table { TableId = 5, RestaurantId = 4, Capacity = 10 }
            );
        }

        private static void SeedEmployees(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, RestaurantId = 1, FirstName = "Khaled", LastName = "Ahmad", Position = "Manager" },
                new Employee { EmployeeId = 2, RestaurantId = 2, FirstName = "Ahmad", LastName = "Salem", Position = "Chef" },
                new Employee { EmployeeId = 3, RestaurantId = 3, FirstName = "Obayd", LastName = "Ali", Position = "Waiter" },
                new Employee { EmployeeId = 4, RestaurantId = 4, FirstName = "Samir", LastName = "Zayed", Position = "Accountant" },
                new Employee { EmployeeId = 5, RestaurantId = 5, FirstName = "Omar", LastName = "Hassan", Position = "Manager" }
            );
        }

        private static void SeedMenuItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { MenuItemId = 1, RestaurantId = 1, Name = "Musakhan", Description = "Chicken with onions and sumac on taboon bread", Price = 20 },
                new MenuItem { MenuItemId = 2, RestaurantId = 2, Name = "Kanafeh", Description = "Sweet cheese pastry", Price = 15 },
                new MenuItem { MenuItemId = 3, RestaurantId = 3, Name = "Maqluba", Description = "Upside-down rice and vegetable dish", Price = 18 },
                new MenuItem { MenuItemId = 4, RestaurantId = 4, Name = "Sayadiyah", Description = "Fish with rice and spices", Price = 25 },
                new MenuItem { MenuItemId = 5, RestaurantId = 5, Name = "Falafel Sandwich", Description = "Classic Palestinian falafel wrap", Price = 5 }
            );
        }

        private static void SeedReservations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationId = 1, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = _today, PartySize = 4 },
                new Reservation { ReservationId = 2, CustomerId = 2, RestaurantId = 2, TableId = 3, ReservationDate = _today.AddHours(1), PartySize = 2 },
                new Reservation { ReservationId = 3, CustomerId = 3, RestaurantId = 3, TableId = 4, ReservationDate = _today.AddHours(2), PartySize = 6 },
                new Reservation { ReservationId = 4, CustomerId = 4, RestaurantId = 4, TableId = 5, ReservationDate = _today.AddHours(3), PartySize = 8 },
                new Reservation { ReservationId = 5, CustomerId = 5, RestaurantId = 5, TableId = 5, ReservationDate = _today.AddHours(5), PartySize = 5 }
            );
        }

        private static void SeedOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, ReservationId = 1, EmployeeId = 1, OrderDate = _today.AddHours(2), TotalAmount = 80 },
                new Order { OrderId = 2, ReservationId = 2, EmployeeId = 2, OrderDate = _today.AddHours(4), TotalAmount = 30 },
                new Order { OrderId = 3, ReservationId = 3, EmployeeId = 3, OrderDate = _today.AddHours(6), TotalAmount = 108 },
                new Order { OrderId = 4, ReservationId = 4, EmployeeId = 4, OrderDate = _today.AddHours(8), TotalAmount = 200 },
                new Order { OrderId = 5, ReservationId = 5, EmployeeId = 5, OrderDate = _today.AddHours(10), TotalAmount = 125 }
            );
        }

        private static void SeedOrderItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, MenuItemId = 1, Quantity = 4 },
                new OrderItem { OrderItemId = 2, OrderId = 2, MenuItemId = 2, Quantity = 2 },
                new OrderItem { OrderItemId = 3, OrderId = 3, MenuItemId = 3, Quantity = 6 },
                new OrderItem { OrderItemId = 4, OrderId = 4, MenuItemId = 4, Quantity = 8 },
                new OrderItem { OrderItemId = 5, OrderId = 5, MenuItemId = 5, Quantity = 5 }
            );
        }
    }
}
