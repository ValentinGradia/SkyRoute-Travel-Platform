import { CommonModule } from '@angular/common';
import { Component, inject, Input } from '@angular/core';
import { IFlightResponse } from '../../interfaces/IFlightResponse';
import { RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-flight-results',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './flight-results.component.html',
  styleUrl: './flight-results.component.css'
})
export class FlightResultsComponent {

  router = inject(Router);

  @Input() flights: IFlightResponse[] = [];
  @Input() passengers: number = 1;
  
  selectFlight(flight: IFlightResponse): void {
      this.router.navigate(['/bookings', flight.flightNumber], { 
        queryParams: { 
          passengers: this.passengers,
          cabinClass: flight.cabinClass,
          fare: flight.fare,
          provider: flight.provider,
        } 
      });
  }
}
