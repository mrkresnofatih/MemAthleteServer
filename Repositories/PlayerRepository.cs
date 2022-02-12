using System;
using AutoMapper;
using MemAthleteServer.Models;
using MemAthleteServer.Templates;
using MemAthleteServer.Utils;
using StackExchange.Redis;

namespace MemAthleteServer.Repositories
{
    public class PlayerRepository : RedisTemplate<Player>
    {
        private readonly IMapper _mapper;
        private readonly PlayerPasswordHasher _playerPasswordHasher;
        private readonly ShortIdGenerator _shortIdGenerator;
        private readonly AccessTokenUtils _accessTokenUtils;

        public PlayerRepository(IDatabase redisDb,
            PlayerPasswordHasher playerPasswordHasher,
            IMapper mapper,
            ShortIdGenerator shortIdGenerator) : base(redisDb)
        {
            _mapper = mapper;
            _shortIdGenerator = shortIdGenerator;
            _playerPasswordHasher = playerPasswordHasher;
            _accessTokenUtils = new AccessTokenUtils();
        }

        protected override string GetPrefix()
        {
            return "PL";
        }

        protected override TimeSpan GetLifeTime()
        {
            return TimeSpan.FromMinutes(30);
        }

        public string Login(PlayerLoginDto playerLoginDto)
        {
            var playerId = playerLoginDto.PlayerId;
            var foundPlayer = GetById(playerId);
            if (foundPlayer == null)
            {
                return "invalid-credentials";
            }
            var isPasswordValid = _playerPasswordHasher
                .IsCompareValid(playerLoginDto.Password, foundPlayer.Password);
            if (isPasswordValid) return _accessTokenUtils.GenerateToken(playerId, foundPlayer.YearOfBirth);
            throw new Exception(ErrorCodes.InvalidCredential);
        }

        public Player SaveOne(PlayerCreateUpdateDto playerCreateUpdateDto)
        {
            var newPlayer = _mapper.Map<Player>(playerCreateUpdateDto);
            var newPlayerId = _shortIdGenerator.GenerateNewShortId();
            newPlayer.PlayerId = newPlayerId;
            newPlayer.Password = _playerPasswordHasher.DoHash(playerCreateUpdateDto.Password);
            SaveById(newPlayerId, newPlayer);
            return newPlayer;
        }

        public Player GetOne(string playerId)
        {
            var foundPlayer = GetById(playerId);
            if (foundPlayer != null) return foundPlayer;

            throw new Exception(ErrorCodes.BadRequest);
        }

        public string DeleteOne(string playerId)
        {
            var foundPlayer = GetById(playerId);
            if (foundPlayer != null)
            {
                DeleteById(playerId);
                return playerId;
            }

            throw new Exception(ErrorCodes.BadRequest);
        }
    }
}