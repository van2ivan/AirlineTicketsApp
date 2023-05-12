import { Component, OnInit } from '@angular/core';
import { BookingService } from './booking/booking.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'AirlineTickets';

  constructor(private bookingService: BookingService,
    private accountService: AccountService){

  }

  ngOnInit(): void {
    this.loadBooking();
    this.loadCurrentUser();
  }

  loadBooking(){
    const bookingId = localStorage.getItem('booking_id'); //persisting booking in local storage
    if(bookingId){
      this.bookingService.getBooking(bookingId).subscribe({
        next: () => console.log('Booking initialized'),
        error: (error) => console.log(error)
      })
    }
  }
  loadCurrentUser(){
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe({
      next: () => console.log('User loaded'),
      error: (error) => console.log(error)
    });

  }
}
