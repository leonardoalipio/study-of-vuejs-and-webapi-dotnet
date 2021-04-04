using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configuration
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, 
                                                    string recordId, 
                                                    T data, 
                                                    TimeSpan? absoluteExpireTime= null,
                                                    TimeSpan? unusedExpireTime = null)
        {

        }
    }
}
