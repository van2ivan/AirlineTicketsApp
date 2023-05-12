import { Component, Input, OnInit } from '@angular/core';
import { BookingService } from 'src/app/booking/booking.service';
import { IFlight } from 'src/app/shared/models/EntitiyInterfaces/flight';

@Component({
  selector: 'app-flight-item',
  templateUrl: './flight-item.component.html',
  styleUrls: ['./flight-item.component.scss']
})
export class FlightItemComponent implements OnInit{
  @Input() flight: IFlight;
  arrTime: any;
  now: any;


  constructor(private bookingService: BookingService){

  }
  ngOnInit(){
    this.arrTime = new Date(this.flight.arrivalTime)
    this.now = new Date();
  }
}
