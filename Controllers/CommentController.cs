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
    public class CommentController
    {
        public CommentController(ILogger<CommentController> logger, CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            _logger = logger;
        }

        private readonly CommentRepository _commentRepository;
        private readonly ILogger<CommentController> _logger;

        [HttpGet]
        public ResponsePayload<List<Comment>> GetAll()
        {
            _logger.LogInformation("Get All Comments");
            var res = _commentRepository.GetAll();
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpGet("{commentId}")]
        public ResponsePayload<Comment> GetOne(int commentId)
        {
            _logger.LogInformation("Get One Comment");
            var res = _commentRepository.GetOne(commentId);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpPost]
        [IsModelValidFilter]
        public ResponsePayload<Comment> SaveOne([FromBody] CommentCreateUpdateDto commentCreateUpdateDto)
        {
            _logger.LogInformation("Add One Comment");
            var res = _commentRepository.AddOne(commentCreateUpdateDto);
            return ResponseHandler.WrapSuccess(res);
        }
    }
}