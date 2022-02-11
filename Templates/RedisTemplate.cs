using System;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MemAthleteServer.Templates
{
    public abstract class RedisTemplate<T> where T : class
    {
        protected RedisTemplate(IDatabase redisDb)
        {
            _redisDb = redisDb;
        }

        private readonly IDatabase _redisDb;

        protected abstract string GetPrefix();

        protected abstract TimeSpan GetLifeTime();

        private string GetKeyById(string id)
        {
            return $"{GetPrefix()}${id}";
        }

        protected void SaveById(string id, T entity)
        {
            var key = GetKeyById(id);
            var lifeTime = GetLifeTime();
            Save(key, entity, lifeTime);
        }

        protected void DeleteById(string id)
        {
            var key = GetKeyById(id);
            Delete(key);
        }

        protected T GetById(string id)
        {
            var key = GetKeyById(id);
            return Get(key);
        }

        private void Save(string key, T entity, TimeSpan life)
        {
            var serializedEntity = JsonConvert.SerializeObject(entity);
            _redisDb.StringSet(key, serializedEntity, life);
        }

        private void Delete(string key)
        {
            _redisDb.KeyDelete(key);
        }

        private T Get(string key)
        {
            var value = _redisDb.StringGet(key);
            return value.IsNull ? null : JsonConvert.DeserializeObject<T>(value);
        }
    }
}