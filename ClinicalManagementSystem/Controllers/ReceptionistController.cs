using ClinicalManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalManagementSystem.Controllers
{
    public class ReceptionistController : Controller
    {
        public IActionResult Index()
        {

            //if (string.IsNullOrEmpty(HttpContext.Session.GetString("ReceptionistId")))
            //    return RedirectToAction("Login");

            //ViewBag.Name = HttpContext.Session.GetString("ReceptionistUsername");
            return View();
        }
        public IActionResult ManagePatients()
        {
            var patients = _patientService.GetAllPatients();
            return View(patients);
        }

        [HttpPost]
        public IActionResult AddPatient(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                _patientService.AddPatient(model);
                TempData["Message"] = "Patient added successfully";
            }
            return RedirectToAction("ManagePatients");
        }

        [HttpPost]
        public IActionResult EditPatient(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                _patientService.UpdatePatient(model);
                TempData["Message"] = "Patient updated successfully";
            }
            return RedirectToAction("ManagePatients");
        }

    }
}
