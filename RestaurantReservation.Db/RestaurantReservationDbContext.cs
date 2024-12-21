using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Extensions;
using RestaurantReservation.Db.ViewModels;

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
        public DbSet<ReservationsWithCustomerAndRestaurants> ReservationsWithCustomerAndRestaurants { get; set; }
        public DbSet<EmployeesWithRestaurants> EmployeesWithRestaurants { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(DatabaseConstants.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedEntities(); // probs handle profiling for prod and dev envs?
            modelBuilder.OnDeleteSetNullForForeignKeys();

            modelBuilder.Entity<ReservationsWithCustomerAndRestaurants>(entity =>
                entity.HasNoKey()
                .ToView("vw_ReservationsWithCustomersAndRestaurants")
            );

            modelBuilder.Entity<EmployeesWithRestaurants>(entity =>
                entity.HasNoKey()
                .ToView("vw_EmployeesWithRestaurants")
            );

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(user => user.Id)
                    .IncludeProperties(user => user.Username);
            });
        }
    }
}