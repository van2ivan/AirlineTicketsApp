import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { IFlight } from 'src/app/shared/models/EntitiyInterfaces/flight';
import { FlightsService } from '../flights.service';
import { ActivatedRoute } from '@angular/router';
import { Breadcrumb } from 'xng-breadcrumb/lib/types/breadcrumb';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BookingService } from 'src/app/booking/booking.service';
import { MapInfoWindow, MapMarker } from '@angular/google-maps';
import { Time } from '@angular/common';

@Component({
  selector: 'app-flight-details',
  templateUrl: './flight-details.component.html',
  styleUrls: ['./flight-details.component.scss']
})
export class FlightDetailsComponent implements OnInit {
  flag: boolean = true;
  depFlag: boolean = true;
  arrFlag: boolean = true;
  totalMinutes: number;
  routeLongtitude: number;
  routeLatitude: number;
  minutesLeft: number;
  hours: number;
  minutes: number;
  seconds: number;
  days: number;
  display: any;
  marker: MapMarker;
  center: google.maps.LatLngLiteral = {lat: 24, lng: 12};
  zoom = 6;
  flightMarkerOptions: google.maps.MarkerOptions = { draggable: false, icon:"../../../assets/images/marker.png"  };
  airportMarkerOptions: google.maps.MarkerOptions = { draggable: false, icon:"../../../assets/images/airport.png"  };
  flightPosition: google.maps.LatLngLiteral[] = [];
  airportPositions: google.maps.LatLngLiteral[] = [];


  @Input() flight: IFlight;
  @ViewChild(MapInfoWindow) infoWindow: MapInfoWindow | undefined;


  constructor(private flightsService: FlightsService, private activatedRoute: ActivatedRoute,
    private bcService: BreadcrumbService, private bookingService: BookingService){

  }

  ngOnInit(){
    this.loadFlight()

  }

  loadFlight(){
    this.flightsService.getFlight(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe({
      next: (flight) => {
        this.flight = flight;
        let flightDetails = "Your flight details"
        this.bcService.set('@flightDetails', flightDetails);
        this.getFlightInfo();
        this.addMarker();
      },
      error: (error) => console.log(error)
  });
  }

  addTicketToBooking(){
    this.bookingService.addTicketToBooking(this.flight);
  }


  route: google.maps.LatLngLiteral[] = [

  ]

  addMarker(){
    this.flightPosition.push({lat: this.routeLatitude, lng: this.routeLongtitude});
    this.airportPositions.push({lat: this.flight.departureAirport.latitude, lng: this.flight.departureAirport.longtitude},
      {lat: this.flight.arrivalAirport.latitude, lng: this.flight.arrivalAirport.longtitude})
  }

  moveMap(event: google.maps.MapMouseEvent){
    if(event.latLng != null)
    this.center = (event.latLng.toJSON());
  }
  move(event: google.maps.MapMouseEvent){
    if(event.latLng != null)
    this.display = event.latLng.toJSON();
  }

  openInfoWindow(marker: MapMarker){
    if(this.infoWindow != undefined){
      this.getFlightInfo();
      this.infoWindow.open(marker);
    }
  }

  getFlightInfo() {

    const now = new Date();

    const departure = new Date(this.flight.departureTime);
    let startTime = departure.getTime();
    let depTime = departure.getTime();

    if(now.getTime() > startTime){
      this.flag = false;
      startTime = now.getTime();
    }
    if(now.getTime() < depTime) this.depFlag = false;

    const arrival  = new Date(this.flight.arrivalTime);
    let arrTime = arrival.getTime();
    let totalFlightTime = Math.abs(arrTime - depTime);
    let flightTime = Math.abs(arrTime - startTime);

    this.days = Math.floor((flightTime) / (1000 * 60 * 60 * 24));
    this.hours = Math.floor((flightTime % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    this.minutes = Math.floor((flightTime % (1000 * 60 * 60)) / (1000 * 60));
    this.seconds = Math.floor((flightTime % (1000 * 60)) / 1000);

    this.totalMinutes = Math.floor((totalFlightTime % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)) * 60 +
      Math.floor((totalFlightTime % (1000 * 60 * 60)) / (1000 * 60));
    this.minutesLeft = this.hours * 60 + this.minutes;


    this.routeLatitude = this.flight.arrivalAirport.latitude - this.flight.departureAirport.latitude;
    this.routeLongtitude = this.flight.arrivalAirport.longtitude - this.flight.departureAirport.longtitude;

    let routePartCompleted = (this.totalMinutes -this.minutesLeft) / this.totalMinutes;

    this.routeLatitude = this.routeLatitude * routePartCompleted + this.flight.departureAirport.latitude;
    this.routeLongtitude = this.routeLongtitude * routePartCompleted + this.flight.departureAirport.longtitude;
    this.center = {lat: this.routeLatitude, lng: this.routeLongtitude }

    if(arrival < now) this.arrFlag = false;
  }
}





