using MemAthleteServer.Attributes;
using MemAthleteServer.Constants;
using MemAthleteServer.Models;
using MemAthleteServer.Repositories;
using MemAthleteServer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemAthleteServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController
    {
        private readonly FoodRepository _foodRepository;
        private readonly ILogger<FoodController> _logger;

        public FoodController(FoodRepository foodRepository, ILogger<FoodController> logger)
        {
            _foodRepository = foodRepository;
            _logger = logger;
        }

        [HttpGet("{foodId}")]
        [RequireAuthenticationFilter]
        [AuthorizeByPolicy(AppAuthorizationPolicies.BornInEarly1990s)]
        public ResponsePayload<Food> GetOne(string foodId)
        {
            _logger.LogInformation("Get One");
            var res = _foodRepository.GetOne(foodId);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpPost]
        [IsModelValidFilter]
        public ResponsePayload<Food> PostOne([FromBody] FoodCreateUpdateDto foodCreateUpdateDto)
        {
            _logger.LogInformation("Save One");
            var res = _foodRepository.SaveOne(foodCreateUpdateDto);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpDelete("{foodId}")]
        public ResponsePayload<string> DeleteOne(string foodId)
        {
            _logger.LogInformation("Delete One");
            var res = _foodRepository.DeleteOne(foodId);
            return ResponseHandler.WrapSuccess(res);
        }
    }
}