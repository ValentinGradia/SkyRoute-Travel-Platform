export interface IFlightRequest
{
	origin : string,
	countryOrigin : string,
	destination : string,
	countryDestination : string,
	departureDate : Date,
	passengers : number,
	cabin : CabinClass
}

export type CabinClass = 'Economy' | 'Business' | 'FirstClass';