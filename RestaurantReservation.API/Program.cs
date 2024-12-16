using RestaurantReservation.Db;
using RestaurantReservation.Db.Service;
using RestaurantReservation.Db.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddScoped<RestaurantReservationDbContext>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

app.UseHttpsRedirection();

app.Run();