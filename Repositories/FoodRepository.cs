using System;
using AutoMapper;
using MemAthleteServer.Models;
using MemAthleteServer.Templates;
using MemAthleteServer.Utils;
using StackExchange.Redis;

namespace MemAthleteServer.Repositories
{
    public class FoodRepository : RedisTemplate<Food>
    {
        private readonly IMapper _mapper;

        private readonly ShortIdGenerator _shortIdGenerator;

        public FoodRepository(IDatabase redisDb, ShortIdGenerator shortIdGenerator, IMapper mapper) : base(redisDb)
        {
            _shortIdGenerator = shortIdGenerator;
            _mapper = mapper;
        }

        protected override string GetPrefix()
        {
            return "FD";
        }

        protected override TimeSpan GetLifeTime()
        {
            return TimeSpan.FromMinutes(10);
        }

        public Food SaveOne(FoodCreateUpdateDto foodCreateUpdateDto)
        {
            var newFood = _mapper.Map<Food>(foodCreateUpdateDto);
            var newFoodId = _shortIdGenerator.GenerateNewShortId();
            newFood.FoodId = newFoodId;
            SaveById(newFoodId, newFood);
            return newFood;
        }

        public Food GetOne(string foodId)
        {
            var foundFood = GetById(foodId);
            if (foundFood != null) return foundFood;
            throw new Exception(ErrorCodes.BadRequest);
        }

        public string DeleteOne(string foodId)
        {
            var foundFood = GetById(foodId);
            if (foundFood != null)
            {
                DeleteById(foodId);
                return foodId;
            }

            throw new Exception(ErrorCodes.BadRequest);
        }
    }
}