using Assessment.Task1.Models;
using Assessment.Task1.Bc;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Assessment.Task1.Service;

namespace Assessment.Task1.Controllers
{
    public class FileDownloadController : Controller
    {
        private readonly ICacheService _cacheService;
        private readonly IFileHandler _fileHandler;

        public FileDownloadController(ICacheService cacheService, IFileHandler fileHandler)
        {
            _cacheService = cacheService;
            _fileHandler = fileHandler;
        }
        [HttpPost]
        public IActionResult GetCsv()
        {
            var employees = _cacheService.ReadFromCache(Constants.Employees);
            StringBuilder sb = _fileHandler.CreateCsvFile(employees);

            var filename = $"Employee-{DateTime.Now}.csv";
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", filename);
        }

       
    }
}
