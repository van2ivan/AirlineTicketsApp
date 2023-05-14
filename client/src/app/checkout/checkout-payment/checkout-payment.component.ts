import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import { loadStripe, Stripe, StripeCardCvcElement, StripeCardExpiryElement, StripeCardNumberElement } from '@stripe/stripe-js';
import { ToastrService } from 'ngx-toastr';
import { firstValueFrom } from 'rxjs';
import { CheckoutService } from '../checkout.service';
import { ICompletedBookingToCreate } from 'src/app/shared/models/EntitiyInterfaces/completedBooking';
import { IBooking } from 'src/app/shared/models/EntitiyInterfaces/booking';
import { BookingService } from 'src/app/booking/booking.service';
import { IUserDetails } from 'src/app/shared/models/EntitiyInterfaces/user';

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
  cardNumberComplete = false;
  cardExpiryComplete = false;
  cardCvcComplete = false;
  cardErrors: any;
  loading = false;

  constructor(private bookingService: BookingService, private checkoutService: CheckoutService,
      private toastr: ToastrService, private router: Router) {}

  ngOnInit(): void {
    loadStripe('pk_test_51N5sUiDov2RUffmYnIGwMWlTrfk2erIXIJdRZG04gICvXIxaKtEI70vD2NrXO2oL1gfG8Cr00UyrUVrXg1a7d41c00imitr2tB').then(stripe => {
      this.stripe = stripe;
      const elements = stripe?.elements();
      if (elements) {
        this.cardNumber = elements.create('cardNumber');
        this.cardNumber.mount(this.cardNumberElement?.nativeElement);
        this.cardNumber.on('change', event => {
          this.cardNumberComplete = event.complete;
          if (event.error) this.cardErrors = event.error.message;
          else this.cardErrors = null;
        })

        this.cardExpiry = elements.create('cardExpiry');
        this.cardExpiry.mount(this.cardExpiryElement?.nativeElement);
        this.cardExpiry.on('change', event => {
          this.cardExpiryComplete = event.complete;
          if (event.error) this.cardErrors = event.error.message;
          else this.cardErrors = null;
        })

        this.cardCvc = elements.create('cardCvc');
        this.cardCvc.mount(this.cardCvcElement?.nativeElement);
        this.cardCvc.on('change', event => {
          this.cardCvcComplete = event.complete;
          if (event.error) this.cardErrors = event.error.message;
          else this.cardErrors = null;
        })
      }
    })
  }

  get paymentFormComplete() {
    return this.checkoutForm?.get('paymentForm')?.valid
      && this.cardNumberComplete
      && this.cardExpiryComplete
      && this.cardCvcComplete
  }

  async submitCompletedBooking() {
    this.loading = true;
    const booking = this.bookingService.getCurrentBookingValue();
    if (!booking) throw new Error('Cannot get booking');
    try {
      const createdCompletedBooking = await this.createCompletedBooking(booking);
      const paymentResult = await this.confirmPaymentWithStripe(booking);
      if (paymentResult.paymentIntent) {
        this.bookingService.deleteBooking(booking);
        const navigationExtras: NavigationExtras = {state: createdCompletedBooking};
        this.router.navigate(['checkout/success'], navigationExtras);
      } else {
        this.toastr.error(paymentResult.error.message);
      }
    } catch (error: any) {
      console.log(error);
      this.toastr.error(error.message)
    } finally {
      this.loading = false;
    }
  }

  private async confirmPaymentWithStripe(booking: IBooking | null) {
    if (!booking) throw new Error('Booking is null');
    const result = this.stripe?.confirmCardPayment(booking.clientSecret!, {
      payment_method: {
        card: this.cardNumber!,
        billing_details: {
          name: this.checkoutForm?.get('paymentForm')?.get('nameOnCard')?.value
        }
      }
    });
    if (!result) throw new Error('Problem attempting payment with stripe');
    return result;
  }

  private async createCompletedBooking(booking: IBooking | null) {
    if (!booking) throw new Error('Booking is null');
    const completedBookingToCreate = this.getCompletedBookingToCreate(booking);
    return firstValueFrom(this.checkoutService.createCompletedBooking(completedBookingToCreate));
  }

  private getCompletedBookingToCreate(booking: IBooking): ICompletedBookingToCreate {
    const luggageOptionId = this.checkoutForm?.get('luggageForm')?.get('luggageOption')?.value;
    const bookingDetails = this.checkoutForm?.get('detailsForm')?.value as IUserDetails;
    if (!luggageOptionId || !bookingDetails) throw new Error('Problem with booking');
    return {
      bookingId: booking.id,
      luggageOptionId: luggageOptionId,
      bookingDetails: bookingDetails
    }
  }
}
