using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UserRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await context.Users.Include(x => x.UserHeros)
            .SingleOrDefaultAsync(x => x.NormalizedUserName == username.ToUpper());
        }
    }
}
