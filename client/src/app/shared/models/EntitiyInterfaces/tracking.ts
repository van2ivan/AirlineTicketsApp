export interface ITracking {
  id: number
  flightNumber: number
  departureTime: string
  arrivalTime: string
  actualDepartureTime: string
  actualArrivalTime: string
  plane: string
  company: string
  departureAirport: IAirport
  arrivalAirport: IAirport
}

export interface IAirport {
  id: number
  name: string
  longtitude: number
  latitude: number
  timeZone: number
}
