import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ICompletedBooking } from 'src/app/shared/models/EntitiyInterfaces/completedBooking';

@Component({
  selector: 'app-checkout-success',
  templateUrl: './checkout-success.component.html',
  styleUrls: ['./checkout-success.component.scss']
})
export class CheckoutSuccessComponent implements OnInit{
  completedBooking: ICompletedBooking;
  constructor(private router: Router){
    const navigation = this.router.getCurrentNavigation();
    const state = navigation && navigation.extras && navigation.extras.state;
    if(state){
      this.completedBooking = state as ICompletedBooking;
    }
  }
  ngOnInit(){
  }
}
