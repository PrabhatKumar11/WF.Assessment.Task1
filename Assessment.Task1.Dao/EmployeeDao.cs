using Assessment.Task1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Task1.Bc
{
    public class EmployeeDao : IEmployeeDao
    {
        public void CreateEmployeeCollection(string csvData, List<EmployeeModel> Employees)
        {
            //Execute a loop over the rows
            foreach (var row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    string[] splittedData = row.Split(',');
                    if (splittedData != null && splittedData.Length == 3)
                        Employees.Add(new EmployeeModel()
                        {
                            EmployeeId = Convert.ToInt32(row.Split(',')[0]),
                            Name = row.Split(',')[1],
                            Country = row.Split(',')[2]
                        });
                }
            }
        }
    }
}
