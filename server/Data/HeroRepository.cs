using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dto;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HeroRepository
    {
        private readonly IMapper mapper;
        private readonly DataContext context;
        private readonly UserRepository userRepository;
        public HeroRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.userRepository = new UserRepository(context, mapper);

        }
        public async Task AddHero(AddHeroDto addHeroDto, string userName)
        {
            var username = await userRepository.GetUserByUsernameAsync(userName);
            var hero = mapper.Map<Hero>(addHeroDto);
            username.UserHeros.Add(hero);
        }

        public async Task<IEnumerable<HeroDto>> GetAllHeros(string trainerId)
        {
            Console.WriteLine(trainerId);
            var queery = await context.UserHeros.Where(x => x.TrainerId == trainerId)
            .ProjectTo<HeroDto>(mapper.ConfigurationProvider).AsQueryable().ToListAsync();

            return queery;
        }
        public async Task TainHero(Guid heroId)
        {
            // var hero = await context.UserHeros.FirstOrDefaultAsync(x => x.Id.Equals(heroId));
            var hero = await context.UserHeros.FindAsync(heroId);
            hero.CuretPower *= GetRandomTrainScalar();
        }
        private double GetRandomTrainScalar()
        {
            Random r = new();
            var rate = (100.0 + r.Next(0, 10)) / 100;
            return rate;
        }
    }
}
