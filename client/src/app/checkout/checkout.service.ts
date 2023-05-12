import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILuggageOption } from '../shared/models/EntitiyInterfaces/luggageOption';
import { map } from 'rxjs';
import { ICompletedBookingToCreate } from '../shared/models/EntitiyInterfaces/completedBooking';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = "https://localhost:5001/api/"

  constructor(private http: HttpClient){

  }
  createCompletedBooking(completedBooking: ICompletedBookingToCreate){
    return this.http.post(this.baseUrl + 'completedBooking', completedBooking)
  }

  getLuggageOptions(){
    return this.http.get(this.baseUrl + 'completedBooking/luggageOptions').pipe(
      map((luggageOption: ILuggageOption[]) => {
        return luggageOption.sort((a, b) => b.price - a.price);
      })
    )
  }
}
