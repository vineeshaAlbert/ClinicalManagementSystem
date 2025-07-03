using System.ComponentModel.DataAnnotations;

namespace ClinicalManagementSystem.Models
{
    public class Receptionist
    {
        public int ReceptionistId { get; set; }
        public string ReferenceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        public bool IsActive { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
