export interface IFlightResponse
{
	id: string;
	flightNumber: string;
	origin: string;
	destination: string;
	departure: string;
	arrival: string;
	duration: string;
	provider: string;
	cabinClass: string;
	availableSeats: number;
	fare: number;
}