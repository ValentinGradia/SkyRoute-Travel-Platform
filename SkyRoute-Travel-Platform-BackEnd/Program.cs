using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.Interfaces;
using SkyRoute_Travel_Platform_BackEnd.Mappers;
using SkyRoute_Travel_Platform_BackEnd.Providers;
using SkyRoute_Travel_Platform_BackEnd.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("SkyRouteDb")); // We define an in-memory database.

// Add AutoMapper
builder.Services.AddAutoMapper(config => {
    config.AddProfile<FlightMappingProfile>();
});

builder.Services.AddScoped<IFlightProvider, GlobalAirProvider>();
builder.Services.AddScoped<IFlightProvider, BudgetWindsProvider>();

builder.Services.AddScoped<IFlightService, FlightService>(); 
builder.Services.AddScoped<IBookingService, BookingService>(); 
builder.Services.AddScoped<BookingService>();// Aggregate for BookingsController
builder.Services.AddScoped<FlightService>();// Aggregate for FlightsController
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular"); //Always before redirection and authentication/authorization
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
