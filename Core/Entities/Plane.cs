using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core.Entities
{

    public class Plane : BaseEntity
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public List<Flight> Flights { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }

    }
}