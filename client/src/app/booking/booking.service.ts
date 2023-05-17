import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Booking, IBooking, IBookingTotals, ITicket } from '../shared/models/EntitiyInterfaces/booking';
import { map } from 'rxjs/operators';
import { IFlight } from '../shared/models/EntitiyInterfaces/flight';
import { ILuggageOption } from '../shared/models/EntitiyInterfaces/luggageOption';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  baseUrl = 'https://localhost:5001/api';
  private bookingSource = new BehaviorSubject<IBooking | null>(null); // observable with multisubscribing
  booking$ = this.bookingSource.asObservable();
  private bookingTotalSource = new BehaviorSubject<IBookingTotals | null>(null);
  bookingTotal$ = this.bookingTotalSource.asObservable();


  constructor(private http: HttpClient) {

  }
  createPaymentIntent(){
    return this.http.post<IBooking>(this.baseUrl + '/payment/' + this.getCurrentBookingValue().id, {})
    .pipe(
      map(booking => {
        this.bookingSource.next(booking);
        console.log(booking);
      })
    );
  }

  setLuggagePrice(luggageOption: ILuggageOption){
    const booking = this.getCurrentBookingValue();

    if(booking){
      booking.luggagePrice = Math.round(luggageOption.price * 100) / 100;
      booking.luggageOptionId = luggageOption.id;
      this.setBooking(booking);
    }
  }

  private calculateTotals(){
    const booking = this.getCurrentBookingValue();
    if(!booking) return;
    const subtotal = Math.round(booking.tickets.reduce((a, b) => (b.price) + a, 0) * 100) / 100
    const luggage = Math.round(booking.luggagePrice * 100) / 100;
    const total = Math.round(subtotal * 100) / 100 + luggage;
    this.bookingTotalSource.next({subtotal, total, luggage})
  }

  getBooking(id: string){
    return this.http.get<IBooking>(this.baseUrl + '/booking?id=' + id)
    .pipe(
      map((booking: IBooking) => {
        this.bookingSource.next(booking); //iterate through observable
        //this.luggage = booking.luggagePrice;
        console.log(this.getCurrentBookingValue());
        this.calculateTotals();
      })
    //);
    /*.subscribe({
      next: booking => {
        this.bookingSource.next(booking);
        this.calculateTotals();
      }
    }*/
    );
  }

  setBooking(booking: IBooking)
  {
    return this.http.post<IBooking>(this.baseUrl + '/booking', booking).subscribe({
      next: response => {
        this.bookingSource.next(response);
        console.log(response);
        this.calculateTotals();
      },
      error: (error) =>  console.log(error)
    })
  }

  getCurrentBookingValue(){
    return this.bookingSource.value;
  }

  addTicketToBooking(flight: IFlight){
    const ticketToAdd: ITicket = this.mapFlighttoTicket(flight);
    const booking = this.getCurrentBookingValue() ?? this.createBooking();
    booking.tickets.push(ticketToAdd);
    this.setBooking(booking);
  }
  removeTicketFromBooking(ticket: ITicket){
    const booking = this.getCurrentBookingValue();
    if(!booking) return;
    if(booking.tickets.find(x => x.id == ticket.id)){ //some
      booking.tickets = booking.tickets.filter(t => t.id != ticket.id);
      if(booking.tickets.length > 0){
        this.setBooking(booking);
      }
      else{
        this.deleteBooking(booking);
      }
    }
  }

  deleteLocalBooking(){
    this.bookingSource.next(null);
    this.bookingTotalSource.next(null);
    localStorage.removeItem('booking_id');
  }

  deleteBooking(booking: IBooking){
    return this.http.delete(this.baseUrl + '/booking?id=' + booking.id).subscribe({
      next: () => {
        this.bookingSource.next(null)
        this.bookingTotalSource.next(null);
        localStorage.removeItem('booking_id');
      },
      error: (error) => console.log(error)
    })
  }

  private createBooking(): IBooking {
    const booking = new Booking();
    localStorage.setItem('booking_id', booking.id); //stroring booking in browser local storage
    //specfic for each browser
    return booking;
  }


  private mapFlighttoTicket(flight: IFlight): ITicket {
    return{
      id: flight.id,
      flightNumber: flight.flightNumber,
      departureTime: flight.departureTime,
      arrivalTime: flight.arrivalTime,
      actualDepartureTime: flight.actualDepartureTime,
      actualArrivalTime: flight.actualArrivalTime,
      status: flight.status,
      plane: flight.plane,
      company: flight.company.name,
      departureAirport: flight.departureAirport.name,
      arrivalAirport: flight.arrivalAirport.name,
      price: flight.price
    }
  }
}
