using Assessment.Task1.Models;

namespace Assessment.Task1.Bc
{
    public interface IEmployeeDao
    {
        void CreateEmployeeCollection(string csvData, List<EmployeeModel> Employees);
    }
}