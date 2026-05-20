import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IFlightRequest } from '../../interfaces/IFlightRequest';

@Component({
  selector: 'app-search-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './search-form.component.html',
  styleUrl: './search-form.component.css'
})
export class SearchFormComponent {
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
  }

}
