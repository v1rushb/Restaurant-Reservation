using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeRestaurantDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW EmployeeRestaurantDetails AS
                SELECT 
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.Position,
                    e.RestaurantId,
                    res.Name AS RestaurantName,
                    res.Address AS RestaurantAddress,
                    res.PhoneNumber AS RestaurantPhone
                FROM Employees e
                INNER JOIN Restaurants res ON e.RestaurantId = res.RestaurantId;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS EmployeeRestaurantDetails;"
            );
        }
    }
}
