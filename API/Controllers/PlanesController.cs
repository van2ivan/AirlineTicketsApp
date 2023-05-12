using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.EntitySpecificationParams;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PlanesController : BaseApiController
    {
        private readonly IGenericRepository<Plane> _planeRepository;
        private readonly IMapper _mapper;

        public PlanesController(IGenericRepository<Plane> planeRepository, IMapper mapper)
        {
            _planeRepository = planeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PlaneToReturnDTO>>> GetPlanesAsync(
            [FromQuery]PlaneSpecificationParams planeParams)
        {
            var specification = new PlanesWithCompanyAndFlights(planeParams);
            var planes = await _planeRepository.ListAsync(specification);
            return Ok(_mapper.Map<IReadOnlyList<Plane>, IReadOnlyList<PlaneToReturnDTO>>(planes));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaneToReturnDTO>> GetPlaneByIdAsync(int id)
        {
            var specification = new PlanesWithCompanyAndFlights(id);
            var plane = await _planeRepository.GetEntityWithSpecification(specification);
            return _mapper.Map<Plane, PlaneToReturnDTO>(plane);

        }
    }
}