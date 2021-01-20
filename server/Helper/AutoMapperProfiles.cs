
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
           
        }
    }
}
