using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Flight : BaseEntity
    {
        public int FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime ActualArrivalTime { get; set; }
        public Plane Plane { get; set; }
        public int PlaneId { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public Airport DepartureAirport { get; set; }
        public int DepartureAirportId { get; set; }
        public Airport ArrivalAirport { get; set; }
        public int ArrivalAirportId { get; set; }
        public decimal Price { get; set; }
    }
}