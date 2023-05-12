import { IAirport } from "./airport";

export interface IFlight {
  id: number;
  flightNumber: number
  status: string
  departureTime: string
  arrivalTime: string
  actualDepartureTime: string
  actualArrivalTime: string
  plane: string
  company: string
  departureAirport: IAirport
  arrivalAirport: IAirport
  price: number
}

