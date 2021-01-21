using System.Threading.Tasks;
using Entities;
/*
    
*/
namespace Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
