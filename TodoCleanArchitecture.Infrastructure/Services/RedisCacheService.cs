using StackExchange.Redis;
using System.Text.Json;
using TodoCleanArchitecture.Application.Services;

namespace TodoCleanArchitecture.Infrastructure.Services
{
    public class RedisCacheService : ICacheService
    {
        private ConnectionMultiplexer redis;
        private IDatabase db;
        public RedisCacheService()
        {
            redis = ConnectionMultiplexer.Connect("localhost");
            db = redis.GetDatabase();

        }
        public void Remove(string key)
        {
            db.KeyDelete(key);
        }

        public void Set<T>(string key, T value)
        {
            RedisValue redisValue = JsonSerializer.Serialize(value);
            db.StringSet(key, redisValue);
        }

        public void TryGetValue<T>(string key, out T? value)
        {
            var result = db.StringGet(key).ToString();
            if (!string.IsNullOrEmpty(result))
            {
                var jsonResult = JsonSerializer.Deserialize<T>(result);
                value = jsonResult;
            }
            else
            {
                value = default;
            }
        }
    }
}
