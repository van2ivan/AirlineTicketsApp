using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.DTOs
{
    public class AirportToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        public int TimeZone { get; set; }
    }
}