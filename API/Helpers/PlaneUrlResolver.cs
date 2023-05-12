using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using API.DTOs;

namespace API.Helpers
{
    public class PlaneUrlResolver: IValueResolver<Plane, PlaneToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;
        public PlaneUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Plane source, PlaneToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}