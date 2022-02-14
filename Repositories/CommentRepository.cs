using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MemAthleteServer.Configs;
using MemAthleteServer.DatabaseContexts;
using MemAthleteServer.Models;

namespace MemAthleteServer.Repositories
{
    public class CommentRepository
    {
        public CommentRepository(FacebookDbContext facebookDbContext)
        {
            _mapper = AutomapperConfig.CreateIMapper();
            _facebookDbContext = facebookDbContext;
        }

        private readonly FacebookDbContext _facebookDbContext;
        private readonly IMapper _mapper;

        public Comment AddOne(CommentCreateUpdateDto commentCreateUpdateDto)
        {
            var newComment = _mapper.Map<Comment>(commentCreateUpdateDto);
            _facebookDbContext.Comments.Add(newComment);
            _facebookDbContext.SaveChanges();
            var newCommentId = newComment.CommentId;
            return GetOne(newCommentId);
        }

        public Comment GetOne(int commentId)
        {
            return _facebookDbContext.Comments.FirstOrDefault(p => p.CommentId == commentId);
        }

        public List<Comment> GetAll()
        {
            return _facebookDbContext.Comments.ToList();
        }
    }
}