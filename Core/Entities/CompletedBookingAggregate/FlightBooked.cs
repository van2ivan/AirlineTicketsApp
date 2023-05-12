using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities.CompletedBookingAggregate
{
    [Owned]
    public class FlightBooked
    {
        public FlightBooked()
        {

        }
        public FlightBooked(int flightId, int flightNumber, DateTime departureTime, DateTime arrivalTime, DateTime actualDepartureTime, DateTime actualArrivalTime, string company, string departureAirport, string arrivalAirport)
        {
            FlightId = flightId;
            FlightNumber = flightNumber;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            ActualDepartureTime = actualDepartureTime;
            ActualArrivalTime = actualArrivalTime;
            Company = company;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
        }

        public int FlightId { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime ActualArrivalTime { get; set; }
        public string Company { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
    }
}