export interface IBookingRequest {
	flightId: string;
	flightNumber: string;
	provider: string;
	passengerCount: number;
	cabinClass: string;
	finalPrice: number;
	fullName: string;
	email: string;
	documentNumber: number;
}
