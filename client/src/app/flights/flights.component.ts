import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FlightsService } from './flights.service';
import { IFlight } from '../shared/models/EntitiyInterfaces/flight';
import { ICompany } from '../shared/models/EntitiyInterfaces/companyName';
import { IAirportName } from '../shared/models/EntitiyInterfaces/airportName';
import { FlightParams } from '../shared/models/flightParams';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.scss']
})
export class FlightsComponent implements OnInit{
  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  flights: IFlight[];
  airports: IAirportName[];
  companies: ICompany[];
  flightParams = new FlightParams();
  totalCount: number;

  sortOptions = [
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'},
    {name: 'Departure Ariport A-Z', value: 'departureAirportNameAsc'},
    {name: 'Departure Ariport Z-A', value: 'departureAirportNameDesc'},
    {name: 'Arrival Ariport A-Z', value: 'arrivalAirportNameAsc'},
    {name: 'Arrival Ariport Z-A', value: 'arrivalAirportNameDesc'},
    {name: 'Departure Date: Soon', value: 'departureTimeAsc'},
    {name: 'Departure Date: Later', value: 'departureTimeDesc'},
  ];


  constructor(private flightService: FlightsService) { }

  ngOnInit(){
    this.getFlights();
    this.getAirports();
    //this.getCompanies();
  }

  getFlights(){

    this.flightService.getFlights(this.flightParams)
    .subscribe({
      next: (response) => {
        this.flights = response.data
        this.flightParams.pageNumber = response.pageIndex,
        this.flightParams.pageSize = response.pageSize
        this.totalCount = response.count
      },
      error: (error) => console.log(error)
    })
  }

  /*getCompanies(){
    this.flightService.getCompanies().subscribe({
      next: (response) => this.companies = response,
      error: (error) => console.log(error)
    })
  }*/

  getAirports(){
    this.flightService.getAirports().subscribe({
      next: (response) => this.airports = [{id: 0, name: "All"}, ...response],
      error: (error) => console.log(error)
    })
  }

  onDepartureAirportSelected(departureAirportId: number){
       this.flightParams.departureAirportId = departureAirportId;
       this.flightParams.pageNumber = 1;
       this.getFlights();
    }

  onArrivalAirportSelected(arrivalAirportId: number){
        this.flightParams.arrivalAirportId = arrivalAirportId;
        this.flightParams.pageNumber = 1;
        this.getFlights();
    }

  onSortSelected(sort: string){
    this.flightParams.sort = sort;
    this.getFlights();
  }

  onPageChanged(event: any){
    if(this.flightParams.pageNumber !== event){
      this.flightParams.pageNumber = event;
      this.getFlights();
    }
  }

  onSearch(){
    this.flightParams.search = this.searchTerm.nativeElement.value;
    this.flightParams.pageNumber = 1;
    this.getFlights();
  }

  onReset(){
    this.searchTerm.nativeElement.value = '';
    this.flightParams = new FlightParams();
    this.getFlights();
  }
}
