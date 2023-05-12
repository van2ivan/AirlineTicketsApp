import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { NotFoundError } from 'rxjs';
import { AuthorizationGuard } from './core/guards/authorization.guard';

const routes: Routes = [ //lazy loading
  {path: '', component: HomeComponent, data: {breadcrumb: 'Welcome aboard!' }},
  {path: 'test-error', component: TestErrorComponent, data: {breadcrumb: 'Test errors'}},
  {path: 'not-found', component: NotFoundError, data: {breadcrumb: 'Not found error'}},
  {path: 'server-error', component: ServerErrorComponent, data: {breadcrumb: 'Server error'}},
  {path: 'flights', loadChildren: () => import('./flights/flights.module').then(mod => mod.FlightsModule),
   data: {breadcrumb: 'Pick up your destination'}},
   {path: 'booking', loadChildren: () => import('./booking/booking.module').then(mod => mod.BookingModule),
   data: {breadcrumb: 'Book your flight'}},

   {path: 'checkout',
    canActivate: [AuthorizationGuard],
    loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule),
   data: {breadcrumb: 'Checkout'}},

   {path: 'completed-booking',
    canActivate: [AuthorizationGuard],
    loadChildren: () => import('./completed-booking/completed-booking.module').then(mod => mod.CompletedBookingModule),
    data: {breadcrumb: 'Your booking'}},

   {path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule),
   data: {breadcrumb: {skip: true}}},
  //{path: 'flights', component: CompaniesComponent}, // In companies module
  {path: '**', redirectTo: 'not-found', pathMatch: 'full'}//back to home back - for bad URLs
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
