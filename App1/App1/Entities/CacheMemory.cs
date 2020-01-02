using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;


namespace AppDemo.Entities
{
    public static class CacheMemory
    {
        private static readonly IMemoryCache myCache = new MemoryCache(new MemoryCacheOptions() { });

        public static IMemoryCache MyCache { get { return myCache;  } }
    }
}
