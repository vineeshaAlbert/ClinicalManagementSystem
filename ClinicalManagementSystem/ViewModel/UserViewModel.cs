using System.ComponentModel.DataAnnotations;

namespace ClinicalManagementSystem.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "Employee ID")]
        public string? EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Username")]   
        public string? Username { get; set; }

        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [Display(Name = "Role")]
        public int RoleId { get; set; }

        public string? RoleName { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
