using System.Threading.Tasks;
using AutoMapper;
using Dto;
using Entities;
using Microsoft.AspNetCore.Identity;

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
            var hero = this.mapper.Map<Hero>(addHeroDto);
            username.UserHeros.Add(hero);
        }
    }
}
