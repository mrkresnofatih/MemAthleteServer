using System;

namespace MemAthleteServer.Templates
{
    public interface IRedisTemplate<T>
    {
        public void Save(string key, T entity, TimeSpan life);

        public void Delete(string key);

        public T Get(string key);
    }
}