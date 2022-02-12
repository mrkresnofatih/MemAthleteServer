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
    public class PlayerController
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly PlayerRepository _playerRepository;

        public PlayerController(PlayerRepository playerRepository, ILogger<PlayerController> logger)
        {
            _logger = logger;
            _playerRepository = playerRepository;
        }

        [HttpGet("{playerId}")]
        public ResponsePayload<Player> GetOne(string playerId)
        {
            _logger.LogInformation("Get One");
            var res = _playerRepository.GetOne(playerId);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpPost]
        [IsModelValidFilter]
        public ResponsePayload<Player> PostOne([FromBody] PlayerCreateUpdateDto playerCreateUpdateDto)
        {
            _logger.LogInformation("Save One");
            var res = _playerRepository.SaveOne(playerCreateUpdateDto);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpPost("login")]
        public ResponsePayload<string> Login([FromBody] PlayerLoginDto playerLoginDto)
        {
            _logger.LogInformation("Login");
            var res = _playerRepository.Login(playerLoginDto);
            return ResponseHandler.WrapSuccess(res);
        }
    }
}