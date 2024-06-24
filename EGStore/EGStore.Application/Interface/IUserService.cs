using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Application.DTO;

namespace EGStore.Application.Interface
{
    public interface IUserService
    {
        List<UserDTO> GetAllUsers();
        UserDTO GetUser(Guid id);
        bool AddUser(UserDTO userDTO);
        bool UpdateUser(UserDTO userDTO);
        bool DeleteUser(Guid id);
        RoleDTO GetRoleByUserName(string userName);
        UserDTO GetUserByUserName(string userName);
    }
}
