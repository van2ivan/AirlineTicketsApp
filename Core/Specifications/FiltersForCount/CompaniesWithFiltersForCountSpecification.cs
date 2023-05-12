using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications.EntitySpecificationParams;

namespace Core.Specifications.FiltersForCount
{
    public class CompaniesWithFiltersForCountSpecification : BaseSpecification<Company>
    {
        public CompaniesWithFiltersForCountSpecification(CompanySpecificationParams companyParams) : base(x => 
                (string.IsNullOrEmpty(companyParams.Search) || x.Name.ToLower().Contains(companyParams.Search))
            ) 
            {

            }
    }
}