using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class ReservationWithCustomerAndRestaurantView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW ReservationWithCustomerAndRestaurantDetails AS
                SELECT 
                    r.reservation_id,
                    r.customer_id,
                    c.first_name AS customer_first_name,
                    c.last_name AS customer_last_name,
                    c.phone_number AS customer_phone,
                    r.restaurant_id,
                    res.name AS restaurant_name,
                    res.address AS restaurant_address,
                    r.reservation_date,
                    r.table_id
                FROM Reservations r
                INNER JOIN Customers c ON r.customer_id = c.customer_id
                INNER JOIN Restaurants res ON r.restaurant_id = res.restaurant_id;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS ReservationWithCustomerAndRestaurantDetails;
            ");
        }
    }
}
