import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BookingService } from 'src/app/booking/booking.service';
import { IBooking, ITicket } from '../../models/EntitiyInterfaces/booking';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-booking-summary',
  templateUrl: './booking-summary.component.html',
  styleUrls: ['./booking-summary.component.scss']
})
export class BookingSummaryComponent implements OnInit{
  booking$: Observable<IBooking>;
  @Output() remove: EventEmitter<ITicket> = new EventEmitter<ITicket>();
  @Input() isBooking = true;

  constructor(private bookingService: BookingService){

  }
  ngOnInit(){
    this.booking$ = this.bookingService.booking$;
  }
  removeTicketFromBooking(item: ITicket){
    this.remove.emit(item);
  }
}
