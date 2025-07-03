using ClinicalManagementSystem.Models;
using ClinicalManagementSystem.ViewModel;

namespace ClinicalManagementSystem.Service
{
    public interface IAdminService
    {
        List<Receptionist> GetReceptionists();
        void AddReceptionist(StaffCreateViewModel receptionist);
        Receptionist GetReceptionistById(int id);
        void UpdateReceptionist(StaffCreateViewModel receptionist);
        void DeactivateReceptionist(int id);

        List<Doctor> GetDoctors();
        void AddDoctor(StaffCreateViewModel doctor);
        Doctor GetDoctorById(int id);
        void UpdateDoctor(StaffCreateViewModel doctor);
        void DeactivateDoctor(int id);

        List<Pharmacist> GetPharmacists();
        void AddPharmacist(StaffCreateViewModel pharmacist);
        Pharmacist GetPharmacistById(int id);
        void UpdatePharmacist(StaffCreateViewModel pharmacist);
        void DeactivatePharmacist(int id);

        List<Lab> GetLabTechnicians();
        void AddLabTechnician(StaffCreateViewModel lab);
        Lab GetLabTechnicianById(int id);
        void UpdateLabTechnician(StaffCreateViewModel lab);
        void DeactivateLabTechnician(int id);

        void UpdateUserStatus(int userId, bool isActive);

    }
}
