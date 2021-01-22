using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Extensions;
using AutoMapper;
using Data;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Controllers
{
    public class HerosController : BaseApiController
    {
        private readonly UnitOfWork unitOfWork;
        public HerosController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddHero(AddHeroDto addHeroDto)
        {
            await unitOfWork.HeroRepository.AddHero(addHeroDto, User.GetUsername());
            return await unitOfWork.ApplyChanges() ? Ok()
            : throw new HttpRequestException(" an unknown error has accorded ");//TODO: change to proper exception messsage 

        }
        [HttpPost("{heroId}")]
        public async Task<IActionResult> AddHero(Guid heroId)
        {
            await unitOfWork.HeroRepository.TainHero(heroId);
            return await unitOfWork.ApplyChanges() ? Ok()
            : throw new HttpRequestException(" an unknown error has accorded ");//TODO: change to proper exception messsage 

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroDto>>> GetHeros()
        {
            var heros = await unitOfWork.HeroRepository.GetAllHeros(User.GetUserId());
            return Ok(heros);
        }

    }
}
