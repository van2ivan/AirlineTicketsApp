import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CompletedBookingService {
  baseUrl = "https://localhost:5001/api/"
  constructor(private http: HttpClient) {

   }
   getCompletedBookingForUser(){
    return this.http.get(this.baseUrl + 'completedBooking');
   }

   getCompletedBookingDetails(id: number){
    return this.http.get(this.baseUrl + 'completedBooking/' + id);
   }
}
