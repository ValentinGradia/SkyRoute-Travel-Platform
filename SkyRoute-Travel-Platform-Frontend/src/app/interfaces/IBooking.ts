export interface IBooking {
	id: string;
	bookingReference: string;
	flightId: string;
	flightNumber: string;
	provider: string;
	cabinClass: string;
	passengerCount: number;
	perPassengerPrice: number;
	totalPrice: number;
	createdAt: string;
	fullName: string;
	email: string;
	documentNumber: number;
}
