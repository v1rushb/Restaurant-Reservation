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
                    e.employee_id,
                    e.first_name,
                    e.last_name,
                    e.position,
                    e.restaurant_id,
                    res.name AS restaurant_name,
                    res.address AS restaurant_address,
                    res.phone_number AS restaurant_phone
                FROM Employees e
                INNER JOIN Restaurants res ON e.restaurant_id = res.restaurant_id;
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
