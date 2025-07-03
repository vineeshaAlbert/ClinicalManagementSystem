using System.ComponentModel.DataAnnotations;

namespace ClinicalManagementSystem.ViewModel
{
    public class StaffCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Contact { get; set; }
        public int ReceptionistId { get; set; }
        public int DoctorId { get; set; }
        public int PharmacistId { get; set; }
        public int LabId { get; set; }
    }
}
