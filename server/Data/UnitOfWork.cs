using System.Threading.Tasks;
using AutoMapper;

namespace Data
{
    public class UnitOfWork
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public UserRepository UserRepository => new(context, mapper);
        public HeroRepository HeroRepository => new(context, mapper);
        public async Task<bool> ApplyChanges()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}
