import { AfterViewInit, Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BookingService } from 'src/app/booking/booking.service';
import { CheckoutService } from '../checkout.service';
import { ToastrService } from 'ngx-toastr';
import { IBooking } from 'src/app/shared/models/EntitiyInterfaces/booking';
import { ICompletedBooking } from 'src/app/shared/models/EntitiyInterfaces/completedBooking';
import { NavigationExtras, Router } from '@angular/router';
import { Stripe, StripeCardCvcElement, StripeCardExpiryElement, StripeCardNumberElement, loadStripe } from '@stripe/stripe-js';

//declare var Stripe;

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss']
})
export class CheckoutPaymentComponent implements OnInit {
  @Input() checkoutForm?: FormGroup;
  @ViewChild('cardNumber') cardNumberElement?: ElementRef;
  @ViewChild('cardExpiry') cardExpiryElement?: ElementRef;
  @ViewChild('cardCvc') cardCvcElement?: ElementRef;
  stripe: Stripe | null = null;
  cardNumber?: StripeCardNumberElement;
  cardExpiry?: StripeCardExpiryElement;
  cardCvc?: StripeCardCvcElement;
  cardErrors: any;

  constructor(
    private bookingService: BookingService,
    private checkoutService: CheckoutService,
    private toastr: ToastrService,
    private router: Router) { }

  ngOnInit() {
    loadStripe('pk_test_51N5sUiDov2RUffmYnIGwMWlTrfk2erIXIJdRZG04gICvXIxaKtEI70vD2NrXO2oL1gfG8Cr00UyrUVrXg1a7d41c00imitr2tB').then(stripe => {
      this.stripe = stripe;
      const elements = stripe?.elements();
      if(elements){
        this.cardNumber = elements.create('cardNumber');
        this.cardNumber.mount(this.cardNumberElement?.nativeElement);
        this.cardNumber.on('change', event => {
          if(event.error) this.cardErrors = event.error.message;
          else this.cardErrors = null
        })

        this.cardExpiry = elements.create('cardExpiry');
        this.cardExpiry.mount(this.cardExpiryElement?.nativeElement);
        this.cardExpiry.on('change', event => {
          if(event.error) this.cardErrors = event.error.message;
          else this.cardErrors = null
        })

        this.cardCvc = elements.create('cardCvc');
        this.cardCvc.mount(this.cardCvcElement?.nativeElement);
        this.cardCvc.on('change', event => {
          if(event.error) this.cardErrors = event.error.message;
          else this.cardErrors = null
        })
      }
    });
  }

    submitCompletedBooking(){
      const booking = this.bookingService.getCurrentBookingValue();
      if(!booking) return;
      const completedBookingToCreate = this.getCompletedBookingToCreate(booking);
      if(!completedBookingToCreate) return;
      this.checkoutService.createCompletedBooking(completedBookingToCreate).subscribe({
        next: completedBooking => {
          this.toastr.success('Booking created successfully');
          this.stripe.confirmCardPayment(booking.clientSecret!, {
            payment_method: {
              card: this.cardNumber!,
              billing_details: {
                name: this.checkoutForm?.get('paymentForm')?.get('nameOnCard')?.value
              }
            }
          }).then(result => {
            console.log(result);
            if(result.paymentIntent){
              this.bookingService.deleteLocalBooking(booking.id);
              const navigationExtras: NavigationExtras = {state: completedBooking}
              this.router.navigate(['checkout/success'], navigationExtras)
            } else {
              this.toastr.error('Payment error');
            }
          });
          console.log(completedBooking);
        },
        error: (error) => {
          this.toastr.error(error.message);
          console.log(error);
        }
      });
    }
    getCompletedBookingToCreate(booking: IBooking){
      return {
        bookingId: booking.id,
        luggageOptionId: +this.checkoutForm.get('luggageForm').get('luggageOption').value,
        bookingDetails: this.checkoutForm.get('detailsForm').value
      };
    }

}
