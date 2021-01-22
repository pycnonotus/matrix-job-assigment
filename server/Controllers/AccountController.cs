

using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dto;
using Entities;
using Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        ITokenService tokenService, IMapper mapper)
        {
            this.mapper = mapper;
            this.tokenService = tokenService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var isUserExists = await userManager.Users.Where(x => x.NormalizedUserName == registerDto.Username.ToUpper())
               .Select(x => 1)
               .FirstOrDefaultAsync(); 
            if (isUserExists != 0)
            {
                return BadRequest("This user already exists");
            }
            var user = mapper.Map<AppUser>(registerDto);
            var userCreation = await userManager.CreateAsync(user, registerDto.Password);
            if (!userCreation.Succeeded)
            {
                return BadRequest(userCreation.Errors);
            }

            var userDto = new UserDto
            {
                Token =  tokenService.CreateToken(user),

            };
            return Ok(userDto);
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginDto>> Login(LoginDto loginDto)
        {
            var login = await userManager.FindByNameAsync(loginDto.Username);
            if (login == null)
            {
                return Unauthorized("Wrong Username of Password");
            }

            var loginAtempt =
                (await signInManager.CheckPasswordSignInAsync(login, loginDto.Password,
                    false)).Succeeded;
            if (!loginAtempt)
            {
                return Unauthorized("Wrong Username of Password");
            }
            var userDto = new UserDto
            {
                Token = tokenService.CreateToken(login),

            };
            return Ok(userDto);
        }



    }
}
