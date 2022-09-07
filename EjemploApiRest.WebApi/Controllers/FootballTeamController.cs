using EjemploApiRest.Application;
using EjemploApiRest.Entities;
using EjemploApiRest.WebApi.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EjemploApiRest.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {
        IApplication<FootballTeam> _footballTeam;
        public FootballTeamController(IApplication<FootballTeam> footballTeam)
        {
            _footballTeam = footballTeam;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_footballTeam.GetAll());
        }

        [HttpPost]
        public IActionResult Post(FootballTeamDTO dto)
        {
            var f = new FootballTeam()
            {
                Name = dto.Name,
                Score = dto.Score,
                Manager = dto.Manager
            };
            return Ok(_footballTeam.Save(f));
        }
    }
}
