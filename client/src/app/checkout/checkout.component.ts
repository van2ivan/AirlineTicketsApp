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
  bookingTotals$: Observable<IBookingTotals>
  checkoutForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private accountService: AccountService,
    private bookingService: BookingService){

  }
  ngOnInit(){
    this.createCheckoutForm();
    this.getDetailsFormValues();
    this.getLuggageOptionValue();
    this.bookingTotals$ = this.bookingService.bookingTotal$;
  }
  createCheckoutForm(){
    this.checkoutForm = this.formBuilder.group({
      detailsForm: this.formBuilder.group({
        firstName: [null, Validators.required],
        lastName: [null, Validators.required],
        passport: [null, Validators.required],
        citizenship: [null, Validators.required]
      }),
      luggageForm: this.formBuilder.group({
        luggageOption: [null, Validators.required]
      }),
      paymentForm: this.formBuilder.group({
        nameOnCard: [null, Validators.required]
      })
    });
  }

  getDetailsFormValues(){
    this.accountService.getUserDetails().subscribe({
      next: (details) => {
        if(details){
          this.checkoutForm.get('detailsForm').patchValue(details);
        }
    },
      error: (error) => {
        console.log(error);
      }
    });
  }

  getLuggageOptionValue(){
    const booking = this.bookingService.getCurrentBookingValue();
    if(booking.luggageOptionId != null){
      this.checkoutForm.get('luggageForm').get('luggageOption').patchValue(booking.luggageOptionId.toString());
    }
  }
}

