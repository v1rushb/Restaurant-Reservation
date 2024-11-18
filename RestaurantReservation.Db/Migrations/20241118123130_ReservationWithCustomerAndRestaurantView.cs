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
                    r.ReservationId,
                    r.CustomerId,
                    c.FirstName AS CustomerFirstName,
                    c.LastName AS CustomerLastName,
                    c.PhoneNumber AS CustomerPhone,
                    r.RestaurantId,
                    res.Name AS RestaurantName,
                    res.Address AS RestaurantAddress,
                    r.ReservationDate,
                    r.TableId
                FROM Reservations r
                INNER JOIN Customers c ON r.CustomerId = c.CustomerId
                INNER JOIN Restaurants res ON r.RestaurantId = res.RestaurantId;
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
