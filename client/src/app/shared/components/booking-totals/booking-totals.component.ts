import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/booking/booking.service';
import { IBookingTotals } from '../../models/EntitiyInterfaces/booking';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-booking-totals',
  templateUrl: './booking-totals.component.html',
  styleUrls: ['./booking-totals.component.scss']
})
export class BookingTotalsComponent implements OnInit{
  bookingTotal$: Observable<IBookingTotals>;

  constructor(private bookingService: BookingService){

  }
  ngOnInit(){
    this.bookingTotal$ = this.bookingService.bookingTotal$;
  }
}
