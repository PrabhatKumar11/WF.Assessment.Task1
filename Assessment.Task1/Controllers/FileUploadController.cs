using Microsoft.AspNetCore.Mvc;
using Assessment.Task1.Models;
using System.Text;
using Assessment.Task1.Bc;
using Assessment.Task1.Service;

namespace Assessment.Task1.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICacheService _cacheService;
        private readonly IFileHandler _fileHandler;
        private readonly IEmployeeDao _employeeBc;

        public FileUploadController(IWebHostEnvironment webHostEnvironment, ICacheService cacheService, 
            IFileHandler fileHandler, IEmployeeDao employeeBc)
        {
            _webHostEnvironment = webHostEnvironment;
            _cacheService = cacheService;
            _fileHandler = fileHandler;
            _employeeBc = employeeBc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();

        [HttpPost]
        public ActionResult Upload(IFormFile postedFile)
        {
            //Create Directory
            string path = _fileHandler.CreateDirectory(_webHostEnvironment.WebRootPath);

            //upload file
            if (!string.IsNullOrEmpty(postedFile?.FileName))
            {
                string filePath = _fileHandler.UploadFile(postedFile, path);
                ViewBag.Message += "File Uploaded Successfully.";

                //Read file
                string csvData = System.IO.File.ReadAllText(filePath);

                _employeeBc.CreateEmployeeCollection(csvData, Employees);

                _cacheService.AddToCache(Employees);
            }
            else
            {
                ViewBag.Message += "Please upload file.";
            }
            return RedirectToAction("Index", "Home");

        }   
  
    }
}
