
namespace SkyRoute_Travel_Platform_BackEnd.DTOs
{
    public class BookingResponseDto
    {
        public string BookingReference { get; set; }
        public decimal PerPassengerPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public List<PassengerDTO> Passengers { get; set; } = new();
    }


}
