import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { BookingTotalsComponent } from './components/booking-totals/booking-totals.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TextInputComponent } from './components/text-input/text-input.component';
import { CdkStepperModule} from '@angular/cdk/stepper';
import { StepperComponent } from './components/stepper/stepper.component';
import { BookingSummaryComponent } from './components/booking-summary/booking-summary.component'

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    BookingTotalsComponent,
    BookingTotalsComponent,
    TextInputComponent,
    StepperComponent,
    BookingSummaryComponent
  ],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    PaginationModule.forRoot(),
    ReactiveFormsModule,
    CdkStepperModule

  ],
  exports: [
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    BookingTotalsComponent,
    ReactiveFormsModule,
    BsDropdownModule,
    TextInputComponent,
    CdkStepperModule,
    StepperComponent,
    BookingSummaryComponent
  ],
})
export class SharedModule { }
