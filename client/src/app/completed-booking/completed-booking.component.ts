import { Component, OnInit } from '@angular/core';
import { ICompletedBooking } from '../shared/models/EntitiyInterfaces/completedBooking';
import { CompletedBookingService } from './completed-booking.service';

@Component({
  selector: 'app-completed-booking',
  templateUrl: './completed-booking.component.html',
  styleUrls: ['./completed-booking.component.scss']
})
export class CompletedBookingComponent implements OnInit{
  completedBookings: ICompletedBooking[];

  constructor(private completedBookingService: CompletedBookingService){

  }
  ngOnInit(){
    this.getCompletedBooking();
  }

  getCompletedBooking(){
    this.completedBookingService.getCompletedBookingForUser().subscribe({
      next: (completedBookings : ICompletedBooking[]) => {
        this.completedBookings = completedBookings;
      },
      error: (error) => console.log(error)
    })
  }
}
