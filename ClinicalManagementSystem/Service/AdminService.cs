using ClinicalManagementSystem.Models;
using ClinicalManagementSystem.Repository;
using ClinicalManagementSystem.ViewModel;
using System.Numerics;

namespace ClinicalManagementSystem.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repo;

        public AdminService(IAdminRepository repo)
        {
            _repo = repo;
        }

        public List<Receptionist> GetReceptionists() => _repo.GetReceptionists();
        public void AddReceptionist(StaffCreateViewModel receptionist) => _repo.AddReceptionist(receptionist);
        public Receptionist GetReceptionistById(int id) => _repo.GetReceptionistById(id);
        public void UpdateReceptionist(StaffCreateViewModel receptionist) => _repo.UpdateReceptionist(receptionist);
        public void DeactivateReceptionist(int id) => _repo.DeactivateReceptionist(id);

        public List<Doctor> GetDoctors() => _repo.GetDoctors();
        public void AddDoctor(StaffCreateViewModel doctor) => _repo.AddDoctor(doctor);
        public Doctor GetDoctorById(int id) => _repo.GetDoctorById(id);
        public void UpdateDoctor(StaffCreateViewModel doctor) => _repo.UpdateDoctor(doctor);
        public void DeactivateDoctor(int id) => _repo.DeactivateDoctor(id);

        public List<Pharmacist> GetPharmacists() => _repo.GetPharmacists();
        public void AddPharmacist(StaffCreateViewModel pharmacist) => _repo.AddPharmacist(pharmacist);
        public Pharmacist GetPharmacistById(int id) => _repo.GetPharmacistById(id);
        public void UpdatePharmacist(StaffCreateViewModel pharmacist) => _repo.UpdatePharmacist(pharmacist);
        public void DeactivatePharmacist(int id) => _repo.DeactivatePharmacist(id);

        public List<Lab> GetLabTechnicians() => _repo.GetLabTechnicians();
        public void AddLabTechnician(StaffCreateViewModel lab) => _repo.AddLabTechnician(lab);
        public Lab GetLabTechnicianById(int id) => _repo.GetLabTechnicianById(id);
        public void UpdateLabTechnician(StaffCreateViewModel lab) => _repo.UpdateLabTechnician(lab);
        public void DeactivateLabTechnician(int id) => _repo.DeactivateLabTechnician(id);
        public void UpdateUserStatus(int userId, bool isActive)
        {
            _repo.UpdateUserStatus(userId, isActive);
        }

    }
}
