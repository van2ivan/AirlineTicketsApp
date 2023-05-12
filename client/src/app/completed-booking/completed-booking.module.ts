import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompletedBookingComponent } from './completed-booking.component';
import { CompletedBookingDetailsComponent } from './completed-booking-details/completed-booking-details.component';
import { CompletedBookingRoutingModule } from './completed-booking-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    CompletedBookingComponent,
    CompletedBookingDetailsComponent
  ],
  imports: [
    CommonModule,
    CompletedBookingRoutingModule,
    SharedModule
  ]
})
export class CompletedBookingModule { }
