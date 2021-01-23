using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Extensions;
using AutoMapper;
using Data;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authorization;

namespace Controllers
{   
     [Authorize]

    public class HerosController : BaseApiController
    {
        private readonly UnitOfWork unitOfWork;
        public HerosController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<HeroDto>> AddHero(AddHeroDto addHeroDto)
        {
            var hero = await unitOfWork.HeroRepository.AddHero(addHeroDto, User.GetUserId());
            return await unitOfWork.ApplyChanges() ? Ok(hero)
            : throw new HttpRequestException(" an unknown error has accorded while adding a new hero ");

        }
        [HttpPost("{heroId}")]
        public async Task<IActionResult> Train(Guid heroId)
        {

            var hero = await unitOfWork.HeroRepository.GetHero(heroId);
            if (hero == null || hero.TrainerId != User.GetUserId()) // user shall not train not his heros
            {
                return NotFound("no hero is assoiled with the id: " + heroId);
            }
            if (hero.TrainHistory.Count >= 5)
            {
                return BadRequest("A hero can't train more then 5 times a day");
            }
            unitOfWork.HeroRepository.TainHero(hero);
            return await unitOfWork.ApplyChanges() ? Ok(hero.CuretPower)
                : throw new HttpRequestException(" an unknown error has accorded while training a hero");
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroDto>>> GetHeros()
        {

            var heros = await unitOfWork.HeroRepository.GetAllHerosDto(User.GetUserId());
            return Ok(heros);
        }

    }
}
