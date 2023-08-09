using Assessment.Task1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Task1.Bc
{
    public class FileHandler : IFileHandler
    {
        public StringBuilder CreateCsvFile(IEnumerable<EmployeeModel>? employees)
        {
            var sb = new StringBuilder();

            if (employees != null && employees.Any())
            {
                foreach (var emp in employees)
                {
                    sb.Append(emp.EmployeeId + ",");
                    sb.Append(emp.Name + ",");
                    sb.Append(emp.Country);

                    sb.Append("\r\n");
                }
            }

            return sb;
        }
        public string UploadFile(IFormFile postedFile, string path)
        {
            string fileName = Path.GetFileName(postedFile.FileName);
            string filePath = Path.Combine(path, fileName);

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                postedFile.CopyTo(stream);
               
            }

            return filePath;
        }

        public string CreateDirectory(string webRootPath)
        {
            string path = Path.Combine(webRootPath, "upload");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
