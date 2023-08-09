using Assessment.Task1.Models;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Assessment.Task1.Bc
{
    public interface IFileHandler
    {
        StringBuilder CreateCsvFile(IEnumerable<EmployeeModel>? employees);
        string UploadFile(IFormFile postedFile, string path);
        string CreateDirectory(string webRootPath);
    }
}