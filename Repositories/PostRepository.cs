using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MemAthleteServer.Configs;
using MemAthleteServer.DatabaseContexts;
using MemAthleteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace MemAthleteServer.Repositories
{
    public class PostRepository
    {
        public PostRepository(FacebookDbContext facebookDbContext)
        {
            _facebookDbContext = facebookDbContext;
            _mapper = AutomapperConfig.CreateIMapper();
        }

        private readonly FacebookDbContext _facebookDbContext;
        private readonly IMapper _mapper;

        public Post AddOne(PostCreateUpdateDto postCreateUpdateDto)
        {
            var newPost = _mapper.Map<Post>(postCreateUpdateDto);
            _facebookDbContext.Posts.Add(newPost);
            _facebookDbContext.SaveChanges();
            var newPostId = newPost.PostId;
            return GetOne(newPostId);
        }

        public Post GetOne(int postId)
        {
            var foundPost = _facebookDbContext
                .Posts
                .Include(post => post.Comments)
                .SingleOrDefault(p => p.PostId == postId);
            if (foundPost == null)
            {
                throw new Exception(ErrorCodes.BadRequest);
            }

            return foundPost;
        }

        public List<Post> GetAll()
        {
            return _facebookDbContext
                .Posts
                .Include(post => post.Comments)
                .ToList();
        }

        public int DeleteOne(int postId)
        {
            var foundPost = _facebookDbContext.Posts.SingleOrDefault(p => p.PostId == postId);
            if (foundPost == null)
            {
                throw new Exception(ErrorCodes.BadRequest);
            }

            _facebookDbContext.Posts.Remove(foundPost);
            _facebookDbContext.SaveChanges();
            return postId;
        }
    }
}