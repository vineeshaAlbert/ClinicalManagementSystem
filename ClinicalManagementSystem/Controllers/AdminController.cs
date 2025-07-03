using ClinicalManagementSystem.Service;
using ClinicalManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicalManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AdminController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        public IActionResult AddUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(model);
                TempData["Message"] = "User created successfully!";
            }
            else
            {
                TempData["Error"] = "Please check form fields.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleStatus(int userId, bool isActive)
        {
            _userService.UpdateUserStatus(userId, isActive);
            return Json(new { success = true });
        }

        public IActionResult GetRoles()
        {
            var roles = _roleService.GetAllRoles();
            return Json(roles.Select(r => new SelectListItem
            {
                Value = r.RoleId.ToString(),
                Text = r.RoleName
            }));
        }
    }
}
