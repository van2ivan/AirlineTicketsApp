import { IAirport } from "./airport";
import { ICompany } from "./companyName";

export interface IFlight {
  id: number;
  flightNumber: number
  status: string
  departureTime: string
  arrivalTime: string
  actualDepartureTime: string
  actualArrivalTime: string
  plane: string
  company: ICompany
  departureAirport: IAirport
  arrivalAirport: IAirport
  price: number
}

