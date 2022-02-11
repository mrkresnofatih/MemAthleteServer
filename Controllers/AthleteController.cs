using System.Collections.Generic;
using MemAthleteServer.Attributes;
using MemAthleteServer.Models;
using MemAthleteServer.Repositories;
using MemAthleteServer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemAthleteServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AthleteController : ControllerBase
    {
        private readonly AthleteRepository _athleteRepository;
        private readonly ILogger<AthleteController> _logger;

        public AthleteController(AthleteRepository athleteRepository, ILogger<AthleteController> logger)
        {
            _athleteRepository = athleteRepository;
            _logger = logger;
        }

        [HttpGet]
        public ResponsePayload<IEnumerable<Athlete>> GetAll()
        {
            _logger.LogInformation("Get All");
            var res = _athleteRepository.GetAll();
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpGet("{athleteId}")]
        public ResponsePayload<Athlete> GetOne(string athleteId)
        {
            _logger.LogInformation("Get One");
            var res = _athleteRepository.GetById(athleteId);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpPost]
        [IsModelValidFilter]
        public ResponsePayload<Athlete> AddOne([FromBody] AthleteCreateUpdateDto athleteCreateUpdateDto)
        {
            _logger.LogInformation("Add One");
            var res = _athleteRepository.AddOne(athleteCreateUpdateDto);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpPut("{athleteId}")]
        [IsModelValidFilter]
        public ResponsePayload<Athlete> UpdateOne(string athleteId,
            [FromBody] AthleteCreateUpdateDto athleteCreateUpdateDto)
        {
            _logger.LogInformation("Update One");
            var res = _athleteRepository.UpdateOne(athleteId, athleteCreateUpdateDto);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpDelete("{athleteId}")]
        public ResponsePayload<string> DeleteOne(string athleteId)
        {
            _logger.LogInformation("Delete One");
            var res = _athleteRepository.DeleteOne(athleteId);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpGet("GetFirstName/{athleteId}")]
        [HasHeader("firstNameKey")]
        public ResponsePayload<string> GetFirstName(string athleteId)
        {
            _logger.LogInformation("Get First Name");
            var res = _athleteRepository.GetById(athleteId).FirstName;
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpGet("GetClub/{athleteId}")]
        [AuthHeaderFilter("getClub")]
        public ResponsePayload<string> GetClub(string athleteId)
        {
            _logger.LogInformation("Get Club");
            var res = _athleteRepository.GetById(athleteId).Club;
            return ResponseHandler.WrapSuccess(res);
        }
    }
}