using System.Collections.Generic;
using MemAthleteServer.Models;
using MemAthleteServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemAthleteServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AthleteController : ControllerBase
    {
        public AthleteController(AthleteRepository athleteRepository, ILogger<AthleteController> logger)
        {
            _athleteRepository = athleteRepository;
            _logger = logger;
        }

        private readonly AthleteRepository _athleteRepository;
        private readonly ILogger<AthleteController> _logger;
        
        [HttpGet]
        public IEnumerable<Athlete> GetAll()
        {
            _logger.LogInformation("Get All");
            return _athleteRepository.GetAll();
        }

        [HttpGet("{athleteId}")]
        public Athlete GetOne(string athleteId)
        {
            _logger.LogInformation("Get One");
            return _athleteRepository.GetById(athleteId);
        }

        [HttpPost]
        public Athlete AddOne([FromBody] AthleteCreateUpdateDto athleteCreateUpdateDto)
        {
            _logger.LogInformation("Add One");
            return _athleteRepository.AddOne(athleteCreateUpdateDto);
        }

        [HttpPut("{athleteId}")]
        public Athlete UpdateOne(string athleteId, [FromBody] AthleteCreateUpdateDto athleteCreateUpdateDto)
        {
            return null;
        }

        [HttpDelete("{athleteId}")]
        public string DeleteOne(string athleteId)
        {
            return null;
        }
    }
}