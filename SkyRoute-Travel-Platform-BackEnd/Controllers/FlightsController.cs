using Microsoft.AspNetCore.Mvc;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Models;
using SkyRoute_Travel_Platform_BackEnd.Services;

namespace SkyRoute_Travel_Platform_BackEnd.Controllers
{
    [ApiController]
    [Route("api/flights")]
    public class FlightsController(FlightService _flightService) : ControllerBase
    {
        // GET api/flights/search
        [HttpGet("search")]
        public async Task<ActionResult<List<Flight>>> Search([FromQuery] FlightSearchRequestDto request)
        {
            List<Flight> flights = await _flightService.SearchFlights(request);
            return Ok(flights);
        }
    }
}
