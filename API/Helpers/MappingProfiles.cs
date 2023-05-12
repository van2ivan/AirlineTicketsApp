using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.CompletedBookingAggregate;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Flight, FlightToReturnDTO>()
            .ForMember(x => x.Company, x => x.MapFrom(x => x.Company.Name))
            .ForMember(x => x.Plane, x => x.MapFrom(x => x.Plane.Name));
            //.ForMember(x => x.DepartureAirport, x => x.MapFrom(x => x.DepartureAirport.Name))
            //.ForMember(x => x.ArrivalAirport, x => x.MapFrom(x => x.ArrivalAirport.Name));

            CreateMap<Plane, PlaneToReturnDTO>()
                //.ForMember(x => x.Company, x => x.MapFrom(x => x.Company.Name))
                .ForMember(x => x.PictureUrl, x => x.MapFrom<PlaneUrlResolver>());
            CreateMap<Company, CompanyToReturnDTO>()
                .ForMember(x => x.PictureUrl, x => x.MapFrom<CompanyUrlResolver>());

            CreateMap<Airport, AirportToReturnDTO>();

            CreateMap<Core.Entities.Identity.Details, DetailsDTO>().ReverseMap();

            CreateMap<Flight, TrackingToReturnDTO>()
                .ForMember(x => x.Company, x => x.MapFrom(x => x.Company.Name))
                .ForMember(x => x.Plane, x => x.MapFrom(x => x.Plane.Name));
            CreateMap<BookingDTO, Booking>();
            CreateMap<TicketDTO, Ticket>();
            CreateMap<DetailsDTO, Core.Entities.CompletedBookingAggregate.Details>();
            CreateMap<CompletedBooking, CompletedBookingToReturnDTO>()
                .ForMember(x => x.LuggageOption, option => option.MapFrom(source => source.LuggageOption.Name))
                .ForMember(x => x.LuggagePrice, option => option.MapFrom(source => source.LuggageOption.Price));
            CreateMap<BookingItem, BookingItemDTO>()
                .ForMember(x => x.FlightId, option => option.MapFrom(source => source.FlightBooked.FlightId))
                .ForMember(x => x.FlightNumber, option => option.MapFrom(source => source.FlightBooked.FlightNumber))
                .ForMember(x => x.DepartureTime, option => option.MapFrom(source => source.FlightBooked.DepartureTime))
                .ForMember(x => x.ArrivalTime, option => option.MapFrom(source => source.FlightBooked.ArrivalTime))
                .ForMember(x => x.Company, option => option.MapFrom(source => source.FlightBooked.Company))
                .ForMember(x => x.DepartureAirport, option => option.MapFrom(source => source.FlightBooked.DepartureAirport))
                .ForMember(x => x.ArrivalAirport, option => option.MapFrom(source => source.FlightBooked.ArrivalAirport));
        }
    }
}