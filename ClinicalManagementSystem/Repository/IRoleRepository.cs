using ClinicalManagementSystem.Models;
using System.Collections.Generic;
using System.Data;

namespace ClinicalManagementSystem.Repository
{
    public interface IRoleRepository
    {
        List<Role> GetAllRoles();
    }
}
