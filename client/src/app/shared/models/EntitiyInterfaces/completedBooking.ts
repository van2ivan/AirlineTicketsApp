import { IUserDetails } from "./user"

export interface ICompletedBookingToCreate {
  bookingId: string
  luggageOptionId: number
  bookingDetails: IUserDetails
}

export interface ICompletedBooking{
  id: number;
  passangerEmail: string
  bookingDate: string
  bookingDetails: IUserDetails
  luggageOption: string
  luggagePrice: number
  bookingItems: IBookingItem[]
  subtotal: number
  status: string
  total: number
} 

export interface IBookingItem {
  flightId: number
  flightNumber: number
  departureTime: string
  arrivalTime: string
  company: string
  departureAirport: string
  arrivalAirport: string
  price: number
}
