using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Ticket : BaseEntity
    {
        public int FlightNumber { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string ActualDepartureTime { get; set; }
        public string ActualArrivalTime { get; set; }
        public string Plane { get; set; }
        public string Company { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public decimal Price { get; set; }
    }
}