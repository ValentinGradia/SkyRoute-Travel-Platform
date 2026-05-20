namespace SkyRoute_Travel_Platform_BackEnd.DTOs;

public class FlightSearchResponseDto
{
    public Guid Id { get; set; }
    public string FlightNumber { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTimeOffset Departure { get; set; }
    public DateTimeOffset Arrival { get; set; }
    public TimeSpan Duration { get; set; }
    public string Provider { get; set; }

    // Only the requested cabin info
    public string CabinClass { get; set; }
    public int AvailableSeats { get; set; }
    public decimal Fare { get; set; }
}