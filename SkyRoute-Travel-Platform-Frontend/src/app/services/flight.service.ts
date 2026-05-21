import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IFlightResponse } from '../interfaces/IFlightResponse';
import { IFlightRequest } from '../interfaces/IFlightRequest';

@Injectable({
  providedIn: 'root'
})
export class FlightService {

  http = inject(HttpClient);
  private apiUrl = environment.apiUrl;
  
  constructor() { }

  searchFlight(request : IFlightRequest): Observable<IFlightResponse[]>
  {
    const params = new HttpParams()
      .set('Origin', request.origin)
      .set('Destination', request.destination)
      .set('DepartureDate', new Date(request.departureDate).toISOString())
      .set('Passengers', request.passengers)
      .set('CabinClass', request.cabin); 

    return this.http.get<IFlightResponse[]>(`${this.apiUrl}/flights/search`, { params });
  }

  searchFlightByFlightNumber(request : string) : Observable<IFlightResponse>
  {
    return this.http.get<IFlightResponse>(`${this.apiUrl}/flights/${request}`);
  }
}
