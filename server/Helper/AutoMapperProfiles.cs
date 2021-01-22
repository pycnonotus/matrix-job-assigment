
using System;
using System.Collections.Generic;
using System.Linq;
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
            CreateMap<Hero, HeroDto>()
            .ForMember(d => d.TrainedTodayTimes,
            o => o.MapFrom(s => s.TrainHistory.Where(x => x.Date == DateTime.Today).Count()))
            .ForMember(d => d.FirstTraining, o => o.MapFrom(s => GetMinDate(s.TrainHistory.Select(x => x.Date))));

            CreateMap<AddHeroDto, Hero>().ForMember(d => d.CuretPower, o => o.MapFrom(s => s.Power))
            .ForMember(d => d.StartingPower, o => o.MapFrom(s => s.Power));
        }

        private static DateTime? GetMinDate(IEnumerable<DateTime>? dates)
        {
            if (dates != null && dates.Any())
            {
                return dates.Min();
            }
            return null;
        }
    }
}
