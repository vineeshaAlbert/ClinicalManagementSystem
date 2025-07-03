using ClinicalManagementSystem.Models;
using ClinicalManagementSystem.ViewModel;

namespace ClinicalManagementSystem.Repository
{
    public interface IUserRepository
    {
        User Login(string username, string password);
        List<UserViewModel> GetAllUsers();
        void AddUser(UserViewModel user);
        void UpdateUserStatus(int userId, bool isActive);
    }
}
