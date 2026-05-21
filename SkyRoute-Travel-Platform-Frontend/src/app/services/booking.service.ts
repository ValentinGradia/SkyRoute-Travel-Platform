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

  createBooking(bookingRequest : IBookingRequest) : Observable<string>
  {
      return this.http.post(`${this.apiUrl}/bookings`, bookingRequest, 
        { responseType: 'text'});
  }
}
