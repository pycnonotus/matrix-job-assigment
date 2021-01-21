
using AutoMapper;
using Dto;
using Entities;
using Extensions;

namespace API.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AddHeroDto, Hero>().ForMember(d => d.CuretPower, o => o.MapFrom(s => s.Power))
            .ForMember(d => d.StartingPower, o => o.MapFrom(s => s.Power));
        }
    }
}
