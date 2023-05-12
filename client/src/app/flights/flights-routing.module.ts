import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FlightsComponent } from './flights.component';
import { FlightDetailsComponent } from './flight-details/flight-details.component';

const routes: Routes = [
  {path: '', component: FlightsComponent},
  {path: ':id', component: FlightDetailsComponent, data: {breadcrumb: {alias: 'flightDetails'}}},
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class FlightsRoutingModule { }
