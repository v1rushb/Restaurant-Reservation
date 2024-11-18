using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantRevenueFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE FUNCTION fn_RestaurantRevenue (@restaurantId INT)
                RETURNS DECIMAL(18, 2)
                AS
                BEGIN
                    RETURN (
                        SELECT COALESCE(SUM(mi.Price * oi.Quantity), 0)
                        FROM Reservations r
                        JOIN Orders o ON r.ReservationId = o.ReservationId
                        JOIN OrderItems oi ON o.OrderId = oi.OrderId
                        JOIN MenuItems mi ON oi.MenuItemId = mi.MenuItemId
                        WHERE r.RestaurantId = @restaurantId
                    )
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
