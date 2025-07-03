using ClinicalManagementSystem.Models;
using ClinicalManagementSystem.Repository;
using System.Collections.Generic;
using System.Data;

namespace ClinicalManagementSystem.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }
    }
}
