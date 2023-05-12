using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications.EntitySpecificationParams;

namespace Core.Specifications
{
    public class PlanesWithCompanyAndFlights : BaseSpecification<Plane>
    {
        public PlanesWithCompanyAndFlights(PlaneSpecificationParams planeParams)
        {
            AddInclude(x => x.Company);
            AddInclude(x => x.Flights);
            ApplyPaging(planeParams.PageSize * (planeParams.PageIndex - 1),
            planeParams.PageSize);
        }
        public PlanesWithCompanyAndFlights(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Company);
            AddInclude(x => x.Flights);
        }
    }
}