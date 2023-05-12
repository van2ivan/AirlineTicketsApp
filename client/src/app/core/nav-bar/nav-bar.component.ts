import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { BookingService } from 'src/app/booking/booking.service';
import { IBooking } from 'src/app/shared/models/EntitiyInterfaces/booking';
import { IUser } from 'src/app/shared/models/EntitiyInterfaces/user';


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit{
  booking$: Observable<IBooking>;
  currentUser$: Observable<IUser>;

  constructor(private bookingService: BookingService,
    private accountService: AccountService){
    booking$: Observable<IBooking>;
  }

  ngOnInit(){
    this.booking$ = this.bookingService.booking$;
    this.currentUser$ = this.accountService.currentUser$;
  }

  logout(){
    this.accountService.logout();
  }
}
