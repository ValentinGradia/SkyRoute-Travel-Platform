import { Component, EventEmitter, inject, Output } from '@angular/core';
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
  showResults : boolean = false;
  isLoading : boolean = false;

  flights: IFlightResponse[] = []
  @Output() returnFlightsResults = new EventEmitter<IFlightResponse[]>
  
  airports = [
    { code: 'EZE', label: 'Buenos Aires (EZE), Argentina' },
    { code: 'AEP', label: 'Buenos Aires (AEP), Argentina' },
    { code: 'SCL', label: 'Santiago (SCL), Chile' },
    { code: 'LIM', label: 'Lima (LIM), Peru' },
    { code: 'MEX', label: 'Mexico City (MEX), Mexico' },
    { code: 'JFK', label: 'New York (JFK), USA' }
  ];

  cabinOptions = ['Economy', 'Business', 'FirstClass'];

  flightRequest: IFlightRequest = {
    origin: '',
    countryOrigin: '',
    destination: '',
    countryDestination: '',
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

    const originAirport = this.airports.find(a => a.code === this.flightRequest.origin);
    if (originAirport) {
      const parts = originAirport.label.split(',');
      this.flightRequest.countryOrigin = parts[parts.length - 1].trim();
    }

    const destinationAirport = this.airports.find(a => a.code === this.flightRequest.destination);
    if (destinationAirport) {
      const parts = destinationAirport.label.split(',');
      this.flightRequest.countryDestination = parts[parts.length - 1].trim();
    }
    
    this.isLoading = true;
    this.flightService.searchFlight(this.flightRequest).subscribe({
      next: (data) => {
        this.flights = data;
        this.showResults = true;
        this.isLoading = false;
      },
      error: (err) => {
        this.isLoading = false;
      }
    });
  }

}
