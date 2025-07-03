using ClinicalManagementSystem.Models;
using ClinicalManagementSystem.ViewModel;

namespace ClinicalManagementSystem.Service
{
    public interface IUserService
    {
        User Login(string username, string password);
        List<UserViewModel> GetAllUsers();
        void AddUser(UserViewModel user);
        void UpdateUserStatus(int userId, bool isActive);
    }
}
