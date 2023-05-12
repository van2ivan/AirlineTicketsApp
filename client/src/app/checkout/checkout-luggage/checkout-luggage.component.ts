import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CheckoutService } from '../checkout.service';
import { ILuggageOption } from 'src/app/shared/models/EntitiyInterfaces/luggageOption';
import { BookingService } from 'src/app/booking/booking.service';

@Component({
  selector: 'app-checkout-luggage',
  templateUrl: './checkout-luggage.component.html',
  styleUrls: ['./checkout-luggage.component.scss']
})
export class CheckoutLuggageComponent implements OnInit {
  @Input() checkoutForm: FormGroup;
  luggageOptions: ILuggageOption[];

  constructor(private checkoutService: CheckoutService,
    private bookingService: BookingService){

  }
  ngOnInit(){
    this.checkoutService.getLuggageOptions().subscribe({
      next: (luggageOption: ILuggageOption[]) => {
        this.luggageOptions = luggageOption
      },
      error: (error) => console.log(error)
    });
  }
  setLuggagePrice(luggageOption: ILuggageOption){
    this.bookingService.setLuggagePrice(luggageOption);
  }

}
