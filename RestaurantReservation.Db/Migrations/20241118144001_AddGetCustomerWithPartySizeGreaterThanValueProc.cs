using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddGetCustomerWithPartySizeGreaterThanValueProc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_GetCustomerWithPartySizeGreaterThanValue
                        @Value INT
                    AS BEGIN
                        SELECT cus.CustomerId AS [ID], cus.CustomerFirstName AS [First Name], cus.CustomerLastName AS [LastName], res.PartySize AS [Party Size]
                        FROM Customers cus
                        INNER JOIN Reservations res 
                            ON CustomerId = CustomerId
                        WHERE res.PartySize > @Value
                        ORDER BY res.PartySize
                    END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetCustomerWithPartySizeGreaterThanValue;");
        }
    }
}
