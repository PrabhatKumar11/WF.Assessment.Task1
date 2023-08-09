using Assessment.Task1.Models;
using Assessment.Task1.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assessment.Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICacheService _cacheService;

        public HomeController(ILogger<HomeController> logger, ICacheService cacheService)
        {
            _logger = logger;
            _cacheService = cacheService;
        }

        public IActionResult Index()
        {
            var uname = HttpContext.Session.GetString(Constants.UserName);
            ViewData[Constants.UserName] = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(uname?.ToLower() ?? String.Empty);

            var employeeModel = _cacheService.ReadFromCache(Constants.Employees);

            return View("Home", employeeModel ?? new List<EmployeeModel>());
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(Constants.UserName);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}