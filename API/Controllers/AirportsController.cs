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
    public class AirportsController : BaseApiController
    {
        private readonly IGenericRepository<Airport> _airportRepository;
        private readonly IMapper _mapper;

        public AirportsController(IGenericRepository<Airport> airportRepository, IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AirportToReturnDTO>>> GetAirportsAsync(
            [FromQuery]AirportSpecificationParams airportParams)
        {
            var specification = new AirportWithDepartureAndArrivalFlights(airportParams);
            var airports = await _airportRepository.ListAsync(specification);
            return Ok(_mapper.Map<IReadOnlyList<Airport>, IReadOnlyList<AirportToReturnDTO>>(airports));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AirportToReturnDTO>> GetAirportByIdAsync(int id)
        {
            var specification = new AirportWithDepartureAndArrivalFlights(id);
            var airport = await _airportRepository.GetEntityWithSpecification(specification);
            return _mapper.Map<Airport, AirportToReturnDTO>(airport);
        }
    }
}