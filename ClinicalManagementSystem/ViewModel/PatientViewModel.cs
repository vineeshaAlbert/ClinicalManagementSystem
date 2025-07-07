using System.ComponentModel.DataAnnotations;

namespace ClinicalManagementSystem.ViewModel
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string Phone { get; set; }

        public bool IsActive { get; set; }
    }
}
