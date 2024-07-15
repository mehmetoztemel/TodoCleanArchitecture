using Microsoft.Extensions.Caching.Memory;
using TodoCleanArchitecture.Application.Services;

namespace TodoCleanArchitecture.Infrastructure.Services
{
    public class MemoryCacheService : ICacheService
    {
        private IMemoryCache _memoryCache;
        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void Set<T>(string key, T value)
        {
            MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                //AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
            };
            _memoryCache.Set(key, value, cacheOptions);
        }

        public void TryGetValue<T>(string key, out T? value)
        {
            _memoryCache.TryGetValue(key, out value);
        }
    }
}
