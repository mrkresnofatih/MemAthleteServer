using System.Collections.Generic;
using MemAthleteServer.Attributes;
using MemAthleteServer.Models;
using MemAthleteServer.Repositories;
using MemAthleteServer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MemAthleteServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController
    {
        private readonly ILogger<PostController> _logger;
        private readonly PostRepository _postRepository;

        public PostController(IConfiguration configuration, PostRepository postRepository, ILogger<PostController> logger)
        {
            _logger = logger;
            _postRepository = postRepository;
            _logger.LogInformation(configuration["AppKey"]);
        }
        
        [HttpGet]
        public ResponsePayload<List<Post>> GetAll()
        {
            _logger.LogInformation("Get All");
            var res = _postRepository.GetAll();
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpPost]
        [IsModelValidFilter]
        public ResponsePayload<Post> AddOne([FromBody] PostCreateUpdateDto postCreateUpdateDto)
        {
            _logger.LogInformation("Add One");
            var res = _postRepository.AddOne(postCreateUpdateDto);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpGet("{postId}")]
        public ResponsePayload<Post> GetOne(int postId)
        {
            _logger.LogInformation("Get One");
            var res = _postRepository.GetOne(postId);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpDelete("{postId}")]
        public ResponsePayload<int> DeleteOne(int postId)
        {
            _logger.LogInformation("Delete One Post");
            var res = _postRepository.DeleteOne(postId);
            return ResponseHandler.WrapSuccess(res);
        }
    }
}