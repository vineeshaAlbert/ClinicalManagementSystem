using ClinicalManagementSystem.Models;
using ClinicalManagementSystem.Repository;
using ClinicalManagementSystem.ViewModel;

namespace ClinicalManagementSystem.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Login(string username, string password)
        {
            return _repository.Login(username, password);
        }
        public List<UserViewModel> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public void AddUser(UserViewModel user)
        {
            _repository.AddUser(user);
        }

        public void UpdateUserStatus(int userId, bool isActive)
        {
            _repository.UpdateUserStatus(userId, isActive);
        }
    }
}

