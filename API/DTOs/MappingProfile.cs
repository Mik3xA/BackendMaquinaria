using API.Models;
using AutoMapper;

namespace API.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<MachineryDto, Machinery>();
            CreateMap<Machinery, MachineryDto>();
            CreateMap<RentalRequestDto, Rental>();
        }
    }
}