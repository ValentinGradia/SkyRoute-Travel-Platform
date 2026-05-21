import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IFlightRequest } from '../../interfaces/IFlightRequest';
import { IFlightResponse } from '../../interfaces/IFlightResponse';
import { CommonModule } from '@angular/common';
import { FlightResultsComponent } from '../flight-results/flight-results.component';
import { FlightService } from '../../services/flight.service';

@Component({
  selector: 'app-search-form',
  standalone: true,
  imports: [CommonModule, FormsModule, FlightResultsComponent],
  templateUrl: './search-form.component.html',
  styleUrl: './search-form.component.css'
})
export class SearchFormComponent {
  
  flightService = inject(FlightService);

  flights: IFlightResponse[] = []
  airports = [
    { code: 'EZE', label: 'Buenos Aires (EZE), Argentina' },
    { code: 'AEP', label: 'Buenos Aires (AEP), Argentina' },
    { code: 'SCL', label: 'Santiago (SCL), Chile' },
    { code: 'LIM', label: 'Lima (LIM), Peru' },
    { code: 'MEX', label: 'Mexico City (MEX), Mexico' },
    { code: 'JFK', label: 'New York (JFK), USA' }
  ];

  cabinOptions = ['Economy', 'Business', 'First Class'];

  flightRequest: IFlightRequest = {
    origin: '',
    destination: '',
    departureDate: new Date(),
    passengers: 1,
    cabin: 'Economy'
  };

  departureDateInput = '';

  submit(): void {
    if (!this.departureDateInput) {
      return;
    }

    this.flightRequest.departureDate = new Date(this.departureDateInput);

    

    this.flightService.searchFlight(this.flightRequest).subscribe({
      next: (data) => {
        this.flights = data;
        console.log(data);
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

}
