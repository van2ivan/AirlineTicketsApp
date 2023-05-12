import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IFlightPagination } from '../shared/models/PaginationInterfaces/flightPagination';
import { IAirport } from '../shared/models/EntitiyInterfaces/airport';
import { IAirportName } from '../shared/models/EntitiyInterfaces/airportName';
import { map } from 'rxjs/operators';
import { FlightParams } from '../shared/models/flightParams';
import { IFlight } from '../shared/models/EntitiyInterfaces/flight';

@Injectable({
  providedIn: 'root'
})
export class FlightsService {

  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) { }
  getFlights(flightParams: FlightParams){

    let params = new HttpParams();

    if(flightParams.departureAirportId !== 0){
      params = params.append('departureAirportId', flightParams.departureAirportId.toString())
    }
    if(flightParams.arrivalAirportId !== 0){
      params = params.append('arrivalAirportId', flightParams.arrivalAirportId.toString())
    }
    if(flightParams.search){
      params = params.append('search', flightParams.search)
    }

    params = params.append('sort', flightParams.sort);
    params = params.append('pageIndex', flightParams.pageNumber.toString())
    params = params.append('pageIndex', flightParams.pageSize.toString())


    return this.http.get<IFlightPagination>(this.baseUrl + 'Flights', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        })
      );//pipe (wrapper) response (RxJS method) into IFlightPagination object - getting response body
      // map - one of RxJS methods
  }

  /*getCompanies(){
    return this.http.get<ICompanyName[]>(this.baseUrl + 'Companies')
  }*/
  getFlight(id: number){
    return this.http.get<IFlight>(this.baseUrl + 'flights/' + id)
  }

  getAirports(){
    return this.http.get<IAirportName[]>(this.baseUrl + 'Airports')
  }
}
