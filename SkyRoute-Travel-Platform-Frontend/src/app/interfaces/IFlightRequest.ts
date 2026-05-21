export interface IFlightRequest
{
	origin : string,
	destination : string,
	departureDate : Date,
	passengers : number,
	cabin : CabinClass
}

export type CabinClass = 'Economy' | 'Business' | 'FirstClass';