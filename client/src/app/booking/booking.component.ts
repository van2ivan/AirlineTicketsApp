import { Component, OnInit } from '@angular/core';
import { IBooking, ITicket } from '../shared/models/EntitiyInterfaces/booking';
import { Observable } from 'rxjs';
import { BookingService } from './booking.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.scss']
})
export class BookingComponent implements OnInit{
  booking$: Observable<IBooking>;

  constructor(private bookingService: BookingService){

  }
  ngOnInit(){
    this.booking$ = this.bookingService.booking$;
  }

  removeTicketFromBooking(ticket: ITicket){
    this.bookingService.removeTicketFromBooking(ticket);
  }
}
