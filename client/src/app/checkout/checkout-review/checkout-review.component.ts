import { CdkStepper } from '@angular/cdk/stepper';
import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { BookingService } from 'src/app/booking/booking.service';
import { IBooking } from 'src/app/shared/models/EntitiyInterfaces/booking';

@Component({
  selector: 'app-checkout-review',
  templateUrl: './checkout-review.component.html',
  styleUrls: ['./checkout-review.component.scss']
})
export class CheckoutReviewComponent{
  @Input() appStepper?: CdkStepper;


  constructor(private bookingSerivce: BookingService,
    private toastr: ToastrService){

  }
  createPaymentIntent(){
    return this.bookingSerivce.createPaymentIntent().subscribe({
      next: (response: any) => {
        this.toastr.success('Payment intent created');
        this.appStepper.next();
      },
      error: (error) => {
        console.log(error)
        this.toastr.error(error.message);
      }
    })
  }
}
