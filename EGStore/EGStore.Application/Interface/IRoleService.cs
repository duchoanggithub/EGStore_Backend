using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Application.DTO;

namespace EGStore.Application.Interface
{
    public interface IRoleService
    {
        List<RoleDTO> GetAllRoles();
        RoleDTO GetRole(Guid id);
        bool AddRole(RoleDTO roleDTO);
        bool UpdateRole(RoleDTO roleDTO);
        bool DeleteRole(Guid id);
    }
}
