import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlightsComponent } from './flights.component';
import { SharedModule } from '../shared/shared.module';
import { FlightDetailsComponent } from './flight-details/flight-details.component';
import { FlightsRoutingModule } from './flights-routing.module';
import { RouterModule } from '@angular/router';
import { FlightItemComponent } from './flight-item/flight-item.component';
import { GoogleMapsModule } from '@angular/google-maps';

@NgModule({
  declarations: [
    FlightsComponent,
    FlightDetailsComponent,
    FlightItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FlightsRoutingModule,
    RouterModule,
    GoogleMapsModule
  ]
})
export class FlightsModule { }
