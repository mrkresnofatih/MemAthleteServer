using System;
using System.Collections.Generic;
using AutoMapper;
using MemAthleteServer.Models;
using MemAthleteServer.Utils;

namespace MemAthleteServer.Repositories
{
    public class AthleteRepository
    {
        public AthleteRepository(IMapper mapper, ShortIdGenerator shortIdGenerator)
        {
            _repository = new Dictionary<string, Athlete>();
            _mapper = mapper;
            _shortIdGenerator = shortIdGenerator;
        }

        private readonly ShortIdGenerator _shortIdGenerator;
        private readonly Dictionary<string, Athlete> _repository;
        private readonly IMapper _mapper;

        public IEnumerable<Athlete> GetAll()
        {
            return _repository.Values;
        }

        public Athlete GetById(string athleteId)
        {
            var foundAthlete = _repository.GetValueOrDefault(athleteId);
            if (foundAthlete == null)
            {
                throw new Exception(ErrorCodes.BadRequest);
            }

            return foundAthlete;
        }

        public Athlete AddOne(AthleteCreateUpdateDto athleteCreateUpdateDto)
        {
            var newAthlete = _mapper.Map<Athlete>(athleteCreateUpdateDto);
            var newlyGeneratedId = _shortIdGenerator.GenerateNewShortId();
            newAthlete.AthleteId = newlyGeneratedId;
            _repository.Add(newlyGeneratedId, newAthlete);
            return newAthlete;
        }

        public Athlete UpdateOne(string athleteId, AthleteCreateUpdateDto athleteCreateUpdateDto)
        {
            var foundAthlete = _repository.GetValueOrDefault(athleteId);
            if (foundAthlete == null)
            {
                throw new Exception(ErrorCodes.BadRequest);
            }
            var updatedAthlete = _mapper.Map<Athlete>(athleteCreateUpdateDto);
            updatedAthlete.AthleteId = athleteId;
            _repository[athleteId] = updatedAthlete;
            return updatedAthlete;
        }

        public string DeleteOne(string athleteId)
        {
            var foundAthlete = _repository.GetValueOrDefault(athleteId);
            if (foundAthlete == null)
            {
                throw new Exception(ErrorCodes.BadRequest);
            }

            _repository.Remove(athleteId);
            return "Athlete deleted";
        }
    }
}