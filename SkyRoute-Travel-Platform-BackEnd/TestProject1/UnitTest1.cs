using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SkyRoute_Travel_Platform_BackEnd.Controllers;
using SkyRoute_Travel_Platform_BackEnd.Models;
using SkyRoute_Travel_Platform_BackEnd.Services;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.Providers;

namespace SkyRoute.Tests;

public class UnitTest1
{
    private readonly FlightsController _controller;
    private readonly Mock<FlightService> _mockFlightService;

    [Fact]
    public async Task Test1()
    {
        //Arrange
        string flightNumber = "GA100";
        
        //Act
        var result = await _controller.GetByFlightNumber(flightNumber);
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var flight = Assert.IsType<Flight>(okResult.Value);
        
        //Assert
        // Assert.Equal(flightNumber, flight.FlightNumber);
        // Assert.Equal("GlobalAir", flight.Provider);
        // Assert.Equal("JFK", flight.Origin);
        // Assert.Equal("LHR", flight.Destination);
        // Assert.Equal(450.00m, flight.BaseFare);
    }
}