import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { IFlightResponse } from '../../interfaces/IFlightResponse';

@Component({
  selector: 'app-flight-results',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './flight-results.component.html',
  styleUrl: './flight-results.component.css'
})
export class FlightResultsComponent {
  
  @Input() flights: IFlightResponse[] = [];

  selectFlight(flight: IFlightResponse): void {
    console.log('Selected flight:', flight);
  }
}
