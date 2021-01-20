using System.Threading.Tasks;
using Entities;
/*
    
*/
namespace Interface
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
