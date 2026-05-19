using Microsoft.AspNetCore.Mvc;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        // GET api/flights/search
        [HttpGet("search")]
        public ActionResult<IEnumerable<Flight>> Search([FromQuery] FlightSearchRequestDto request)
        {
            // TODO: Implement provider mocks and search logic in Phase 2
            return Ok(new List<Flight>());
        }
    }
}

