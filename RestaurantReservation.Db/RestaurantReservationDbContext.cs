using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Extensions;

namespace RestaurantReservation.Db {
    public class RestaurantReservationDbContext : DbContext 
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;" +
                                "Initial Catalog=RestaurantReservationCore;" +
                                "User Id=SA;" +
                                "Password=RootxPassw0rd;" +
                                "Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedEntities();
            modelBuilder.OnDeleteSetNullForForeignKeys();
        }
    }
}