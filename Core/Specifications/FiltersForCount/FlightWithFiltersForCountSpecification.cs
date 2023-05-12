using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications.EntitySpecificationParams;

namespace Core.Specifications
{
    public class FlightWithFiltersForCountSpecification : BaseSpecification<Flight>
    {
        public FlightWithFiltersForCountSpecification(FlightSpecificationParams
        flightParams) : base(x => 
                (string.IsNullOrEmpty(flightParams.Search) || x.ArrivalAirport.Name
                .ToLower().Contains(flightParams.Search)) &&
                (!flightParams.ArrivalAirportId.HasValue || 
                x.ArrivalAirportId == flightParams.ArrivalAirportId ) &&
                (!flightParams.DepartureAirportId.HasValue || 
                x.DepartureAirportId == flightParams.DepartureAirportId )
                )
        {

        }
    }
}