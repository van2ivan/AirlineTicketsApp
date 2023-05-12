using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.EntitySpecificationParams;
using Core.Specifications.FiltersForCount;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CompaniesController : BaseApiController
    {
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IMapper _mapper;
        public CompaniesController(IGenericRepository<Company> companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompanyToReturnDTO>>> GetCompaniesAsync(
            [FromQuery]CompanySpecificationParams companyParams)
        {
            var specification = new CompanyWithFlightsAndPlanes(companyParams);
            var countSpecification = new CompaniesWithFiltersForCountSpecification(companyParams);

            var totalItems = await _companyRepository.CountAsync(countSpecification);
            var companies = await _companyRepository.ListAsync(specification);

            var data = _mapper.Map<IReadOnlyList<Company>, IReadOnlyList<CompanyToReturnDTO>>(companies);

            return Ok(new Pagination<CompanyToReturnDTO>(companyParams.PageIndex,
             companyParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyToReturnDTO>> GetCompanyByIdAsync(int id)
        {
            var specification = new CompanyWithFlightsAndPlanes(id);
            var company = await _companyRepository.GetEntityWithSpecification(specification);
            return _mapper.Map<Company, CompanyToReturnDTO>(company);
        }
    }
}