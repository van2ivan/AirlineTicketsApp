using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications.EntitySpecificationParams;

namespace Core.Specifications
{
    public class FlightsWithCompaniesPlanesAndAirports : BaseSpecification<Flight>
    {
        public FlightsWithCompaniesPlanesAndAirports(FlightSpecificationParams flightParams)
            : base(x =>
                (string.IsNullOrEmpty(flightParams.Search) || x.ArrivalAirport.City.ToLower().Contains(flightParams.Search) ||
                x.DepartureAirport.City.ToLower().Contains(flightParams.Search) || x.ArrivalAirport.Country.ToLower().Contains(flightParams.Search) ||
                x.DepartureAirport.Country.ToLower().Contains(flightParams.Search)) &&
                (!flightParams.ArrivalAirportId.HasValue ||
                x.ArrivalAirportId == flightParams.ArrivalAirportId) &&
                (!flightParams.DepartureAirportId.HasValue ||
                x.DepartureAirportId == flightParams.DepartureAirportId)
            )
        {
            AddInclude(x => x.ArrivalAirport);
            AddInclude(x => x.DepartureAirport);
            AddInclude(x => x.Plane);
            AddInclude(x => x.Company);
            ApplyPaging(flightParams.PageSize * (flightParams.PageIndex - 1),
            flightParams.PageSize);

            if (!string.IsNullOrEmpty(flightParams.Sort))
            {
                switch (flightParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    case "departureAirportNameAsc":
                        AddOrderBy(x => x.DepartureAirport.Name);
                        break;
                    case "departureAirportNameDesc":
                        AddOrderByDescending(x => x.DepartureAirport.Name);
                        break;
                    case "arrivalAirportNameAsc":
                        AddOrderBy(x => x.ArrivalAirport.Name);
                        break;
                    case "arrivalAirportNameDesc":
                        AddOrderByDescending(x => x.ArrivalAirport.Name);
                        break;
                    default:
                        AddOrderBy(x => x.ArrivalAirport.Name);
                        break;
                }
            }
        }
        public FlightsWithCompaniesPlanesAndAirports(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ArrivalAirport);
            AddInclude(x => x.DepartureAirport);
            AddInclude(x => x.Plane);
            AddInclude(x => x.Company);
        }
    }
}