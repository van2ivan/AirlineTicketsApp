using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.DTOs
{
    public class FlightToReturnDTO
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public string Status { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime ActualArrivalTime { get; set; }
        public string Plane { get; set; }
        public Company Company { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public decimal Price { get; set; }
    }
}