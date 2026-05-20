using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Models;
using SkyRoute_Travel_Platform_BackEnd.Services;

namespace SkyRoute_Travel_Platform_BackEnd.Controllers
{
    [ApiController]
    [Route("api/flights")]
    public class FlightsController(FlightService _flightService, AppDbContext _dbContext) : ControllerBase
    {
        // GET api/flights/search
        [HttpGet("search")]
        public async Task<ActionResult<List<FlightSearchResponseDto>>> Search([FromQuery] FlightSearchRequestDto request)
        {
            List<FlightSearchResponseDto> flights = await _flightService.SearchFlights(request);
            return Ok(flights);
        }

        [HttpGet("{flightNumber}")]
        public async Task<ActionResult<Flight>> GetByFlightNumber(string flightNumber)
        {
            Flight flight = await _dbContext.Flights.FirstOrDefaultAsync(f => f.FlightNumber == flightNumber);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }
    }
}
