using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specifications.EntitySpecificationParams
{
    public class CompanySpecifcationParams
    {
        private const int MaxPageSize = 15;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 5;
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string Sort { get; set; }
    }
}