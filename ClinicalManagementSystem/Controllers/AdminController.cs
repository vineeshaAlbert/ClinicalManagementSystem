using ClinicalManagementSystem.Service;
using ClinicalManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            ViewBag.Receptionists = _adminService.GetReceptionists();
            ViewBag.Doctors = _adminService.GetDoctors();
            ViewBag.Pharmacists = _adminService.GetPharmacists();
            ViewBag.Lab = _adminService.GetLabTechnicians();
            return View();
        }

        // ============== Manage Views ===============
        public IActionResult ManageReceptionists()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];
            var receptionists = _adminService.GetReceptionists();
            return View(receptionists);
        }

        public IActionResult ManageDoctors()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];
            var doctors = _adminService.GetDoctors();
            return View(doctors);
        }

        public IActionResult ManagePharmacists()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];
            var pharmacists = _adminService.GetPharmacists();
            return View(pharmacists);
        }

        public IActionResult ManageLabTechnicians()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];
            var labs = _adminService.GetLabTechnicians();
            return View(labs);
        }

        // ============== Add ====================
        [HttpPost]
        public IActionResult AddReceptionist(StaffCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddReceptionist(model);
                TempData["Message"] = "Receptionist added successfully.";
            }
            else
            {
                TempData["Error"] = "Invalid receptionist data.";
            }
            return RedirectToAction("ManageReceptionists");
        }

        [HttpPost]
        public IActionResult AddDoctor(StaffCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddDoctor(model);
                TempData["Message"] = "Doctor added successfully.";
            }
            else
            {
                TempData["Error"] = "Invalid doctor data.";
            }
            return RedirectToAction("ManageDoctors");
        }

        [HttpPost]
        public IActionResult AddPharmacist(StaffCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddPharmacist(model);
                TempData["Message"] = "Pharmacist added successfully.";
            }
            else
            {
                TempData["Error"] = "Invalid pharmacist data.";
            }
            return RedirectToAction("ManagePharmacists");
        }

        [HttpPost]
        public IActionResult AddLabTechnician(StaffCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddLabTechnician(model);
                TempData["Message"] = "Lab Technician added successfully.";
            }
            else
            {
                TempData["Error"] = "Invalid lab technician data.";
            }
            return RedirectToAction("ManageLabTechnicians");
        }

        // ============== Edit ====================
        [HttpPost]
        public IActionResult EditReceptionist(StaffCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdateReceptionist(model);
                TempData["Message"] = "Receptionist updated.";
            }
            else
            {
                TempData["Error"] = "Invalid receptionist data.";
            }
            return RedirectToAction("ManageReceptionists");
        }

        [HttpPost]
        public IActionResult EditDoctor(StaffCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdateDoctor(model);
                TempData["Message"] = "Doctor updated.";
            }
            else
            {
                TempData["Error"] = "Invalid doctor data.";
            }
            return RedirectToAction("ManageDoctors");
        }

        [HttpPost]
        public IActionResult EditPharmacist(StaffCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdatePharmacist(model);
                TempData["Message"] = "Pharmacist updated.";
            }
            else
            {
                TempData["Error"] = "Invalid pharmacist data.";
            }
            return RedirectToAction("ManagePharmacists");
        }

        [HttpPost]
        public IActionResult EditLabTechnician(StaffCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdateLabTechnician(model);
                TempData["Message"] = "Lab Technician updated.";
            }
            else
            {
                TempData["Error"] = "Invalid lab technician data.";
            }
            return RedirectToAction("ManageLabTechnicians");
        }

        // ============== Delete ====================
        public IActionResult DeleteReceptionist(int id)
        {
            _adminService.DeactivateReceptionist(id);
            TempData["Message"] = "Receptionist deleted.";
            return RedirectToAction("ManageReceptionists");
        }

        public IActionResult DeleteDoctor(int id)
        {
            _adminService.DeactivateDoctor(id);
            TempData["Message"] = "Doctor deleted.";
            return RedirectToAction("ManageDoctors");
        }

        public IActionResult DeletePharmacist(int id)
        {
            _adminService.DeactivatePharmacist(id);
            TempData["Message"] = "Pharmacist deleted.";
            return RedirectToAction("ManagePharmacists");
        }

        public IActionResult DeleteLabTechnician(int id)
        {
            _adminService.DeactivateLabTechnician(id);
            TempData["Message"] = "Lab Technician deleted.";
            return RedirectToAction("ManageLabTechnicians");
        }

        //Toggle
        [HttpPost]
        public IActionResult ToggleStatus(int userId, bool isActive)
        {
            try
            {
                _adminService.UpdateUserStatus(userId, isActive);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Logout", "Account");
        }
    }
}
