using System.Collections.Generic;
using API.Controllers;
using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.EntitySpecificationParams;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class FlightsController : BaseApiController
{
    private readonly IGenericRepository<Flight> _flightRepository;
    private readonly IGenericRepository<Ticket> _ticketRepository;

    private readonly IMapper _mapper;


    public FlightsController(IGenericRepository<Flight> flightRepository,
    IGenericRepository<Ticket> ticketRepository, IMapper mapper)
    {
        _flightRepository = flightRepository;
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<Pagination<FlightToReturnDTO>>> GetFlightsAsync(
        [FromQuery] FlightSpecificationParams flightParams)
    {
        var specification = new FlightsWithCompaniesPlanesAndAirports(flightParams);
        var countSpecification = new FlightWithFiltersForCountSpecification(flightParams);

        var totalItems = await _flightRepository.CountAsync(countSpecification);
        var flights = await _flightRepository.ListAsync(specification);

        var data = _mapper.Map<IReadOnlyList<Flight>, IReadOnlyList<FlightToReturnDTO>>(flights);

        return Ok(new Pagination<FlightToReturnDTO>(flightParams.PageIndex,
            flightParams.PageSize, totalItems, data));

    }
    [HttpGet("{id}")]
    public async Task<ActionResult<FlightToReturnDTO>> GetFlightByIdAsync(int id)
    {
        var specification = new FlightsWithCompaniesPlanesAndAirports(id);
        var flight = await _flightRepository.GetEntityWithSpecification(specification);
        return _mapper.Map<Flight, FlightToReturnDTO>(flight);
    }
}