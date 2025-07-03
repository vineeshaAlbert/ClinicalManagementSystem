using System.ComponentModel.DataAnnotations;

namespace ClinicalManagementSystem.Models
{
    public class Lab
    {
        public int LabId { get; set; }
        public string LabEmpId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Contact { get; set; }

        public bool IsActive { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
