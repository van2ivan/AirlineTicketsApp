import { NgModule } from '@angular/core';
import { CompletedBookingComponent } from './completed-booking.component';
import { CompletedBookingDetailsComponent } from './completed-booking-details/completed-booking-details.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '', component: CompletedBookingComponent},
  {path: ':id', component: CompletedBookingDetailsComponent, data: {breadcrumb: {alias: 'Your booked flights'}}}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class CompletedBookingRoutingModule { }
