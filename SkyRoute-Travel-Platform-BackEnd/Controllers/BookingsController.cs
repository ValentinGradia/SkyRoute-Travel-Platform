using Microsoft.AspNetCore.Mvc;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Services;

namespace SkyRoute_Travel_Platform_BackEnd.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController(BookingService bookingService) : ControllerBase
    {
        // POST api/bookings
        [HttpPost]
        public ActionResult<string> Create([FromBody] BookingRequestDto request)
        {
            string bookingReference = bookingService.CreateBookingAsync(request).Result;

            return Ok(bookingReference);
        }
    }
}
