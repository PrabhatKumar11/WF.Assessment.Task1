using Microsoft.AspNetCore.Mvc;
using Assessment.Task1.Models;
using Assessment.Task1.Dao;

namespace Assessment.Task1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserDao _userDao;

        public LoginController(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public IActionResult Index()
        {
            var indexModel = new IndexModel();
            return View(indexModel);
        }

        public IActionResult Login(IndexModel indexModel)
        {
            var users = _userDao.GetUsers();
            bool isFound = false;
            foreach (var user in users)
            {
                if (indexModel.Username.Equals(user.Username) && indexModel.Password.Equals(user.Password))
                {
                    isFound = true;
                    break;
                }
            }
            if (isFound)
            {
                HttpContext.Session.SetString(Constants.UserName, indexModel.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Error"] = "Please enter correct username & password.";
                return View("Index");
            }
        }
    }
}
