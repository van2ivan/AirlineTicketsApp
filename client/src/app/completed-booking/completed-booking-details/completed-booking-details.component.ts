import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ICompletedBooking } from 'src/app/shared/models/EntitiyInterfaces/completedBooking';
import { BreadcrumbService } from 'xng-breadcrumb';
import { CompletedBookingService } from '../completed-booking.service';

@Component({
  selector: 'app-completed-booking-details',
  templateUrl: './completed-booking-details.component.html',
  styleUrls: ['./completed-booking-details.component.scss']
})
export class CompletedBookingDetailsComponent implements OnInit{
  completedBooking: ICompletedBooking;

  constructor(private route: ActivatedRoute, private breadcrumbService: BreadcrumbService,
    private completedBookingService: CompletedBookingService){
      this.breadcrumbService.set('@YourBooking', '');

    }
  ngOnInit(){
    this.completedBookingService.getCompletedBookingDetails
    (+this.route.snapshot.paramMap.get('id'))
    .subscribe({
      next: (completedBooking: ICompletedBooking) => {
        this.completedBooking = completedBooking;
        this.breadcrumbService.set('@YourBooking', `Booking No. ${completedBooking.id} - ${completedBooking.status}`);
      },
      error: (error) => console.log(error)
    })
  }

}
