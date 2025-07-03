using ClinicalManagementSystem.Service;
using ClinicalManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalManagementSystem.Controllers
{
    public class AccountController : Controller
    {
       
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userService.Login(model.Username, model.Password);
                    if (user != null)
                    {
                        HttpContext.Session.SetString("Username", user.Username);
                        HttpContext.Session.SetString("Role", user.RoleName);

                        return user.RoleName switch
                        {
                            "Admin" => RedirectToAction("Dashboard", "Admin"),
                            "Receptionist" => RedirectToAction("Dashboard", "Receptionist"),
                            "Doctor" => RedirectToAction("Dashboard", "Doctor"),
                            "LabTechnician" => RedirectToAction("Dashboard", "Lab"),
                            "Pharmacist" => RedirectToAction("Dashboard", "Pharmacy"),
                            _ => RedirectToAction("Login")
                        };
                    }
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
