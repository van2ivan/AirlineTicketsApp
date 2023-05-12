using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications.EntitySpecificationParams;

namespace Core.Specifications
{
    public class AirportWithDepartureAndArrivalFlights : BaseSpecification<Airport>
    {
        public AirportWithDepartureAndArrivalFlights(AirportSpecificationParams airportParams)
        {
            AddInclude(x => x.ArrivalFlights);
            AddInclude(x => x.DepartureFlights);
            ApplyPaging(airportParams.PageSize * (airportParams.PageIndex - 1),
            airportParams.PageSize);
        }
        public AirportWithDepartureAndArrivalFlights(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ArrivalFlights);
            AddInclude(x => x.DepartureFlights);
        }
    }
}