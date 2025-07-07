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
            if (!ModelState.IsValid)
            {
                foreach (var err in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(err.ErrorMessage); // Log to console for debugging
                }
                return View(model);
            }


            try
            {
                var user = _userService.Login(model.Username, model.Password);

                if (user != null)
                {
                    // 💾 Store session
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Role", user.RoleName);

                    // ✅ Clean up role string
                    string role = user.RoleName?.Trim().ToLower();

                    switch (role)
                    {
                        case "admin":
                            return RedirectToAction("Index", "Admin");

                        case "receptionist":
                            return RedirectToAction("Index", "Receptionist");

                        case "doctor":
                            return RedirectToAction("TodayAppointments", "Doctor", new { doctorId = user.UserId });

                        case "pharmacist":
                            return RedirectToAction("Index", "Pharmacist");

                        case "lab":
                            return RedirectToAction("Index", "Lab");

                        default:
                            ViewBag.Error = $"Unrecognized role: {user.RoleName}";
                            break;
                    }
                }
                else
                {
                    ViewBag.Error = "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Login failed: {ex.Message}";
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
