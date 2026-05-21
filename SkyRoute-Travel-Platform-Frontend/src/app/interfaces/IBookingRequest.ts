import { CabinClass } from "./IFlightRequest";

export interface IBookingRequest {
	FlightId: string;
	FlightNumber: string;
	Provider: string;
	PassengerCount: number;
	CabinClass: CabinClass;
	FinalPrice: number;
	PricePerPassenger: number,
	FullName: string;
	Email: string;
	DocumentNumber: number;
}
