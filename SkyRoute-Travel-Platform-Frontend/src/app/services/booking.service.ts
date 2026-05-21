import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IBookingRequest } from '../interfaces/IBookingRequest';
import { IBooking } from '../interfaces/IBooking';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  private apiUrl = environment.apiUrl;

  constructor(private http : HttpClient) { }

  createBooking(bookingRequest : IBookingRequest) : Observable<IBooking>
  {
    const params = new HttpParams()
      .set('flightId', bookingRequest.flightId)
      .set('flightNumber', bookingRequest.flightNumber)
      .set('provider', bookingRequest.provider)
      .set('passengerCount', bookingRequest.passengerCount.toString())
      .set('cabinClass', bookingRequest.cabinClass)
      .set('finalPrice', bookingRequest.finalPrice.toString())
      .set('fullName', bookingRequest.fullName)
      .set('email', bookingRequest.email)
      .set('documentNumber', bookingRequest.documentNumber.toString());

      return this.http.post<IBooking>(`${this.apiUrl}/bookings`, { params });
  }
}
