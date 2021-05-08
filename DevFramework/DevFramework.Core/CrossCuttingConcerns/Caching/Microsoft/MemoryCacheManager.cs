using System;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;


namespace DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache cache => MemoryCache.Default;

        //60 dk
        public void Add(string key, object data, int cacheTime = 60)
        {
            if (data == null)
            {
                return;
            }
            // cachede varsayılan degerimiz olan 60 dk tutmasını söylüyoruz.
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime) };
            cache.Add(new CacheItem(key, data), policy);
        }

        public void Clear()
        {
            foreach (var item in cache)
            {
                Remove(item.Key);
            }
        }

        public T Get<T>(string key)
        {
            return (T)cache[key];
        }

        public bool IsAdd(string key)
        {
            return cache.Contains(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cache.Where(d => regex.IsMatch(d.Key)).Select(d => d.Key).ToList();
            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}