using Assessment.Task1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Task1.Service
{
    public interface ICacheService
    {
        void AddToCache(List<EmployeeModel> employees);

        IEnumerable<EmployeeModel>? ReadFromCache(string key);
    }
}
