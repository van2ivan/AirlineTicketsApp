using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class CompanyUrlResolver : IValueResolver<Company, CompanyToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;
        public CompanyUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Company source, CompanyToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}