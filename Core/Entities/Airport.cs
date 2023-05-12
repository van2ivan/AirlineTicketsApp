using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Airport : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Flight> DepartureFlights { get; set; }
        public List<Flight> ArrivalFlights { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        public int TimeZone { get; set;}
        public string Country { get; set; }
        public string City { get; set; }
        

    }
}