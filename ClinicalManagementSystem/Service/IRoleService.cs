using ClinicalManagementSystem.Models;
using System.Collections.Generic;
using System.Data;

namespace ClinicalManagementSystem.Service
{
    public interface IRoleService
    {
        List<Role> GetAllRoles();
    }
}
