import { v4 as uuidv4 } from 'uuid';
import { ICompany } from './companyName';

export interface IBooking {
  id: string;
  tickets: ITicket[];
  clientSecret?: string;
  paymentIntentId?: string;
  luggageOptionId?: number;
  luggagePrice: number;
}

export interface ITicket{
  id: number;
  flightNumber: number;
  status: string;
  departureTime: string;
  arrivalTime: string;
  actualDepartureTime: string;
  actualArrivalTime: string;
  plane: string;
  company: string;
  departureAirport: string;
  arrivalAirport: string;
  price: number;
}

export interface IBookingTotals{
  luggage: number;
  subtotal: number;
  total: number;
}

export interface IPassengerCredentials{
  passengerFirstName: string;
  passengerLastName: string;
  passengerEmail: string;
}

export class Booking implements IBooking{
  id = uuidv4();
  tickets: ITicket[] = [];
  luggagePrice = 0;
}
