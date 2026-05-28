export interface IFlightResponse
{
	id: string;
	flightNumber: string;
	origin: string;
	countryOrigin: string,
	destination: string;
	countryDestination: string,
	departure: string;
	arrival: string;
	duration: string;
	provider: string;
	cabinClass: string;
	availableSeats: number;
	fare: number;
}