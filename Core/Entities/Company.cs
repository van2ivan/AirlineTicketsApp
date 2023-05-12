
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set;}
        public string PictureUrl { get; set;}
        public string FlightCode { get; set; }
        
        [Range(0, 5)]
        public decimal Rating { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Plane> Planes { get; set; }
    }
}