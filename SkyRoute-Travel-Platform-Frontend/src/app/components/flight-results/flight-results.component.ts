import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { IFlightResponse } from '../../interfaces/IFlightResponse';

@Component({
  selector: 'app-flight-results',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './flight-results.component.html',
  styleUrl: './flight-results.component.css'
})
export class FlightResultsComponent {
  flights: IFlightResponse[] = [
    {
      id: 'a2f3b1f4-5a5e-4ad8-8f4b-1a2b3c4d5e6f',
      flightNumber: 'SK-101',
      origin: 'EZE',
      destination: 'SCL',
      departure: '2026-06-10T09:30:00-03:00',
      arrival: '2026-06-10T11:45:00-04:00',
      duration: '02:15',
      provider: 'SkyRoute',
      cabinClass: 'Economy',
      availableSeats: 5,
      fare: 220.5
    },
    {
      id: 'b7c8d9e0-1f23-4a56-8b90-1234567890ab',
      flightNumber: 'SK-214',
      origin: 'AEP',
      destination: 'LIM',
      departure: '2026-06-12T14:10:00-03:00',
      arrival: '2026-06-12T17:35:00-05:00',
      duration: '04:25',
      provider: 'SkyRoute',
      cabinClass: 'Business',
      availableSeats: 2,
      fare: 540.0
    },
    {
      id: 'c0ffee00-1234-5678-90ab-abcdef123456',
      flightNumber: 'SK-330',
      origin: 'MEX',
      destination: 'JFK',
      departure: '2026-06-15T07:00:00-06:00',
      arrival: '2026-06-15T13:25:00-04:00',
      duration: '05:25',
      provider: 'SkyRoute',
      cabinClass: 'First Class',
      availableSeats: 1,
      fare: 980.99
    }
  ];

  selectFlight(flight: IFlightResponse): void {
    console.log('Selected flight:', flight);
  }
}
