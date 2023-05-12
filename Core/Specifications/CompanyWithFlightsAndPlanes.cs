using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications.EntitySpecificationParams;

namespace Core.Specifications
{
    public class CompanyWithFlightsAndPlanes : BaseSpecification<Company>
    {
        public CompanyWithFlightsAndPlanes(CompanySpecificationParams companyParams) : base(x => 
                (string.IsNullOrEmpty(companyParams.Search) || x.Name.ToLower().Contains(companyParams.Search))
            ) 
        {
            AddInclude(x => x.Planes);
            AddInclude(x => x.Flights);
            ApplyPaging(companyParams.PageSize * (companyParams.PageIndex - 1), 
            companyParams.PageSize);

            if(!string.IsNullOrEmpty(companyParams.Sort))
            {
                switch(companyParams.Sort)
                {
                    case "CompanyNameAsc":
                        AddOrderBy(x => x.Name);
                        break;
                    case "CompanyNameDesc":
                        AddOrderByDescending(x => x.Name);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }
        public CompanyWithFlightsAndPlanes(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Planes);
            AddInclude(x => x.Flights);
        }
    }
}