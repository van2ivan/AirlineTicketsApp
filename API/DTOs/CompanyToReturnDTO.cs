using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.DTOs
{
    public class CompanyToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string FlightCode { get; set; }
        public decimal Rating { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Plane> Planes { get; set; }
    }
}