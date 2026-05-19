using Microsoft.AspNetCore.Mvc;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;

namespace SkyRoute_Travel_Platform_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController(AppDbContext _dbContext) : ControllerBase
    {
        // POST api/bookings
        [HttpPost]
        public ActionResult<BookingResponseDto> Create([FromBody] BookingRequestDto request)
        {
            // TODO: Implement booking creation logic in Phase 2
            var response = new BookingResponseDto
            {
                BookingReference = string.Empty,
                PerPassengerPrice = 0m,
                TotalPrice = 0m,
                Passengers = new List<PassengerDTO>()
            };

            return Ok(response);
        }
    }
}
