using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class TrackingToReturnDTO
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime ActualArrivalTime { get; set; }
        public string Plane { get; set; }
        public string Company { get; set; }
        public AirportToReturnDTO DepartureAirport { get; set; }
        public AirportToReturnDTO ArrivalAirport { get; set; }

    }
}