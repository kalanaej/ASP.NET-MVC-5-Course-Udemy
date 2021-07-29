using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    // Derive the class from Profile (using System.Web;)
    public class MappingProfile : Profile
    {
        // Constructor
        public MappingProfile()
        {
            // Map customer to CustomerDto
            Mapper.CreateMap<Customer, CustomerDto>();

            // Map Movie to MovieDto
            Mapper.CreateMap<Movie, MovieDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}