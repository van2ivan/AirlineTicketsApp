export class FlightTracking {
  flightNumber: number
  departureTime: string
  arrivalTime: string
  actualDepartureTime: string
  actualArrivalTime: string
  plane: string
  company: string
  departureAirport: Airport
  arrivalAirport: Airport
}

export class Airport{
  id: number
  name: string
  longtitude: number
  latitude: number
  timeZone: number
}
