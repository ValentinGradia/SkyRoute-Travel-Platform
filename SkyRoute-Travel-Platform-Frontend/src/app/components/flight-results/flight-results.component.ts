import { CommonModule } from '@angular/common';
import { Component, inject, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IFlightResponse } from '../../interfaces/IFlightResponse';
import { RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-flight-results',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './flight-results.component.html',
  styleUrl: './flight-results.component.css'
})
export class FlightResultsComponent {

  router = inject(Router);

  private _flights: IFlightResponse[] = [];
  
  @Input() 
  set flights(value: IFlightResponse[]) {
    this._flights = value;
    this.sortFlights();
  }
  
  get flights(): IFlightResponse[] {
    return this._flights;
  }

  @Input() passengers: number = 1;
  
  sortCriteria: 'price' | 'duration' | 'departure' = 'price';

  sortFlights(): void {
    const flightCopy = [...this._flights];
    switch (this.sortCriteria) {
      case 'price':
        flightCopy.sort((a, b) => a.fare - b.fare);
        break;
      case 'departure':
        flightCopy.sort((a, b) => new Date(a.departure).getTime() - new Date(b.departure).getTime());
        break;
      case 'duration':
        // assuming duration is formatted like "Xh Ym" or something comparable
        // doing a simple string sort might fail if "2h 30m" vs "10h 0m", so we parse it or at least use basic string comparison
        flightCopy.sort((a, b) => {
          const parseDur = (d: string) => {
            const h = parseInt(d.match(/(\d+)h/)?.[1] || '0', 10);
            const m = parseInt(d.match(/(\d+)m/)?.[1] || '0', 10);
            return h * 60 + m;
          };
          return parseDur(a.duration) - parseDur(b.duration);
        });
        break;
    }
    this._flights = flightCopy;
  }

  onSortChange(event: Event): void {
    this.sortCriteria = (event.target as HTMLSelectElement).value as 'price' | 'duration' | 'departure';
    this.sortFlights();
  }

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
