using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class TicketDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int FlightNumber { get; set; }
        [Required]
        public string DepartureTime { get; set; }
        [Required]
        public string ArrivalTime { get; set; }
        [Required]
        public string ActualDepartureTime { get; set; }
        [Required]
        public string ActualArrivalTime { get; set; }
        [Required]
        public string Plane { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string DepartureAirport { get; set; }
        [Required]
        public string ArrivalAirport { get; set; }
        [Required] 
        public decimal Price { get; set; }
    }
}