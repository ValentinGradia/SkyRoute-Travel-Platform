import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IBookingRequest } from '../../interfaces/IBookingRequest';
import { FlightService } from '../../services/flight.service';
import { BookingService } from '../../services/booking.service';

@Component({
  selector: 'app-booking-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './booking-form.component.html',
  styleUrl: './booking-form.component.css'
})
export class BookingFormComponent implements OnInit {
  route = inject(ActivatedRoute);
  router = inject(Router);
  flightService = inject(FlightService);
  bookingService = inject(BookingService);

  bookingRequest: IBookingRequest = {
    FlightId: '',
    FlightNumber: '',
    Provider: '',
    PassengerCount: 1,
    CabinClass: 'Economy',
    PricePerPassenger: 0,
    FinalPrice: 0,
    FullName: '',
    Email: '',
    DocumentNumber: null as any
  };

  ngOnInit(): void {
    const flightNumber = this.route.snapshot.paramMap.get('flightNumber');
    
    this.route.queryParams.subscribe(params => {
        if (params['passengers']) this.bookingRequest.PassengerCount = Number(params['passengers']);
        if (params['provider']) this.bookingRequest.Provider;

        const fare = Number(params['fare']);
        if (!isNaN(fare) && this.bookingRequest.PassengerCount) {
             this.bookingRequest.FinalPrice = fare * this.bookingRequest.PassengerCount;
        }
    });

    if (flightNumber) {
      this.flightService.searchFlightByFlightNumber(flightNumber).subscribe({
      next: (data) => {
        this.bookingRequest.FlightId = data.id;
        this.bookingRequest.FlightNumber = flightNumber;
        this.bookingRequest.Provider = data.provider;
        this.bookingRequest.PricePerPassenger = this.bookingRequest.FinalPrice / this.bookingRequest.PassengerCount;
      },
      error: (err) => {
        console.error(err);
      }
    });
    }
  }

  submit(): void {
    console.log(this.bookingRequest);
    this.bookingService.createBooking(this.bookingRequest).subscribe({
      next: (data) => {
        console.log(data)
      }
    })
  }

  goBack(): void {
    this.router.navigate(['/search']);
  }
}
