using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        /// <summary>
        /// Add a new hero to the SQL
        /// </summary>
        public async Task<HeroDto> AddHero(AddHeroDto addHeroDto, string trainerId)
        {
            if (addHeroDto is null)
            {
                throw new ArgumentNullException(nameof(addHeroDto));
            }

            if (string.IsNullOrEmpty(trainerId))
            {
                throw new ArgumentException($"'{nameof(trainerId)}' cannot be null or empty.", nameof(trainerId));
            }

            var hero = mapper.Map<Hero>(addHeroDto);
            hero.TrainerId = trainerId;
            await context.UserHeros.AddAsync(hero);
            return mapper.Map<HeroDto>(hero);

        }
        /// <summary>
        /// get an entity of a hero from the sql (DbContext follows it changes)
        /// </summary>
        public async Task<Hero> GetHero(Guid heroId)
        {
            return await context.UserHeros.
            Include(x => x.TrainHistory.Where(y => y.Date == DateTime.Today))
            .SingleOrDefaultAsync(x => x.Id == heroId);
        }
        /// <summary>
        ///  Pulling all the heros of the trainer from the sql,
        ///  and how much each hero has trained today
        /// </summary>
        public async Task<IEnumerable<HeroDto>> GetAllHerosDto(string trainerId)
        {
            if (string.IsNullOrEmpty(trainerId))
            {
                throw new ArgumentException($"'{nameof(trainerId)}' cannot be null or empty.", nameof(trainerId));
            }
            return await context.UserHeros.Where(x => x.TrainerId == trainerId)
            .Include(x => x.TrainHistory)
            .ProjectTo<HeroDto>(mapper.ConfigurationProvider).OrderBy(x => x.CuretPower).AsNoTracking().ToListAsync();
        }
        /// <summary>
        ///  set the hero current power to 1.00 ~ 1.10 times of its current power.
        /// </summary>
        /// <param name="hero">Hero to train</param>
        public void TainHero(Hero hero)
        {
            if (hero is null)
            {
                throw new ArgumentNullException(nameof(hero));
            }

            hero.CuretPower *= GetRandomTrainScalar();
            hero.TrainHistory.Add(new Training());
        }
        private static double GetRandomTrainScalar()
        {
            Random r = new();
            var rate = (100.0 + r.Next(0, 10)) / 100;
            return rate;
        }
    }
}
