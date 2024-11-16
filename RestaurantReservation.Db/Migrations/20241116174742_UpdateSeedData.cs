using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "cs.bashar.herbawi@gmail.com", "Bashar", "Herbawi", "0592696336" },
                    { 2, "ali.hassan@example.com", "Ali", "Hassan", "0591234567" },
                    { 3, "obada.khalil@example.com", "Obada", "Khalil", "0592345678" },
                    { 4, "omar.abdullah@example.com", "Omar", "Abdullah", "0593456789" },
                    { 5, "omar.herbawi@example.com", "Omar", "Herbawi", "0594567890" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Ramallah", "Al Quds Restaurant", "9:00 - 22:00", "02-2987654" },
                    { 2, "Nablus", "Nablus Delights", "10:00 - 23:00", "09-2345678" },
                    { 3, "Hebron", "Hebron Grill", "8:00 - 20:00", "02-2298765" },
                    { 4, "Gaza City", "Gaza Seafood", "11:00 - 23:00", "08-2887654" },
                    { 5, "Jericho", "Jericho Oasis", "9:00 - 21:00", "02-2323456" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "Ahmad", "Suleiman", "password123", "ahmad_s" },
                    { 2, "Omar", "Yassin", "password123", "omar_y" },
                    { 3, "Yousef", "Khatib", "password123", "yousef_k" },
                    { 4, "Ali", "Zayed", "password123", "ali_z" },
                    { 5, "Omar", "Herbawi", "password123", "omar_h" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Khaled", "Ahmad", "Manager", 1 },
                    { 2, "Ahmad", "Salem", "Chef", 2 },
                    { 3, "Obayd", "Ali", "Waiter", 3 },
                    { 4, "Samir", "Zayed", "Accountant", 4 },
                    { 5, "Omar", "Hassan", "Manager", 5 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Chicken with onions and sumac on taboon bread", "Musakhan", 20m, 1 },
                    { 2, "Sweet cheese pastry", "Kanafeh", 15m, 2 },
                    { 3, "Upside-down rice and vegetable dish", "Maqluba", 18m, 3 },
                    { 4, "Fish with rice and spices", "Sayadiyah", 25m, 4 },
                    { 5, "Classic Palestinian falafel wrap", "Falafel Sandwich", 5m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 6, 1 },
                    { 3, 2, 2 },
                    { 4, 8, 3 },
                    { 5, 10, 4 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), 1, 1 },
                    { 2, 2, 2, new DateTime(2024, 11, 16, 1, 0, 0, 0, DateTimeKind.Local), 2, 3 },
                    { 3, 3, 6, new DateTime(2024, 11, 16, 2, 0, 0, 0, DateTimeKind.Local), 3, 4 },
                    { 4, 4, 8, new DateTime(2024, 11, 16, 3, 0, 0, 0, DateTimeKind.Local), 4, 5 },
                    { 5, 5, 5, new DateTime(2024, 11, 16, 5, 0, 0, 0, DateTimeKind.Local), 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 16, 2, 0, 0, 0, DateTimeKind.Local), 1, 80m },
                    { 2, 2, new DateTime(2024, 11, 16, 4, 0, 0, 0, DateTimeKind.Local), 2, 30m },
                    { 3, 3, new DateTime(2024, 11, 16, 6, 0, 0, 0, DateTimeKind.Local), 3, 108m },
                    { 4, 4, new DateTime(2024, 11, 16, 8, 0, 0, 0, DateTimeKind.Local), 4, 200m },
                    { 5, 5, new DateTime(2024, 11, 16, 10, 0, 0, 0, DateTimeKind.Local), 5, 125m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "MenuItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 4 },
                    { 2, 2, 2, 2 },
                    { 3, 3, 3, 6 },
                    { 4, 4, 4, 8 },
                    { 5, 5, 5, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4);
        }
    }
}
