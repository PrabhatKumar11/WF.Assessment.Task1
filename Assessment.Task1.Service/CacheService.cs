using Assessment.Task1.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Task1.Service
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddToCache(List<EmployeeModel> employees)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));

            if(!_memoryCache.TryGetValue(Constants.Employees, out object cacheValue))
            {
                _memoryCache.Set(Constants.Employees, employees, cacheEntryOptions);
            }

            var employeeModel = cacheValue as IEnumerable<EmployeeModel>;
            if (employeeModel != null)
            {
                employees.AddRange(employeeModel);
            }
            _memoryCache.Set(Constants.Employees, employees.Distinct(), cacheEntryOptions);
        }

        public IEnumerable<EmployeeModel>? ReadFromCache(string key)
        {
            if (_memoryCache.TryGetValue(key, out object cacheValue))
            {
                if(cacheValue is IEnumerable<EmployeeModel>)
                {
                    return (IEnumerable<EmployeeModel>)cacheValue;
                }
            }
            return null;
        }
    }
}
