//using Microsoft.Extensions.Caching.Memory;
using System.Runtime.Caching;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern
        ObjectCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = MemoryCache.Default; //ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, DateTimeOffset.Now.AddMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return (T)_memoryCache.Get(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        //public bool IsAdd(string key)
        //{
        //    return _memoryCache.Get(key) != null ? true : false;
        //}

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            foreach (var item in _memoryCache)
            {
                if (item.Key.Contains(pattern))
                    _memoryCache.Remove(item.Key);
            }

        }
    }
}
