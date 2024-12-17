using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Service;
using RestaurantReservation.Db.Service.Interfaces;
using RestaurantReservation.Db.Repositories.interfaces;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


builder.Services.AddScoped<RestaurantReservationDbContext>();


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<ICustomerService, CustomerService>();


app.UseHttpsRedirection();

app.Run();