using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly
{
    public class MappingProfile : Profile
    {
        public static void InitializeMappings()
        {
            Mapper.Initialize(configMappings =>
            {
                configMappings.CreateMap<Customer, CustomerDto>();
                configMappings.CreateMap<CustomerDto, Customer>();
                configMappings.CreateMap<Movie, MovieDto>();
                configMappings.CreateMap<MovieDto, Movie>();
            });
        }
    }
}