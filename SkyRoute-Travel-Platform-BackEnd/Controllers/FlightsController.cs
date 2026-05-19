using Microsoft.AspNetCore.Mvc;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Models;
using SkyRoute_Travel_Platform_BackEnd.Services;

namespace SkyRoute_Travel_Platform_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController(FlightService _flightService) : ControllerBase
    {
        // GET api/flights/search
        [HttpGet("search")]
        public ActionResult<IEnumerable<Flight>> Search([FromQuery] FlightSearchRequestDto request)
        {
            var flights = _flightService.SearchFlights(request);
            return Ok(flights);
        }
    }
}
