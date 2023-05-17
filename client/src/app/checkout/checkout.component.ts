import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../account/account.service';
import { BookingService } from '../booking/booking.service';
import { Observable } from 'rxjs';
import { IBookingTotals } from '../shared/models/EntitiyInterfaces/booking';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit{

  constructor(private formBuilder: FormBuilder,
    private accountService: AccountService,
    private bookingService: BookingService){

  }
  ngOnInit(): void {
    this.getDetailsFormValues();
    this.getLuggageOptionValue();
    //this.bookingTotals$ = this.bookingService.bookingTotal$;
  }

    checkoutForm = this.formBuilder.group({
      detailsForm: this.formBuilder.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        passport: ['', Validators.required],
        citizenship: ['', Validators.required]
      }),
      luggageForm: this.formBuilder.group({
        luggageOption: ['', Validators.required]
      }),
      paymentForm: this.formBuilder.group({
        nameOnCard: ['', Validators.required]
      })
    });


  getDetailsFormValues(){
    this.accountService.getUserDetails().subscribe({
      next: details => {
          details && this.checkoutForm.get('detailsForm')?.patchValue(details);

    },
      error: (error) => {
        console.log(error);
      }
    });
  }

  getLuggageOptionValue(){
    const booking = this.bookingService.getCurrentBookingValue();
    if(booking && booking.luggageOptionId){
      this.checkoutForm.get('luggageForm')?.get('luggageOption')?.patchValue(booking.luggageOptionId.toString());
    }
  }
}

