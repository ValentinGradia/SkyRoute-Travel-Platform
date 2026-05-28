using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SkyRoute_Travel_Platform_BackEnd.Controllers;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Enums;
using SkyRoute_Travel_Platform_BackEnd.Interfaces;
using SkyRoute_Travel_Platform_BackEnd.Models;
using SkyRoute_Travel_Platform_BackEnd.Providers;
using SkyRoute_Travel_Platform_BackEnd.Services;

namespace TestProject1;

public class UnitTest1
{
    private readonly Mock<IFlightService> _mockFlightService;
    private FlightsController _flightsController;
    private readonly AppDbContext _dbContext;

    public UnitTest1()
    {
        // Use a unique in-memory database for each test to ensure isolation
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _dbContext = new AppDbContext(options);
        
        _mockFlightService = new Mock<IFlightService>();
        //each test can override this setup if needed
        _mockFlightService
            .Setup(s => s.SearchFlights(It.IsAny<FlightSearchRequestDto>()))
            .ReturnsAsync(new List<FlightSearchResponseDto>());
        
        _flightsController = new FlightsController(_mockFlightService.Object, _dbContext);
    }

    [Fact]
    public async Task GetByFlightNumber_ReturnsNotFound_WhenFlightDoesNotExist()
    {
        // Arrange
        string flightNumber = "INVALID123";

        // Act
        var result = await _flightsController.GetByFlightNumber(flightNumber);
        
        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
    
    [Fact]
    public async Task GetBySearchRequest_ReturnsFlight_WhenFlightExists()
    {
        FlightSearchRequestDto searchRequestDto = new FlightSearchRequestDto()
        {
            Origin = "AEP",
            CountryOrigin = "Argentina",
            Destination = "MEX",
            CountryDestination = "Mexico",
            DepartureDate = new DateTimeOffset(2026, 5, 29, 10, 0, 0, TimeSpan.Zero),
            Passengers = 1,
            CabinClass = CabinClass.Economy
        };
        
        FlightSearchResponseDto expectedFlight = new FlightSearchResponseDto()
        {
            Provider = "GlobalAir",
            FlightNumber = "BW200",
            Origin = "AEP",
            CountryOrigin = "Argentina",
            Destination = "MEX",
            CountryDestination = "Mexico",
            Departure = new DateTimeOffset(2026, 5, 29, 10, 0, 0, TimeSpan.Zero),
            Arrival = new DateTimeOffset(2026, 5, 29, 17, 0, 0, TimeSpan.Zero),
            Duration = TimeSpan.FromHours(7),
            CabinClass = "Economy",
            AvailableSeats = 150,
            Fare = 320.50m
        };
        
        List<FlightSearchResponseDto> expectedFlights = new List<FlightSearchResponseDto> { expectedFlight };
        
        _mockFlightService
            .Setup(s => s.SearchFlights(searchRequestDto))
            .ReturnsAsync(expectedFlights);
        
        // Act
        var result = await _flightsController.Search(searchRequestDto);
        
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var actualFlights = Assert.IsType<List<FlightSearchResponseDto>>(okResult.Value);
        Assert.Single(actualFlights);
        Assert.Equal(expectedFlight.FlightNumber, actualFlights[0].FlightNumber);
    }
}